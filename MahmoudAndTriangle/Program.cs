using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CinemaLine
{
    class Program
    {
        private static void Main()
        {
            Do();
        }

        private static bool Check(uint a, uint b, uint c)
        {
            return (a + b > c);
        }

        private static void Do()
        {
            if (string.IsNullOrWhiteSpace(Console.ReadLine()?.Trim() ?? string.Empty))
                return;

            var s = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(s))
                return;

            var input = s.Split(' ').Select(c => uint.Parse(c));
            var sorted = new Queue<uint>(from p in input
                                    orderby p
                                    select p);

            var window = new LinkedList<uint>();
            window.AddLast(sorted.Dequeue());
            window.AddLast(sorted.Dequeue());
            window.AddLast(sorted.Dequeue());

            var l = sorted.Count;

            if(Check(window.First.Value, window.First.Next.Value, window.Last.Value))
            {
                Console.WriteLine("YES");
                return;
            }

            for (var i = 0U; i < l; i++)
            {
                window.RemoveFirst();
                window.AddLast(sorted.Dequeue());
                if(Check(window.First.Value, window.First.Next.Value, window.Last.Value))
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
            Console.WriteLine("NO");
        }
    }
}