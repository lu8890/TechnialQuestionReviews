namespace lu8890.TechReviews.DataStructures
{
    public class Stack<T>: LinkedList<T>
    {
        public Stack()
        {

        }



        public Stack(T[] inputs)
        {
            foreach (var input in inputs)
            {
                Push(new Node<T>(input));
            }
        }
        public void Push(Node<T> newNode)
        {
            base.AddANode(newNode);
        }

        public Node<T> Pop()
        {
            return base.GetRemoveNodeByPosition(base.Length);
        }
    }
}
