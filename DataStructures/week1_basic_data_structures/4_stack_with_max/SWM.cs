using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StackWithMaximum
{
    public static class Program
    {
        public static void Main()
        {
            var commandQuantity = int.Parse(Console.ReadLine());
            var myStack = new MyStack();
            for (var i = 0; i < commandQuantity; i++)
            {
                var commandArray = Console.ReadLine().Split(' ');
                switch (commandArray[0])
                {
                    case "push":
                        myStack.Push(int.Parse(commandArray[1]));
                        break;
                    case "pop":
                        if (!myStack.IsEmpty())
                        {
                            myStack.Pop();
                        }
                        break;
                    case "max":
                        if (!myStack.IsEmpty())
                        {
                            Console.WriteLine(myStack.Max());
                        }
                        break;
                    default:
                        throw new NotImplementedException(commandArray[0]);
                }
            }
        }

        private class MyStack
        {
            public MyStack()
            {
                AuxiliaryStack = new Stack<int>();
                MainStack = new Stack<int>();
            }

            private Stack<int> MainStack { get; set; }
            
            private Stack<int> AuxiliaryStack { get; set; }

            public bool IsEmpty()
            {
                return !MainStack.Any();
            }

            public void Push(int input)
            {
                int newMax = input;
                if (AuxiliaryStack.Any())
                {
                    var currentMax = AuxiliaryStack.Peek();
                    if (input < currentMax)
                    {
                        newMax = currentMax;
                    }
                }
                
                AuxiliaryStack.Push(newMax);
                MainStack.Push(input);
            }
            
            public void Pop()
            {
                AuxiliaryStack.Pop();
                MainStack.Pop();
            }
            
            public int Max()
            {
                return AuxiliaryStack.Peek();
            }
        }
    }
}