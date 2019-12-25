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
            var tablesQuantity = tablesAndQueries.First();
            var queriesQuantity = tablesAndQueries.Last();
            var rowsSizes = Console.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
            var set = new MyDisjointSet(tablesQuantity);
            foreach(var size in rowsSizes)
            {
                set.MakeSet(new Table(size));
            }
            var queries = new Query[queriesQuantity];
            for(var i = 0; i < queriesQuantity; i++)
            {
                var pair = Console.ReadLine()?.Split(' ');
                queries[i] = new Query(long.Parse(pair[1]), long.Parse(pair[0]));
            }
            Merge(set, queries);
        }

        private static void Merge(MyDisjointSet set, Query[] queries)
        {
            throw new NotImplementedException();
        }
    }

    public class Table
    {
        public Table(long rowsQuantity)
        {
            Rows = rowsQuantity;
        }
        public long Rows { get; set; }

        public Table Parent { get; set; }
    }

    public class MyDisjointSet
    {
        public MyDisjointSet(long capacity)
        {
            Array = new Table[capacity];
        }
        Table[] Array { get; set; }

        public void MakeSet(Table table)
        {
            throw new NotImplementedException();
        }

        public void Union(Table tableA, Table tableB)
        {
            throw new NotImplementedException();
        }

        public Table Find(Table table)
        {
            throw new NotImplementedException();
        }
    }

    public class Query
    {
        public Query(long source, long destination)
        {
            Source = source;
            Destination = destination;
        }
        public long Source { get; set; }
        public long Destination { get; set; }
    }
}