using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.LeetCode.Models
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
                val = inputs[median],
                left = BuildBinaryTree(inputs, startIndex, median),
                right = BuildBinaryTree(inputs, median + 1, endIndex)

            };
        }

        public void PrintTreePreOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write("{0}\t", root.val);
                Output.Append(string.Format("{0} ", root.val));
                PrintTreePreOrder(root.left);
                PrintTreePreOrder(root.right);
            }
        }

        public void PrintTreeInOrder(TreeNode root)
        {
            if (root != null)
            {
                PrintTreePreOrder(root.left);
                Console.Write("{0}\t", root.val);
                Output.Append(string.Format("{0} ", root.val));
                PrintTreePreOrder(root.right);
            }
        }

        public void PrintTreePostOrder(TreeNode root)
        {
            if (root != null)
            {
                PrintTreePreOrder(root.left);
                PrintTreePreOrder(root.right);
                Console.Write("{0}\t", root.val);
                Output.Append(string.Format("{0} ", root.val));
            }
        }
    }
}
