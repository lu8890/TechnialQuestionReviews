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
    }
}
