using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFueling
{
    class Program
    {
        static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            var inputArray = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var border = number / 2;
            var dict = new Dictionary<long, long>();
            foreach(var e in inputArray)
            {
                long val;
                if(!dict.TryGetValue(e, out val))
                {
                    dict[e] = 1; 
                }
                else
                {
                    dict[e] += 1; 
                }
            }
            foreach(var v in dict.Values)
            {
                if (v > border)
                {
                    Console.WriteLine("1");
                    return;
                }
            }
            Console.WriteLine("0");
        }
    }
}