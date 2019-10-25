using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeHeight
{
    public static class Program
    {
        public static void Main()
        {
            var nodeNumber = Console.ReadLine();
            var nodes = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            var result = Count2(BuildTree(nodes));
            Console.WriteLine(result);

            //For tests
            // var dir = new DirectoryInfo("tests");
            // var allFiles = dir.GetFiles();
            // for(var i = 0; i < allFiles.Length; i+=2)
            // {
            //     var result = string.Empty;
            //     var answer = string.Empty;
            //     using (var sr = new StreamReader(allFiles[i].FullName))
            //     {
            //         var nodeNumber = sr.ReadLine();
            //         var nodes = sr.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            //         var root = BuildTree(nodes);
            //         Stopwatch stopWatch = new Stopwatch();
            //         stopWatch.Start();
            //         result = Count2(root).ToString();
            //         stopWatch.Stop();
            //         Console.WriteLine($"stopWatch.Elapsed: {stopWatch.Elapsed}");
            //     }
            //     using (var sr = new StreamReader(allFiles[i+1].FullName))
            //     {
            //         answer = sr.ReadLine();
            //     }
            //     if (!result.Equals(result))
            //     {
            //         Console.WriteLine($"Test {allFiles[i]} failed");
            //     }
            //     else
            //     {
            //         Console.WriteLine($"Test {allFiles[i]} succeeded");
            //     }
            // }
        }

        private static int Count2(TreeItem treeRoot)
        {
            var height = 0;
            var queue = new Queue<TreeItem>();
            queue.Enqueue(treeRoot);
            while(true)
            {
                var currentLevelNodes = queue.Count;
                if (currentLevelNodes == 0)
                {
                    return height;
                }
                height++;
                while(currentLevelNodes > 0)
                {
                    var item = queue.Dequeue();
                    foreach(var child in item.Children)
                    {
                        queue.Enqueue(child);
                    }
                    currentLevelNodes--;
                }
            }                        
        }

        private static TreeItem BuildTree(int[] nodes)
        {
            var preRoot = new TreeItem {Children = new List<TreeItem>()};
            var controlDictionary = new Dictionary<int, TreeItem> {{-1, preRoot}};
            for (int i = 0; i < nodes.Length; i++)
            {
                TreeItem currentNode = default(TreeItem);
                if (!controlDictionary.TryGetValue(i, out currentNode))
                {
                    currentNode = new TreeItem
                    {
                        Children = new List<TreeItem>()
                    };
                    controlDictionary.Add(i, currentNode);
                }
                var parent = nodes[i];
                var parentObject = default(TreeItem);
                if (!controlDictionary.TryGetValue(parent, out parentObject))
                {
                    parentObject = new TreeItem{Children = new List<TreeItem>()};
                    controlDictionary.Add(parent, parentObject);
                }

                parentObject.Children.Add(currentNode);
            }
            return preRoot.Children.Single();
        }

        private class TreeItem
        {
            public List<TreeItem> Children { get; set; }
        }
    }
}