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
            var threadAndJobs = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var threadsQuantity = threadAndJobs.First();
            var jobsQuantity = threadAndJobs.Last();
            var jobsDuration = Console.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
            Simulate(threadsQuantity, jobsDuration);
        }

        private static void Simulate(long threadsQuantity, long[] jobsDuration)
        {
            var freeThreads = new MyPriorityQueue(threadsQuantity);
            var busyThreads = new MyPriorityQueue(threadsQuantity);
            var jobs = new Queue<long>(jobsDuration);
        }


        //todo: Add model for thread (index and time, when thread will be free (will finish current work))
        //todo: Add insert and extractMax methods
        //todo: In while loop (while there are jobs) if there free threads give them job (move from free queue to busy queue), check if any threads have finished there work
        //todo: don't forget about zero-time jobs and several threads released at the same time
        public class MyPriorityQueue
        {
            private long _size;
            private long[] _heap;

            public MyPriorityQueue(long size)
            {
                _heap = new long[size];
            }

            public void Insert()
            {
                throw new NotImplementedException();
            }

            private void SiftUp(long i)
            {
                while (true)
                {
                    var parentIndex = GetParentIndex(i);
                    if (parentIndex < 0)
                    {
                        return;
                    }

                    if (_heap[parentIndex] > _heap[i])
                    {
                        SwapCounter++;
                        StringsToPrint2.AppendLine($"{parentIndex} {i}");
                        var temp = _heap[parentIndex];
                        _heap[parentIndex] = _heap[i];
                        _heap[i] = temp;
                        i = parentIndex;
                        continue;
                    }

                    break;
                }
            }

            private void SiftDown(long i)
            {
                while (true)
                {
                    var minIndex = i;
                    var l = GetLeftChildIndex(i);
                    if (l < _heap.Length && _heap[l] < _heap[minIndex])
                    {
                        minIndex = l;
                    }

                    var r = GetRightChildIndex(i);
                    if (r < _heap.Length && _heap[r] < _heap[minIndex])
                    {
                        minIndex = r;
                    }

                    if (minIndex != i)
                    {
                        SwapCounter++;
                        StringsToPrint2.AppendLine($"{minIndex} {i}");
                        var temp = _heap[minIndex];
                        _heap[minIndex] = _heap[i];
                        _heap[i] = temp;
                        i = minIndex;
                        continue;
                    }

                    break;
                }
            }

            private long GetLeftChildIndex(long i)
            {
                return 2 * i + 1;
            }

            private long GetRightChildIndex(long i)
            {
                return 2 * i + 2;
            }

            private long GetParentIndex(long i)
            {
                if (i != 0)
                {
                    return (i - 1) / 2;
                }

                return -1;
            }


            private bool IsHeap()
            {
                var elementsQuantity = _heap.Length;
                for (var i = 0; i < elementsQuantity; i++)
                {
                    var l = 2 * i + 1;
                    if (l <= elementsQuantity - 1)
                    {
                        if (_heap[i] > _heap[l])
                        {
                            return false;
                        }
                    }

                    var r = l + 1;
                    if (r <= elementsQuantity - 1)
                    {
                        if (_heap[i] > _heap[r])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}