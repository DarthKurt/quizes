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
            ushort i = 1;
            var s = Console.ReadLine().Split(' ')
                .Select(c => new StudentRedirect{
                             From = i++,
                             To = ushort.Parse(c)
                            })
                .ToDictionary(t => t.From, t => t.To);

            var sb = new StringBuilder();

            for (ushort j = 1; j < s.Count + 1; j++)
            {
                var res = CheckStudent(s, j);
                sb.Append($"{res} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static ushort CheckStudent(IDictionary<ushort, ushort> mapping, ushort startStudent)
        {
            var students = new bool[mapping.Count + 1];
            ushort i = startStudent;

            while(!students[i])
            {
                students[i] = true;
                i = mapping[i];
            }

            return i;
        }
    }

    public struct StudentRedirect {
        public ushort From;
        public ushort To;
    }
}