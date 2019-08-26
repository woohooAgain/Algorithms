using System;

namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());            
            var result = GetFibonacciLastNumber(size);
            Console.WriteLine(result);
        }

        static long CountFibonacciFast(int number)
        {
            var array = new long[number+1];            
            for(var i = 0; i <= number; i++)
            {
                if (i < 2)
                {
                    array[i] = i;
                }
                else
                {
                    array[i] = array[i-1] + array[i-2];
                }
            }
            return array[number];
        }

        static long CountFibonacciNaive(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return CountFibonacciNaive(n - 1) + CountFibonacciNaive(n - 2);            
        }

        static int GetFibonacciLastNumber(int n)
        {
            var fibonacci = CountFibonacciFast(n);
            return (int)(fibonacci % 10);
        }
    }
}