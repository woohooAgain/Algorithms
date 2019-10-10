using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyChangeAgain
{
    class Program
    {
        static void Main()
        {
            var money = int.Parse(Console.ReadLine());
            var coins = new List<int>{1, 3, 4};
            Console.WriteLine(CountCoinsV3(money, coins));
        }
        private static int CountCoinsV3(int money, List<int> coins)
        {            
            var coinsQuanity = new int[money+1];
            coinsQuanity[1] = 1;
            for(var i = 2; i <= money; i++)
            {
                var currentMinimum = i;
                foreach(var coin in coins)
                {
                    if (i >= coin)
                    {
                        var currentQuantity = coinsQuanity[i - coin] + 1;
                        if (currentQuantity < currentMinimum)
                        {
                            currentMinimum = currentQuantity;
                        }
                    }
                }
                coinsQuanity[i] = currentMinimum;
            }
            return coinsQuanity[money];
        }
    }
}