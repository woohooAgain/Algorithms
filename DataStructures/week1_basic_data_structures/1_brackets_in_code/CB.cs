using System;

namespace CheckBrackets
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(Count(Console.ReadLine()));
        }

        public static string Count(string input)
        {
            var stack = new MyStack();
            for(var i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('}') || input[i].Equals(']') || input[i].Equals(')'))
                {
                    if (stack.IsEmpty())
                    {
                        return i.ToString();
                    }
                    else
                    {
                        if(!input[i].Equals(stack.Last.Bracket))
                        {
                            return i.ToString();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (input[i].Equals('{') || input[i].Equals('[') || input[i].Equals('('))
                {
                    stack.Push(input[i]);
                }
            }
            if (!stack.IsEmpty())
            {
                return "11";
            }
            return "Success";
        }

        private class MyStack
        {
            public StackItem Last {get;set;}
            public void Push(char newChar)
            {
                var newItem = new StackItem{Bracket = newChar};
                if (Last != null)
                {
                    newItem.Previous = Last;
                }
                Last = newItem;
            }

            public StackItem Pop()
            {
                var result = Last;
                if (Last != null)
                {                    
                    Last = Last.Previous;
                }
                return result;
            }

            public bool IsEmpty()
            {
                return Last == null;
            }
        }

        private class StackItem
        {
            public char Bracket {get;set;}
            public StackItem Previous {get;set;}
        }
    }
}