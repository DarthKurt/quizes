using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lecture
{
    class Program
    {
        private static void Main()
        {
            Do();
        }

        private static void Do()
        {          
            var strings = new Stack<string>();
            string s;
            while((s = Console.ReadLine()) != null && !string.IsNullOrWhiteSpace(s))
            {
                strings.Push(s);
            }

            var lecture = new Queue<string>(strings.Pop().Split(' '));
            var dict = (from l in strings
                       let pair = l.Split(' ')
                       where pair[1].Length < pair[0].Length
                       select pair).ToDictionary(l => l[0], l => l[1]); //Check perfomance
            
            var sb = new StringBuilder();
            while(lecture.Count > 0)
            {
                var word = lecture.Dequeue();
                if(dict.ContainsKey(word))
                    sb.Append($"{dict[word]} ");
                else
                    sb.Append($"{word} ");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}