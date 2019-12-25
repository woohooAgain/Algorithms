using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Algorithms.Week2
{
    public static class MergingTables
    {
        public static void Main()
        {
            var tablesAndQueries = Console.ReadLine()?.Split(' ').Select(long.Parse).ToList();
            var tablesQuantity = threadAndJobs.First();
            var queriesQuantity = threadAndJobs.Last();
            var jobsDuration = Console.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
            Simulate(threadsQuantity, jobsDuration);
        }
    }
}