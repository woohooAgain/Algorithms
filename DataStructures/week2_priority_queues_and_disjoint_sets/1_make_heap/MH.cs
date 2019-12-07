using System;
using System.Collections.Generic;
using System.Linq;

namespace Heap
{
    public static class Program
    {
        private static List<string> StringsToPrint { get; set; }
        private static int SwapCounter { get; set; }
        public static void Main()
        {
            var inputArrayLength = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            var array = Console .ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            CreateHeap(array);
        }

        private static void CreateHeap(int[] array)
        {
            var elementsQuantity = array.Length;
            var startIndex = elementsQuantity / 2;
            SwapCounter = 0;
            StringsToPrint = new List<string>();
            for (var i = startIndex; i < elementsQuantity; i++)
            {
                SiftUp(array, i);
            }
            Console.WriteLine(SwapCounter);
            foreach (var s in StringsToPrint)
            {
                Console.WriteLine(s);
            }
        }

        private static void SiftUp(int[] array, int i)
        {
            while (true)
            {
                var parentIndex = GetParent(i);
                if (parentIndex < 0)
                {
                    return;
                }

                if (array[parentIndex] > array[i])
                {
                    SwapCounter++;
                    StringsToPrint.Add($"{parentIndex} {i}");
                    var temp = array[parentIndex];
                    array[parentIndex] = array[i];
                    array[i] = temp;
                    i = parentIndex;
                    continue;
                }

                break;
            }
        }

        private static int GetParent(int i)
        {
            if (i != 0)
            {
                return (i - 1) / 2;
            }

            return -1;
        }


        private static bool IsHeap(int[] array)
        {
            var elementsQuantity = array.Length;
            for (var i = 0; i < elementsQuantity; i++)
            {
                var l = 2 * i + 1;
                if (l <= elementsQuantity - 1)
                {
                    if (array[i] > array[l])
                    {
                        return false;
                    }
                }
                var r = l + 1;
                if (r <= elementsQuantity - 1)
                {
                    if (array[i] > array[r])
                    {
                        return false;
                    }                    
                }
            }

            return true;
        }
    }
}