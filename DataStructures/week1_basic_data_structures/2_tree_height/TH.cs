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
            var result = CountHeight(BuildTree(nodes));
            Console.WriteLine(result);
        }

        private static int CountHeight(TreeItem treeRoot)
        {
            var currentHeight = 1;
            var maxChildHeight = 0;
            foreach (var t in treeRoot.Children)
            {
                var newMax = CountHeight(t);
                if (newMax > maxChildHeight)
                {
                    maxChildHeight = newMax;
                }
            }
            return currentHeight += maxChildHeight;
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