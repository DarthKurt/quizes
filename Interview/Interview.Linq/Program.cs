using System;
using System.Linq;

namespace Interview.Linq
{
    // What is the output of the short program below? Explain your answer.
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = new int[] {
                7, 2, 5, 5, 7, 6, 7
            };

            Console.WriteLine(Do(n));
            Console.ReadKey();
        }
        
        private static int Do(int[] numbers)
        {
            var result = numbers.Sum() + numbers.Skip(2).Take(3).Sum();
            var y = numbers.GroupBy(x => x).Select(x =>
            {
                result += x.Key;
                return x.Key;
            });
            
            return result;
        }
    }
}