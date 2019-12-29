using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace DSA.Algorithms.Week2
{
    public static class MergingTables
    {
        public static void Main()
        {
            using (var sr = new StreamReader(@"tests/116"))
            {
                var tablesAndQueries = sr.ReadLine()?.Split(' ').Select(long.Parse).ToList();
                var tablesQuantity = tablesAndQueries.First();
                var queriesQuantity = tablesAndQueries.Last();
                var rowsSizes = sr.ReadLine()?.Split(' ').Select(long.Parse).ToArray();
                var set = new MyDisjointSet(tablesQuantity, rowsSizes);
                var queries = new Query[queriesQuantity];
                for(var i = 0; i < queriesQuantity; i++)
                {
                    var pair = sr.ReadLine()?.Split(' ');
                    queries[i] = new Query(long.Parse(pair[1]), long.Parse(pair[0]));
                }
                Merge(set, queries);
            }            
        }

        private static void Merge(MyDisjointSet set, Query[] queries)
        {
            using (var sw = new StreamWriter(@"tests/116.a"))
            {
                foreach (var query in queries)
                {
                    set.Union(query.Destination - 1, query.Source - 1);
                    sw.WriteLine(set.GetLongestTableSize());
                }
            }            
        }
    }

    public class Table
    {
        public Table(long rowsQuantity, long arrayIndex)
        {
            Rows = rowsQuantity;
            Parent = arrayIndex;
        }
        public long Rows { get; set; }

        public long Parent { get; set; }
    }

    public class MyDisjointSet
    {
        //todo
        //add heuristics for rank and find
        //measure performance
        
        public MyDisjointSet(long capacity, long[] rowsSizes)
        {
            Array = new Table[capacity];
            LongestTableSize = long.MinValue;
            for (var i = 0; i < capacity; i++)
            {
                if (rowsSizes[i] > LongestTableSize)
                {
                    LongestTableSize = rowsSizes[i];
                }
                Array[i] = new Table(rowsSizes[i], i);
            }
        }
        Table[] Array { get; set; }

        private long LongestTableSize { get; set; }

        public void MakeSet(Table table)
        {
            throw new NotImplementedException();
        }

        public void Union(long destinationTableIndex, long sourceTableIndex)
        {
            if (destinationTableIndex != sourceTableIndex)
            {
                var destination = Find(destinationTableIndex);
                var source = Find(sourceTableIndex);
                source.Parent = destination.Parent;
                destination.Rows += source.Rows;
                source.Rows = 0;
                if (destination.Rows > LongestTableSize)
                {
                    LongestTableSize = destination.Rows;
                }
            }
        }

        public Table Find(long index)
        {
            while (true)
            {
                if (Array[index].Parent == index) return Array[index];
                index = Array[index].Parent;
            }
        }

        public long GetLongestTableSize()
        {
            return LongestTableSize;
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