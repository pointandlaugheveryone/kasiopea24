using StreamWriter output = new StreamWriter("reseni.txt");
using (StreamReader input = new StreamReader("C-tezky.txt"))
{
    int solutions = int.Parse(input.ReadLine()!);

    for (int currentProblem = 1; currentProblem <= solutions; currentProblem++)
    {
        int ans = 0;

        int balls = int.Parse(input.ReadLine()!);
        int[] radius = input.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        Array.Sort(radius);

        static int SplitByNums(int[] radiuses)
        {
            var count = radiuses.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            var result = new List<List<int>>();
            var currentNums = new List<int>();

            int maxLength = 0;
            foreach (var num in radiuses)
            {
                if (count[num] > 0)
                {
                    currentNums.Add(num);
                    count[num]--;
                }
                if (count[num] == 0 && currentNums.Count > 0)
                {
                    result.Add(new List<int>(currentNums));
                    if (currentNums.Count > maxLength)
                    {
                        maxLength = currentNums.Count;
                    }
                    currentNums.Clear();
                }
            }
        
            if (currentNums.Count > 0)
            {
                result.Add(currentNums);
                if (currentNums.Count > maxLength)
                {
                    maxLength = currentNums.Count;
                }
            }
            return maxLength;
        }
        ans = SplitByNums(radius);
        output.WriteLine(ans);
    }
}