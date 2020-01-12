using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DSA.Algorithms.Week3
{
    public static class HashTableWithChaining
    {
        private const int P = 1000000007;
        private const int x = 263;
        private static int m;
        private static List<string>[] table;

        public static void Main()
        {
            // var sr = new StreamReader("test.txt");
            m = int.Parse(Console.ReadLine());
//            ConstructTable(m);
            table = new List<string>[m];

            var N = int.Parse(Console.ReadLine());

            for (var i = 0; i < N; i++)
            {
                var query = Console.ReadLine().Split(' ');
                switch (query[0])
                {       
                    case "add":
                        Add(CountHash(query[1]), query[1]);
                        break;
                    case "find":
                        Find(CountHash(query[1]), query[1]);
                        break;
                    case "del":
                        Del(CountHash(query[1]), query[1]);
                        break;
                    case "check":
                        Check(int.Parse(query[1]));
                        break;
                }
            }
        }

        private static void ConstructTable(int i)
        {
            table = new List<string>[i];
            for (int j = 0; j < i; j++)
            {
                table[j] = new List<string>();
            }
        }

        private static void Add(int hash, string input)
        {
            var currentChain = table[hash];
            if (currentChain == null)
            {
                table[hash] = new List<string> {input};
            }
            else
            {
                if (!currentChain.Contains(input))
                {
                    table[hash].Insert(0, input);
                }
            }
        }
        
        private static void Del(int hash, string input)
        {
            if (table[hash] != null)
            {
                table[hash].Remove(input);
            }
        }
        
        private static void Find(int hash, string input)
        {
            var answer = "no";
            if (table[hash] != null)
            {
                if (table[hash].Contains(input))
                {
                    answer = "yes";   
                }
            }
            Console.WriteLine(answer);
        }
        
        private static void Check(int index)
        {
            var answer = string.Empty;
            if (table[index] != null)
            {
                answer = string.Join(" ", table[index]);
            }
            Console.WriteLine(answer);
        }

        private static int CountHash(string s)
        {
            var result = default(double);
            long p_pow = 1; 
            for(var i = 0; i < s.Length; i++)
            {
                result += (s[i] * p_pow);
                p_pow = (p_pow * x) % P;
            }
            return (int)(result % P% m);
        }
    }
}