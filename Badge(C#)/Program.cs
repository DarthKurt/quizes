using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badge
{
    class Program
    {
        private static void Main()
        {
            Do();
        }

        private static void Do()
        {
            Console.ReadLine();
            var s = Console.ReadLine().Split(' ')
                .Select(c => uint.Parse(c) - 1).ToArray();

            var sb = new uint[s.Length];

            for (var i = 0u; i < s.Length; i++)
            {
                sb[i] = CheckStudent(s, i);
            }

            Console.WriteLine(string.Join(" ", sb));
        }

        private static uint CheckStudent(uint[] mapping, uint startStudent)
        {
            var students = new bool[mapping.Length];
            var i = startStudent;

            while(!students[i])
            {
                students[i] = true;
                i = mapping[i];
            }

            return i + 1;
        }
    }
}