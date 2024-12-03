class Program
{
    static void Main()
    {
        using StreamWriter output = new StreamWriter("reseni.txt");
        using StreamReader input = new StreamReader("F-lehky.txt");

        int solutions = int.Parse(input.ReadLine()!);

        for (int currentProblem = 0; currentProblem < solutions; currentProblem++)
        {
            string[] parts = input.ReadLine()!.Split(' ');
            long days = long.Parse(parts[0]);
            long logs = long.Parse(parts[1]);
            long cost = long.Parse(parts[2]);
            long limit = long.Parse(parts[3]);

            long ans = Algo.TernarySearch(days, logs, cost, limit);
            output.WriteLine(ans);
        }
    }
}