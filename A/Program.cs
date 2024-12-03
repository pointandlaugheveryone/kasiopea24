using StreamWriter output = new StreamWriter("reseni.txt");
using (StreamReader input = new StreamReader("A-tezky.txt"))
{
    int solutions = int.Parse(input.ReadLine()!);

    for (int currentProblem = 1; currentProblem <= solutions; currentProblem++) {
        int[] numbers = input.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        int answer = 0;

        int papers = numbers[0];
        int cut1 = numbers[1];
        int batchTime = numbers[2];
        int countScissors = numbers[3];

        int timeToCut = cut1 * papers;
        int timeScissors = 0;

        int fullBatches = papers / countScissors;
        int remainderPapers = papers % countScissors;
        int fullBatchesTime = fullBatches * batchTime + (remainderPapers > 0 ? batchTime : 0);
        int combineTime = fullBatches * batchTime + (remainderPapers * cut1);
        timeScissors = Math.Min(fullBatchesTime, combineTime);

        answer = Math.Min(timeToCut, timeScissors);
        output.WriteLine(answer);
    }
}
