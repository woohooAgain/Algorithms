using System;
using System.Collections.Generic;
using System.Linq;

namespace EditDistatnce
{
    class Program
    {
        static void Main()
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            Console.WriteLine(Count(a.Insert(0, " "), b.Insert(0, " ")));
        }
        private static int Count(string a, string b)
        {
            int[,] matrix = new int[a.Length, b.Length];
            for(var i = 0; i < a.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for(var i = 0; i < b.Length; i++)
            {
                matrix[0, i] = i;
            }
            var substitutionCost = 0;
            for (var j = 1; j < b.Length; j++)
            {
                for (var i = 1; i < a.Length; i++)
                {
                    if (a[i] == b[j])
                    {
                        substitutionCost = 0;
                    }
                    else
                    {
                        substitutionCost = 1;
                    }
                    var minList = new List<int>();
                    minList.Add(matrix[i - 1, j] + 1);
                    minList.Add(matrix[i, j - 1] + 1);
                    minList.Add(matrix[i - 1, j - 1] + substitutionCost);
                    minList.Sort();
                    matrix[i, j] = minList.First();
                }
            }
            return matrix[a.Length - 1, b.Length - 1];
        }
    }
}