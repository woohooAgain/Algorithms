using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumValueOfExpression
{
    class Program
    {
        static void Main()
        {
            var commonInput = Console.ReadLine();
            Console.WriteLine(Count(commonInput));
        }
        private static long Count(string input)
        {            
            var length = input.Length / 2 + 1;
            var digits = new List<long>(length);
            var operators = new List<char>(input.Length / 2 );
            for(var i = 0; i < input.Length; i++)
            {
                if(i % 2 == 0)
                {
                    digits.Add(long.Parse(input[i].ToString()));
                }
                else
                {
                    operators.Add(input[i]);
                }
            }
            long[,] minMatrix  = new long[length, length];
            long[,] maxMatrix  = new long[length, length];            
            for(var i = 0; i < length; i++)
            {
                minMatrix[i,i] = digits[i];
                maxMatrix[i,i] = digits[i];
            }
            for (var s = 1; s < length; s++)
            {
                for (var i = 0; i < length - s; i++)
                {
                    var j = i + s;
                    var minMax = MinAndMax(i, j, minMatrix, maxMatrix, operators);
                    minMatrix[i, j] = minMax.First();
                    maxMatrix[i, j] = minMax.Last();
                }
            }
            return maxMatrix[0, length-1];
        }

        private static List<long> MinAndMax(int i, int j, long[,] min, long[,] max, List<char> operators)
        {
            var result = new List<long>();
            var minV = long.MaxValue;
            var maxV = long.MinValue;
            for(var k = i; k < j; k++)
            {
                var a = CountOperation(operators[k], max[i,k], max[k+1, j]);
                if (a > maxV)
                {
                    maxV = a;
                }
                if(a < minV)
                {
                    minV = a;
                }
                var b = CountOperation(operators[k], max[i,k], min[k+1, j]);
                if (b > maxV)
                {
                    maxV = b;
                }
                if(b < minV)
                {
                    minV = b;
                }
                var c = CountOperation(operators[k], min[i,k], max[k+1, j]);
                if (c > maxV)
                {
                    maxV = c;
                }
                if(c < minV)
                {
                    minV = c;
                }
                var d = CountOperation(operators[k], min[i,k], min[k+1, j]);
                if (d > maxV)
                {
                    maxV = d;
                }
                if(d < minV)
                {
                    minV = d;
                }
            }
            return new List<long>{minV, maxV};
        }

        private static long CountOperation(char op, long a, long b)
        {
            switch(op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                default:
                    throw new NotImplementedException(op.ToString());
            }
        }
    }
}