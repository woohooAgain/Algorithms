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
            var jobsDuration = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            Simulate(threadsQuantity, jobsDuration);
        }

        private static void Simulate(long threadsQuantity, int[] jobsDuration)
        {
            //var freeThreads = new MyPriorityQueue(threadsQuantity);
            //var busyThreads = new MyPriorityQueue(threadsQuantity);
            var threads = new MyPriorityQueue(threadsQuantity);
            var jobs = new Queue<int>(jobsDuration);

            while(jobs.Any())
            {
                var newJobDuration = jobs.Dequeue();
                var activeThread = threads.GetThread();
                Console.WriteLine($"{activeThread.Index} {activeThread.ReleaseTime}");
                activeThread.ReleaseTime = newJobDuration;
                threads.SiftDown(0);
            }
        }


        //todo: one queue; priority counts as sum of index and release time;
        //todo: add logics for comparison (at first release times, if equal indexes)
        public class MyPriorityQueue
        {
            private long _size;
            private MyThread[] _heap;

            public MyPriorityQueue(long size)
            {
                _heap = new MyThread[size];
                for(var i = 0; i > size; i++)
                {
                    _heap[i] = new MyThread(i);
                }
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

                    //change comparison
                    if (_heap[parentIndex].CountPriority() > _heap[i].CountPriority())
                    {
                        SwapCounter++;
                        //StringsToPrint2.AppendLine($"{parentIndex} {i}");
                        var temp = _heap[parentIndex];
                        _heap[parentIndex] = _heap[i];
                        _heap[i] = temp;
                        i = parentIndex;
                        continue;
                    }

                    break;
                }
            }

            public void SiftDown(long i)
            {
                while (true)
                {
                    var minIndex = i;
                    var l = GetLeftChildIndex(i);
                    //change comparison
                    if (l < _heap.Length && _heap[l].CountPriority() < _heap[minIndex].CountPriority())
                    {
                        minIndex = l;
                    }

                    var r = GetRightChildIndex(i);
                    //change comparison
                    if (r < _heap.Length && _heap[r].CountPriority() < _heap[minIndex].CountPriority())
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

            public MyThread GetThread()
            {
                return _heap[0];
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


            //private bool IsHeap()
            //{
            //    var elementsQuantity = _heap.Length;
            //    for (var i = 0; i < elementsQuantity; i++)
            //    {
            //        var l = 2 * i + 1;
            //        if (l <= elementsQuantity - 1)
            //        {
            //            if (_heap[i] > _heap[l])
            //            {
            //                return false;
            //            }
            //        }

            //        var r = l + 1;
            //        if (r <= elementsQuantity - 1)
            //        {
            //            if (_heap[i] > _heap[r])
            //            {
            //                return false;
            //            }
            //        }
            //    }

            //    return true;
            //}
        }

        public class MyThread
        {
            public MyThread(int index)
            {
                Index = index;
            }
            public int Index { get; set; }
            public int ReleaseTime { get; set; }

            public int CountPriority()
            {
                return Index + ReleaseTime;
            }
        }
    }
}