using System;
using System.Collections.Generic;
using System.Linq;

namespace ImprovedQuickSort
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            RandomizedQuickSort(inputArray, 0, inputArray.Count - 1);
            foreach (var item in inputArray)
            {
                Console.Write($"{item} ");
            }
        }

        private static int Partition2(List<int> input, int l, int r)
        {
            var x = input[l];
            var j = l;
            for(var i = l + 1; i <= r; i++)
            {
                if (input[i] <= x)
                {
                    j++;
                    Swap(input, i,j);
                }                
            }
            Swap(input, l, j);
            return j;
        }

        private static List<int> Partition3(List<int> input, int l, int r)
        {
            var x = input[l];
            //this for elements less then x
            var j = l;
            //this for elements equal x
            var k = l;
            for(var i = l + 1; i <= r; i++)
            {
                if (input[i] < x)
                {
                    j++;
                    k++;
                    Swap(input, i, j);
                    if (k > j)
                    {
                        Swap(input, i, k);
                    }
                }
                else if (input[i] == x)
                {
                    k++;
                    Swap(input, i, k);
                }
            }
            Swap(input, l, j);
            return new List<int>{j, k};
        }

        private static void RandomizedQuickSort(List<int> input, int l, int r)
        {
            // Console.WriteLine($"l: {l}");
            // Console.WriteLine($"r: {r}");
            if (l >= r)
            {
                return;
            }
            Random random = new Random();
            var k = l + random.Next() % (r - l + 1);
            Swap(input, l, k);
            var m = Partition2(input, l, r);
            var interval = Partition3(input, l, r);
            // Console.WriteLine($"interval.First(): {interval.First()}");
            // Console.WriteLine($"interval.Last(): {interval.Last()}");
            
            RandomizedQuickSort(input, l, interval.First() - 1 > 0 ? interval.First() - 1 : interval.First());
            RandomizedQuickSort(input, interval.Last() + 1, r);
            // Console.WriteLine($"m: {m}");
            // RandomizedQuickSort(input, l, m - 1);
            // RandomizedQuickSort(input, m + 1, r);
        }

        private static void Swap(List<int> input, int a, int b)
        {
            var tmp = input[a];
            input[a] = input[b];
            input[b] = tmp;
        }
    }
}