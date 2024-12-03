using System.Runtime.InteropServices.Marshalling;

using StreamWriter output = new StreamWriter("reseni.txt");
using (StreamReader input = new StreamReader("B-tezky.txt"))
{
    int solutions = int.Parse(input.ReadLine()!);

    for (int currentProblem = 1; currentProblem <= solutions; currentProblem++)
    {
        int Len = int.Parse(input.ReadLine()!);
        char[] shelf = input.ReadLine()!.ToCharArray();
        int shelfLen = shelf.Length;
        int underscoreCount = shelf.Count(c => c == '_');
        output.WriteLine(underscoreCount);
    }
}