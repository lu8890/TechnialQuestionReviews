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
    }
}
