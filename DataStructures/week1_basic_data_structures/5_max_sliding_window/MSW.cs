using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkSimulation
{
    public static class Program
    {
        public static void Main()
        {
            var inputArrayLength = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            var numbers = Console .ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            var windowSize = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            SlideWindow(inputArrayLength, numbers, windowSize);
        }

        private static void SlideWindow(int inputArrayLength, int[] numbers, int windowSize)
        {
            var sb = new StringBuilder(250000);
            var queue = new MyQueue(windowSize);
            for(var i = 0; i < windowSize; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            sb.Append(queue.Max());
            sb.Append(' ');
            for(var i = windowSize; i < inputArrayLength; i++)
            {
                queue.Dequeue();
                queue.Enqueue(numbers[i]);
                sb.Append(queue.Max());
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }

        private class MyQueue
        {
            private readonly MyStack _firstStack;
            private readonly MyStack _secondStack;

            public MyQueue(int size)
            {
                _firstStack = new MyStack(size);
                _secondStack = new MyStack(size);
            }

            public void Enqueue(int newValue)
            {
                _firstStack.Push(newValue);
            }

            public int Dequeue()
            {
                if (!_secondStack.IsEmpty()) return _secondStack.Pop();
                while(!_firstStack.IsEmpty())
                {
                    _secondStack.Push(_firstStack.Pop());
                }

                return _secondStack.Pop();
            }

            public int Max()
            {
                var firstMax = _firstStack.Max();
                var secondMax = _secondStack.Max();
                return firstMax > secondMax ?  firstMax : secondMax;
            }
        }

        private class MyStack
        {
            private readonly Stack<int> _originalStack;
            private readonly Stack<int> _maxElementStack;

            public MyStack(int size)
            {
                _originalStack = new Stack<int>(size);
                _maxElementStack = new Stack<int>(size);
            }

            public void Push(int newValue)
            {
                if (!_maxElementStack.Any())
                {
                    _maxElementStack.Push(newValue);
                }
                else
                {
                    var currentMax = _maxElementStack.Peek();
                    _maxElementStack.Push(currentMax > newValue ? currentMax : newValue);
                }
                _originalStack.Push(newValue);
            }

            public int Pop()
            {
                _maxElementStack.Pop();
                return _originalStack.Pop();
            }

            public int Max()
            {
                return _maxElementStack.Any() ? _maxElementStack.Peek() : 0;
            }

            public bool IsEmpty()
            {
                return !_originalStack.Any();
            }
        }
    }
}