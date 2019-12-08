using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Heap
{
    public static class Program
    {
        private static List<string> StringsToPrint { get; set; }
        private static StringBuilder StringsToPrint2 { get; set; }
        private static long SwapCounter { get; set; }

        public static void Main()
        {
            var inputArrayLength = long.Parse(Console.ReadLine());
            var array = Console.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
            CreateHeap(array);
        }

        private static void CreateHeap(long[] array)
        {
            var elementsQuantity = array.Length;
            var startIndex = elementsQuantity / 2;
            SwapCounter = 0;
            StringsToPrint = new List<string>();
            StringsToPrint2 = new StringBuilder(elementsQuantity);
            for (var i = startIndex - 1; i >= 0; i--)
            {
                SiftDown(array, i);
            }

            Console.WriteLine(SwapCounter);
            Console.Write(StringsToPrint2.ToString());
        }

        private static void SiftUp(long[] array, long i)
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
                    StringsToPrint2.AppendLine($"{parentIndex} {i}");
                    var temp = array[parentIndex];
                    array[parentIndex] = array[i];
                    array[i] = temp;
                    i = parentIndex;
                    continue;
                }

                break;
            }
        }

        private static void SiftDown(long[] array, long i)
        {
            while (true)
            {
                var minIndex = i;
                var l = GetLeftChildIndex(i);
                if (l < array.Length && array[l] < array[minIndex])
                {
                    minIndex = l;
                }

                var r = GetRightChildIndex(i);
                if (r < array.Length && array[r] < array[minIndex])
                {
                    minIndex = r;
                }

                if (minIndex != i)
                {
                    SwapCounter++;
                    StringsToPrint2.AppendLine($"{minIndex} {i}");
                    var temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                    i = minIndex;
                    continue;
                }

                break;
            }
        }

        private static long GetLeftChildIndex(long i)
        {
            return 2 * i + 1;
        }

        private static long GetRightChildIndex(long i)
        {
            return 2 * i + 2;
        }

        private static long GetParent(long i)
        {
            if (i != 0)
            {
                return (i - 1) / 2;
            }

            return -1;
        }


        private static bool IsHeap(long[] array)
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