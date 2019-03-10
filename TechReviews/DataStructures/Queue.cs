namespace lu8890.TechReviews.DataStructures
{
    public class Queue<T>: LinkedList<T>
    {
        public Queue()
        {
        }

        public void EnQueue(Node<T> newNode)
        {
            base.AddANode(newNode);
        }

        /// <summary>
        /// FIFO: Always remove the first node in the queue
        /// </summary>
        public void DeQueue()
        {
            base.RemoveNodeByPosition(1);
        }
    }
}
