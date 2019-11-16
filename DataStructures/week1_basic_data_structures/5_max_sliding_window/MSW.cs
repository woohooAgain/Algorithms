using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetworkSimulation
{
    public static class Program
    {
        public static void Main()
        {
            var inputArrayLength = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var windowSize = int.Parse(Console.ReadLine());
            SlideWindow(inputArrayLength, numbers, windowSize);
        }

        private static void SlideWindow(int inputArrayLength, int[] numbers, int windowSize)
        {
            // var mainStack = new MyStack(windowSize);
            // var tempStack = new Stack<int>(windowSize + 1);
            // for(var i = 0; i < windowSize; i++)
            // {
            //     mainStack.Push(numbers[i]);
            // }
            // mainStack.Max();
            // for(var i = windowSize; i < inputArrayLength; i++)
            // {
            //     tempStack.Push(numbers[i]);
            //     while(!mainStack.IsEmpty())
            //     {
            //         tempStack.Push(mainStack.Pop());
            //     }
            //     tempStack.Pop();
            //     while(tempStack.Any())
            //     {
            //         mainStack.Push(tempStack.Pop());
            //     }
            //     mainStack.Max();
            // }
            var queue = new MyQueue(windowSize);
            for(var i = 0; i < windowSize; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            queue.Max();
            for(var i = windowSize; i < inputArrayLength; i++)
            {
                queue.Enqueue(numbers[i]);
                queue.Max();
            }
        }

        internal class MyQueue
        {
            private MyStack FirstStack;
            private MyStack SecondStack;

            public MyQueue(int size)
            {
                FirstStack = new MyStack(size + 1);
                SecondStack = new MyStack(size + 1);
            }

            public void Enqueue(int newValue)
            {
                SecondStack.Push(newValue);
                while(!FirstStack.IsEmpty())
                {
                    SecondStack.Push(FirstStack.Pop());
                }
                SecondStack.Pop();
                MyStack tempStack;
                tempStack = FirstStack;
                FirstStack = SecondStack;
                SecondStack = tempStack;
                tempStack = null;
            }

            public void Max()
            {
                FirstStack.Max();
            }
        }

        internal class MyStack
        {
            private Stack<int> OriginalStack;
            private Stack<int> MaxElementStack;

            public MyStack()
            {
                OriginalStack = new Stack<int>();
                MaxElementStack = new Stack<int>();
            }

            public MyStack(int size)
            {
                OriginalStack = new Stack<int>(size);
                MaxElementStack = new Stack<int>(size);
            }

            public void Push(int newValue)
            {
                if (!MaxElementStack.Any())
                {
                    MaxElementStack.Push(newValue);
                }
                else
                {
                    var currentMax = MaxElementStack.Peek();
                    MaxElementStack.Push(currentMax > newValue ? currentMax : newValue);
                }
                OriginalStack.Push(newValue);
            }

            public int Pop()
            {
                MaxElementStack.Pop();
                return OriginalStack.Pop();
            }

            public void Max()
            {
                Console.WriteLine(MaxElementStack.Peek());
            }

            public bool IsEmpty()
            {
                return !OriginalStack.Any();
            }
        }
    }
}