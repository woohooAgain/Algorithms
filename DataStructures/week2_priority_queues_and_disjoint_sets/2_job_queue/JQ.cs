using System;
using System.Collections.Generic;
using System.Linq;

namespace Heap
{
    public static class Program
    {
        public static void Main()
        {
            var threadAndJobs = Console.ReadLine()?.Split(' ').Select(long.Parse).ToList();
            var threadsQuantity = threadAndJobs.First();
            var jobsQuantity = threadAndJobs.Last();
            var jobsDuration = Console.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
            Simulate(threadsQuantity, jobsDuration);
        }

        private static void Simulate(long threadsQuantity, long[] jobsDuration)
        {
            var threads = new MyPriorityQueue(threadsQuantity);
            var jobs = new Queue<long>(jobsDuration);
            while (jobs.Any())
            {
                var newJobDuration = jobs.Dequeue();
                var activeThread = threads.GetThread();
                Console.WriteLine($"{activeThread.Index} {activeThread.ReleaseTime}");
                activeThread.ReleaseTime += newJobDuration;
                threads.SiftDown(0);
            }
        }

        public class MyPriorityQueue
        {
            private long _size;
            private MyThread[] _heap;

            public MyPriorityQueue(long size)
            {
                _heap = new MyThread[size];
                for (var i = 0; i < size; i++)
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

                    if (_heap[parentIndex] > _heap[i])
                    {
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
        }

        public class MyThread
        {
            public MyThread(long index)
            {
                Index = index;
            }

            public long Index { get; set; }
            public long ReleaseTime { get; set; }

            public static bool operator <(MyThread mt1, MyThread mt2)
            {
                if (mt1.ReleaseTime == mt2.ReleaseTime)
                {
                    return mt1.Index < mt2.Index;
                }

                return mt1.ReleaseTime < mt2.ReleaseTime;
            }

            public static bool operator >(MyThread mt1, MyThread mt2)
            {
                if (mt1.ReleaseTime == mt2.ReleaseTime)
                {
                    return mt1.Index > mt2.Index;
                }

                return mt1.ReleaseTime > mt2.ReleaseTime;
            }
        }
    }
}