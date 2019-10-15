using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAmountOfGold
{
    class Program
    {
        static void Main()
        {
            var commonInput = Console.ReadLine().Split(' ');
            var capacity = int.Parse(commonInput[0]);
            var number = int.Parse(commonInput[1]);
            var weightsStrings = Console.ReadLine().Split(' ');
            var weights = weightsStrings.Select(w => int.Parse(w)).ToArray();
            Console.WriteLine(Count(capacity, weights));
        }
        private static int Count(int capacity, int[] weights)
        {            
            int[,] result = new int[weights.Length + 1, capacity + 1];
            for(var i = 0; i <= capacity; i++)
            {
                result[0, i] = 0;
            }
            for(var i = 0; i <= weights.Length; i++)
            {
                result[i, 0] = 0;
            }
            for (int i = 1; i <= weights.Length; i++)
            {
                for(int j = 1; j <= capacity; j++)
                {
                    var withoutCurrentRow = result[i - 1, j];
                    var currentResult = withoutCurrentRow;
                    var withCurrentRow = 0;
                    if (j >= weights[i-1])
                    {
                        withCurrentRow = result[i-1, j - weights[i-1]] + weights[i-1];
                    }
                    if (withCurrentRow > currentResult)
                    {
                        currentResult = withCurrentRow;
                    }
                    result[i, j] = currentResult;
                }
            }
            return result[weights.Length, capacity];
        }
    }
}