using System;
using System.IO;
using System.Linq;

namespace CheckBrackets
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(Count(Console.ReadLine()));

            //For tests
            // var dir = new DirectoryInfo("tests");
            // var allFiles = dir.GetFiles();
            // for(var i = 0; i < allFiles.Length; i+=2)
            // {
            //     var result = string.Empty;
            //     var answer = string.Empty;
            //     using (var sr = new StreamReader(allFiles[i].FullName))
            //     {
            //         result = Count(sr.ReadLine());
            //     }
            //     using (var sr = new StreamReader(allFiles[i+1].FullName))
            //     {
            //         answer = sr.ReadLine();
            //     }
            //     if (!result.Equals(result))
            //     {
            //         Console.WriteLine($"Test {allFiles[i]} failed");
            //     }
            // }
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
                        return (i + 1).ToString();
                    }
                    else
                    {
                        if(!AppropriateBracket(input[i], stack))
                        {
                            return (i + 1).ToString();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (input[i].Equals('{') || input[i].Equals('[') || input[i].Equals('('))
                {
                    stack.Push(input[i], i);
                }
            }
            if (!stack.IsEmpty())
            {
                return (stack.Top().Index + 1).ToString();
            }
            return "Success";
        }

        private static bool AppropriateBracket(char newBracket, MyStack stack)
        {
            switch (newBracket)
            {
                case '}':
                    return stack.Top().Bracket.Equals('{');
                case ']':
                    return stack.Top().Bracket.Equals('[');
                case ')':
                    return stack.Top().Bracket.Equals('(');
                default:
                    throw new NotSupportedException(newBracket.ToString());
            }
        }

        private class MyStack
        {
            private StackItem Last {get;set;}
            public void Push(char newChar, int index)
            {
                var newItem = new StackItem{Bracket = newChar, Index = index};
                if (Last != null)
                {
                    newItem.Previous = Last;
                }
                Last = newItem;
            }

            public StackItem Pop()
            {
                var result = Top();
                if (Last != null)
                {                    
                    Last = Last.Previous;
                }
                return result;
            }

            public StackItem Top()
            {
                return Last;
            }

            public bool IsEmpty()
            {
                return Last == null;
            }
        }

        private class StackItem
        {
            public char Bracket {get;set;}
            public int Index {get;set;}
            public StackItem Previous {get;set;}
        }
    }
}