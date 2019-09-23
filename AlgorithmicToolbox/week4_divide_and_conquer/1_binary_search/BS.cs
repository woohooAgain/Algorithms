using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            var firstLineArray = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var secondLineArray = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var initialArray = new long[firstLineArray[0]];
            Array.Copy(firstLineArray,1,initialArray,0,firstLineArray[0]);
            // var result = new List<long>(secondLineArray[0]);
            for(var i = 1; i <= secondLineArray[0]; i++)
            {
                var result = BinarySearch(initialArray, secondLineArray[i], 0, initialArray.Length - 1);
                Console.Write($"{result} ");
            }
        }

        private static long BinarySearch(long[] array, long element, long s, long e)
        {
            if (e == s)
            {
                return array[e] == element ? e : -1;
            }
            var border = s + (e - s) / 2;
            if (array[border] == element)
            {
                return border;
            }
            if (array[border] > element)    
            {
                return BinarySearch(array, element, s, border - 1 < s ? s : border - 1);
            }
            if (array[border] < element)
            {
                return BinarySearch(array, element, border + 1 > e ? e : border + 1, e);
            }
            return 0;
        }
    }
}