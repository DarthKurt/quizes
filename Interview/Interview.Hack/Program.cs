using System;

namespace Interview.Hack
{
    // What is the output of the short program below? Explain your answer.
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Do(123, 687));
            Console.ReadKey();
        }
        
        private static int Do(int A, int B)
        {
            A = A ^ B;
            B = A ^ B;
            return A ^ B;
        }
    }
}