using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.LeetCode.Models
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int x)
        {
            val = x;
        }

        public TreeNode()
        {
        }
    }
}
