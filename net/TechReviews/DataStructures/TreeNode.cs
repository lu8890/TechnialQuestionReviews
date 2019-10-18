using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviews.DataStructures
{
    public class TreeNode: Node<int>
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value):base(value)
        {
            base.NodeValue = value;
            this.Left = null;
            this.Right = null;
        }

        public TreeNode()
        {
        }
    }
}
