using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimitiveCalculator
{
    class Program
    {
        static void Main()
        {
            var destination = int.Parse(Console.ReadLine());
            var result = Count(destination);
            Console.WriteLine(result.Count - 1);
            foreach (var r in result)
            {
                Console.Write($"{r} ");
            }
        }
        private static List<int> Count(int destination)
        {            
            var result = new List<List<int>>();
            result.Add(new List<int>{1});
            for (int i = 2; i <= destination; i++)
            {
                var currentWay = new List<int>();
                var currentMinimum = i;
                var currentAction = 0;
                if (result.ElementAt(i - 1 - 1).Count + 1 <= currentMinimum)
                {
                    currentMinimum = result.ElementAt(i - 1 - 1).Count + 1;
                    currentAction = 1;
                }
                if (i % 2 == 0)
                {
                    if (result.ElementAt(i / 2 - 1).Count + 1 < currentMinimum)
                    {
                        currentMinimum = result.ElementAt(i / 2 - 1).Count + 1;
                        currentAction = 2;
                    }
                }
                if (i % 3 == 0)
                {
                    if (result.ElementAt(i / 3 - 1).Count + 1 < currentMinimum)
                    {
                        currentMinimum = result.ElementAt(i / 3 - 1).Count + 1;
                        currentAction = 3;
                    }
                }
                // Console.WriteLine(currentAction);
                switch(currentAction)
                {
                    case 1:
                        currentWay.AddRange(result.ElementAt(i-1 - 1));
                        break;
                    case 2:
                        currentWay.AddRange(result.ElementAt(i / 2  - 1));
                        break;
                    case 3:
                        currentWay.AddRange(result.ElementAt(i / 3 - 1));
                        break;
                }
                currentWay.Add(i);
                result.Add(currentWay);
            }
            return result.Last();
        }
    }
}