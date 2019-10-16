using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lu8890.TechReviews.DataStructures
{
    public class Tree
    {
        public TreeNode Root { get; set; }

        public StringBuilder Output { get; set; }

        public Tree(IReadOnlyList<int> values)
        {
            Output = new StringBuilder();
            var output = values.OrderBy(x => x).ToList();

            Root = BuildBinaryTree(output, 0, values.Count());
        }

        private static TreeNode BuildBinaryTree(IReadOnlyList<int> inputs, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
                return null;

            var median = startIndex + (endIndex - startIndex) / 2;

            return new TreeNode
            {
                NodeValue = inputs[median],
                Left = BuildBinaryTree(inputs, startIndex, median),
                Right = BuildBinaryTree(inputs, median + 1, endIndex)

            };
        }

        public void PrintTreePreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write("{0}\t", root.NodeValue);
                Output.Append(string.Format("{0} ", root.NodeValue));
                PrintTreePreOrder(root.Left);
                PrintTreePreOrder(root.Right);
            }
        }

        public void PrintTreeInOrder(TreeNode root)
        {
            if (root != null)
            {
                PrintTreePreOrder(root.Left);
                Console.Write("{0}\t", root.NodeValue);
                Output.Append(string.Format("{0} ", root.NodeValue));
                PrintTreePreOrder(root.Right);
            }
        }

        public void PrintTreePostOrder(TreeNode root)
        {
            if (root != null)
            {
                PrintTreePreOrder(root.Left);
                PrintTreePreOrder(root.Right);
                Console.Write("{0}\t", root.NodeValue);
                Output.Append(string.Format("{0} ", root.NodeValue));
            }
        }
    }
}
