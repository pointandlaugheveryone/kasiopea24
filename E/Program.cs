// TODO: comment the whole thing because i have no fucking clue how this works 

using StreamWriter output = new StreamWriter("reseni.txt");
using StreamReader input = new StreamReader("E-tezky.txt");

int solutions = int.Parse(input.ReadLine()!);

for (int currentProblem = 0; currentProblem < solutions; currentProblem++) {
    int numOfNodes = int.Parse(input.ReadLine()!); 
    List<int> teamIDs = input.ReadLine()!.Split(' ').Select(int.Parse).ToList(); // Team IDs for cities 1 to N-1

    var ans = new long[numOfNodes + 1];

    City[] cities = new City[numOfNodes + 1]; // 1-based indexing bc of the input; TODO: practice indexing bullshit

    // Initialize cities from 1 to N-1 with their team IDs
    for (int i = 1; i <= numOfNodes - 1; i++) {
        cities[i] = new City(i, teamIDs[i - 1]);
    }

    City root = new City(numOfNodes, 0);
    cities[numOfNodes] = root;

    for (int i = 0; i < numOfNodes - 1; i++) {
        List<int> edge = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        int A = edge[0];
        int B = edge[1];
        cities[A].AddNeighbors(cities[B]);
    }


    DFS.GetParents(root, null);
    
    Dictionary<int, int> teamAncestors = [];
    DFS.GetDistance(root, 0, teamAncestors, ans);

    output.WriteLine(string.Join(" ", ans[1..numOfNodes]));
}
