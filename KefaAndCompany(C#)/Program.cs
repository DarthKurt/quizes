using System;
using System.Collections.Generic;
using System.Linq;

namespace KefaAndCompanyClassic
{
    internal class Program
    {
        public static void Main()
        {
            var threshold = uint.Parse(Console.ReadLine()?.Split(' ')[1] ?? throw new InvalidOperationException());
            string s;
            var people = new List<(uint, uint)>();
            while ((s = Console.ReadLine()) != null && s != string.Empty)
            {
                var lineArray = s.Split(' ');
                people.Add((uint.Parse(lineArray[0]), uint.Parse(lineArray[1])));
            }

            var sorted = (from p in people
                          orderby p.Item1 descending
                          select p).ToArray();

            var maxMoney = sorted[0].Item1;

            if (threshold > maxMoney)
            {
                var sum = sorted.Aggregate(0L, (current, i) => current + i.Item2);
                Console.WriteLine(sum);
                return;
            }

            var calculatror = new Calculator(sorted, threshold);
            var f = calculatror.Calc();
            Console.WriteLine(f);
        }
    }

    internal class Calculator
    {
        private long _friendship;
        private long _groupFriendship;
        private readonly uint _threshold;
        private readonly LinkedList<(uint, uint)> _group;
        private readonly Stack<(uint, uint)> _stack;

        public Calculator(IEnumerable<(uint, uint)> sortedInput, uint threshold)
        {
            _threshold = threshold;
            _friendship = 0L;
            _groupFriendship = 0L;
            _group = new LinkedList<(uint, uint)>();
            _stack = new Stack<(uint, uint)>(sortedInput);
        }

        public long Calc()
        {
            while (_stack.Count != 0)
            {
                var topFriend = _stack.Pop();

                _group.AddLast(topFriend);
                _groupFriendship += topFriend.Item2;

                while (_group.Count > 0 && ReduceGroup())
                { }
            }

            return _friendship;
        }

        private bool ReduceGroup()
        {
            var first = _group.First.Value;
            if (!Check(_group.Last.Value.Item1, first.Item1, _threshold))
            {
                _groupFriendship -= first.Item2;
                _group.RemoveFirst();
            }
            else
            {
                _friendship = _friendship > _groupFriendship
                    ? _friendship
                    : _groupFriendship;
                return false;
            }

            return true;
        }

        private static bool Check(uint last, uint first, uint threshold)
        {
            return last - first < threshold;
        }
    }
}