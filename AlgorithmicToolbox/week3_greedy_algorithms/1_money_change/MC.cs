using System;

namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            var value = int.Parse(Console.ReadLine());            
            var result = CountCoins(value);
            Console.WriteLine(result);
        }

        static int CountCoins(int value)
        {
            var coinsQuantity = 0;
            coinsQuantity = value / 10;
            value = value % 10;
            coinsQuantity += value / 5;
            value = value % 5;
            coinsQuantity += value;
            return coinsQuantity;
        }
    }
}