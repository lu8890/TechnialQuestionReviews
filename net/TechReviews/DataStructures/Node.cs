using System.Text;

namespace lu8890.TechReviews.DataStructures
{
    public class Node<T>
    {
        public T NodeValue { get; set; }
        public Node<T> NextNode { get; set; }

        public Node(T value)
        {
            this.NodeValue = value;
            this.NextNode = null;
        }

        public Node()
        {
        }

        public string Print(Node<T> headNode)
        {
            var nodeValueBuilder = new StringBuilder();
            while (headNode != null)
            {
                nodeValueBuilder.Append(headNode.NodeValue + " ");
                headNode = headNode.NextNode;
            }

            return nodeValueBuilder.ToString().Trim();
        }
    }
}
