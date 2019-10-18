using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lu8890.TechReviews.LeetCode.Models;

namespace lu8890.TechReviews.LeetCode.Problems.Easy
{
    public class TreeQ
    {
        /// <summary>
        /// https://leetcode.com/problems/same-tree/
        /// Runtime: 96 ms, faster than 58.97% of C# online submissions for Same Tree.
        /// Memory Usage: 22.3 MB, less than 35.29% of C# online submissions for Same Tree.
        ///
        /// ps: this solution is from problem solution Approach 1: Recursion / Java 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        /// <summary>
        /// https://leetcode.com/problems/symmetric-tree/
        /// Runtime: 84 ms, faster than 99.78% of C# online submissions for Symmetric Tree.
        /// Memory Usage: 24.3 MB, less than 27.27% of C# online submissions for Symmetric Tree.
        /// 
        /// ps: from java recursive solution
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root, root);
        }

        private bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if ((t1 == null) && (t2 == null))
                return true;
            if ((t1 == null) || (t2 == null))
                return false;

            return (t1.val == t2.val) && IsMirror(t1.right, t2.left) && IsMirror(t1.left, t2.right);

        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
        /// 
        /// Runtime: 96 ms, faster than 84.95% of C# online submissions for Maximum Depth of Binary Tree.
        ///  Memory Usage: 24.6 MB, less than 5.88% of C# online submissions for Maximum Depth of Binary Tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        /// <summary> 
        /// https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
        /// Runtime: 252 ms, faster than 85.03% of C# online submissions for Binary Tree Level Order Traversal II.
        /// Memory Usage: 30.1 MB, less than 50.00% of C# online submissions for Binary Tree Level Order Traversal II.
        /// </summary>
        public Dictionary<int, IList<int>> treeValueCol = new Dictionary<int, IList<int>>();


        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            RunLevelOrderBottom(root, 0);
            var reversed = treeValueCol.Reverse();
            IList<IList<int>> results = new List<IList<int>>();

            foreach (KeyValuePair<int, IList<int>> level in reversed)
            {
                results.Add(level.Value);
            }

            return results;
        }

        private void RunLevelOrderBottom(TreeNode root, int NodeLevel)
        {
            if (root != null)
            {
                if (!treeValueCol.ContainsKey(NodeLevel))
                    treeValueCol.Add(NodeLevel, new List<int>());
                treeValueCol[NodeLevel].Add(root.val);
                ++NodeLevel;

                RunLevelOrderBottom(root.left, NodeLevel);
                RunLevelOrderBottom(root.right, NodeLevel);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        /// #108
        /// Runtime: 100 ms, faster than 72.32% of C# online submissions for Convert Sorted Array to Binary Search Tree.
        /// Memory Usage: 24.6 MB, less than 25.00% of C# online submissions for Convert Sorted Array to Binary Search Tree.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return RunSortedArrayToBST(0, nums.Length - 1, nums);
        }

        private TreeNode RunSortedArrayToBST(int startIndex, int endIndex, int[] inputs)
        {
            if (startIndex > endIndex)
                return null;

            var midIndex = startIndex + (endIndex - startIndex) / 2;
            var newNode = new TreeNode(inputs[midIndex]);
            newNode.left = RunSortedArrayToBST(startIndex, midIndex - 1, inputs);
            newNode.right = RunSortedArrayToBST(midIndex + 1, endIndex, inputs);

            return newNode;
        }
    }
}
