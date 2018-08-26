using System;
using System.Collections.Generic;
using System.Linq;

namespace KuriyamaMiraisStones
{
    public class Program
    {
        private static void Main()
        {
            Console.ReadLine();
            var stones = Console.ReadLine()?.Split(' ') ?? new string[0];
            var questionsNumber = int.Parse(Console.ReadLine());

            var stonesValues = stones.Select(int.Parse).ToArray();

            var stonesValuesSorted = new int[stonesValues.Length];
            Array.Copy(stonesValues, stonesValuesSorted, stonesValues.Length);
            Array.Sort(stonesValuesSorted);

            var partSum = GetPartSums(stonesValues).ToArray();
            var partSumSorted = GetPartSums(stonesValuesSorted).ToArray();

            var questions = new Question[questionsNumber];

            for (var i = 0; i < questionsNumber; i++)
            {
                var s = Console.ReadLine()?.Split(' ') ?? new string[0];
                questions[i] = new Question
                {
                    Type = byte.Parse(s[0]),
                    LeftPointer = int.Parse(s[1]) - 1,
                    RightPointer = int.Parse(s[2]) - 1
                };
            }

            for (var i = 0; i < questionsNumber; i++)
                if (questions[i].Type == 1)
                    questions[i].Answer = partSum[questions[i].RightPointer]
                                          - partSum[questions[i].LeftPointer]
                                          + stonesValues[questions[i].LeftPointer];
                else
                    questions[i].Answer = partSumSorted[questions[i].RightPointer]
                                          - partSumSorted[questions[i].LeftPointer]
                                          + stonesValuesSorted[questions[i].LeftPointer];

            var res = string.Join("\r\n", questions.Select(q => q.Answer));
            Console.Write(res);
        }

        private static IEnumerable<long> GetPartSums(IEnumerable<int> array)
        {
            var tempSum = default(long);

            foreach (var item in array) yield return tempSum += item;
        }
    }

    public struct Question
    {
        public byte Type { get; set; }
        public int LeftPointer { get; set; }
        public int RightPointer { get; set; }
        public long Answer { get; set; }
    }
}