using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SplittingMoney
{
    class Program
    {
        private static void Main()
        {
            Do();
        }

        private static void Do()
        {
            Console.ReadLine()?.Trim();
            var walletsString = Console.ReadLine()?.Trim();
            var wallets = walletsString.Split(' ').Select(w => int.Parse(w)).ToArray();
            Array.Sort(wallets);
            
            var paramString = Console.ReadLine()?.Trim();
            var param = paramString.Split(' ').Select(p => int.Parse(p)).ToArray();
            var threshold = param[0];
            var price = param[1];

            var res = wallets
                        .SkipWhile(w => w <= threshold)
                        .Select(w => {
                            long sum = Math.DivRem(w, threshold + price, out var rem);
                            if(rem > threshold)
                                sum++;
                            return sum * price;
                        })
                        .Sum();
            
            Console.WriteLine(res);
        }
    }
}