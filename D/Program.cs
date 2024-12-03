using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        using StreamWriter output = new StreamWriter("reseni.txt");
        using (StreamReader input = new StreamReader("D-tezky.txt"))
        {
            int solutions = int.Parse(input.ReadLine()!);
            for (int currentProblem = 1; currentProblem <= solutions; currentProblem++)
            {
                int ans = 0;
                int numOfFields = int.Parse(input.ReadLine()!);
                int[] resources = input.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
                
                
                ans = MaxResourcesDP(resources);
                output.WriteLine(ans);
            }
        }

    
        static int MaxResourcesDP(int[] arr)
        {
            int n = arr.Length;
            if (n == 0) return 0;
            if (n == 1) return arr[0];

            int[] dp = new int[n];
            dp[0] = arr[0];
            dp[1] = Math.Max(arr[0], arr[1]);

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], arr[i] + dp[i - 2]);
            }

            return dp[n - 1];
        }
    }
}