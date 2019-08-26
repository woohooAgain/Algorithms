using System;

namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var tokens = input.Split(' ');
            //var result1 = GCDNaive(a, b);
            var result2 = GCDFast(long.Parse(tokens[0]), long.Parse(tokens[1]));
            //Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        static long GCDNaive(long a, long b)
        {
            int current_gcd = 1;
            for (int d = 2; d <= a && d <= b; d++)
            {
                if (a % d == 0 && b % d == 0)
                {
                    if (d > current_gcd)
                    {
                        current_gcd = d;
                    }
                }
            }
            return current_gcd;
        }

        static long GCDFast(long a, long b)
        {
            var aa = a % b;
            if (aa != 0)
            {
                return GCDFast(b, aa);
            }
            else
            {
                return b;
            }
        }
    }
}