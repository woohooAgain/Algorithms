using System;
using System.Collections.Generic;
using System.Linq;

namespace CarFueling
{
    class Program
    {
        static void Main()
        {
            var number = Console.ReadLine();
            var profitPCString = Console.ReadLine();
            var profitPCList = profitPCString.Split(' ').Select(d => int.Parse(d)).ToList();
            var clicksPDString = Console.ReadLine();
            var clicksPDList = clicksPDString.Split(' ').Select(d => int.Parse(d)).ToList();
            profitPCList.Sort();
            clicksPDList.Sort();
            var result = 0;
            var maxNumber = int.Parse(number);
            for(var i = 0; i < maxNumber; i++)
            {
                result += profitPCList[i]*clicksPDList[i];
            }
            Console.WriteLine($"{result}");
        }
    }
}