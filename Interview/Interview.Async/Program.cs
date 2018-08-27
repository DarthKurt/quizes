using System;
using System.Threading.Tasks;
using System.Threading;

namespace Interview.Async
{
    // What is the output of the short program below? Explain your answer.
    public sealed class Program
    {
        private static string result;

        public static async Task Main()
        {
            SaySomething();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static async Task<string> SaySomething()
        {
            Thread.Sleep(5);
            result = "Hello world!";
            return "Something";
        }
    }
}