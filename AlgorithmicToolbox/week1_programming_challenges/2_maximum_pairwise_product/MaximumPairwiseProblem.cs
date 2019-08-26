using System;
using System.Collections.Generic;

namespace MPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine();
            var numbers = new List<int>(int.Parse(size));
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            foreach (var item in tokens)
            {
                numbers.Add(int.Parse(item));
            }
            Console.WriteLine(MaximumPairwise(numbers));
        }

        private static long MaximumPairwise(List<int> numbers)
        {
            var maxIndex1 = 0;
            
            for(var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[maxIndex1])
                {
                    maxIndex1 = i;
                }
            }
            var maxIndex2 = maxIndex1 == 0 ? 1 : 0;
            for(var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[maxIndex2] && i != maxIndex1)
                {
                    maxIndex2 = i;
                }
            }
            return ((long)numbers[maxIndex1])*numbers[maxIndex2]; 
        }
    }
}