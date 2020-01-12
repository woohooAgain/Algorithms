using System;
using System.Collections.Generic;
using System.IO;

namespace DSA.Algorithms.Week3
{
    public static class PhoneBook
    {
        private const int PhoneBookSize = 10000000;
        private static readonly string[] Phones = new string[PhoneBookSize];

        public static void Main()
        {
            var queryNumber = int.Parse(Console.ReadLine());

            for (var i = 0; i < queryNumber; i++)
            {
                var query = Console.ReadLine().Split(' ');
                switch (query[0])
                {       
                    case "add":
                        Add(int.Parse(query[1]), query[2]);
                        break;
                    case "find":
                        Find(int.Parse(query[1]));
                        break;
                    case "del":
                        Del(int.Parse(query[1]));
                        break;
                }
            }
        }

        private static void Add(int phone, string name)
        {
            Phones[phone] = name;
        }
        
        private static void Del(int phone)
        {
            Phones[phone] = string.Empty;
        }
        
        private static void Find(int phone)
        {
            var name = Phones[phone];
            Console.WriteLine(string.IsNullOrEmpty(name) ? "not found" : name);
        }
    }
}