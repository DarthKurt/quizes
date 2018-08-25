using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CinemaLine
{
    class Program
    {
        static void Main()
        {
            if (string.IsNullOrWhiteSpace(Console.ReadLine()?.Trim() ?? string.Empty))
                return;

            var s = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(s))
                return;

            var queue = new Queue<string>(s.Split(' '));

            var storage = new Storage();
            while (queue.Count > 0)
            {
                var note = uint.Parse(queue.Dequeue());
                if(!storage.Buy(note)){
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }

        internal sealed class Storage
    {
        public uint TwentyFivesCount { get; set; }
        public uint FiftiesCount { get; set; }

        public bool Buy(uint note)
        {
            switch (note)
            {
                case 25:
                    TwentyFivesCount++;
                    return true;
                case 50:
                    if(TwentyFivesCount > 0){
                        TwentyFivesCount--;
                        FiftiesCount++;
                        return true;
                    } else {
                        return false;
                    }
                case 100:
                    if(FiftiesCount > 0 && TwentyFivesCount > 0){
                        TwentyFivesCount--;
                        FiftiesCount--;
                        return true;
                    } else if(TwentyFivesCount > 2) {
                        TwentyFivesCount -= 3;
                        return true;
                    } else {
                        return false;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

