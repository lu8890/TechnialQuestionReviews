using System;

namespace lu8890.TechReviews.DataStructures
{
    public class LinkedList<T>
    {
        public Node<T> Root { get; set; }
        private int NodeCount { get; set; }

        public LinkedList()
        {
            this.NodeCount = 0;
        }

        public int Length => NodeCount;

        public void AddANode(Node<T> newNode)
        {
            if (NodeCount == 0)
                Root = newNode;
            else
            {
                var traverseNode = this.Root;
                while (traverseNode.NextNode != null)
                    traverseNode = traverseNode.NextNode;
                traverseNode.NextNode = newNode;
            }

            ++this.NodeCount;
        }

        /// <summary>
        /// Root = position 1, is the beginning of the linked list
        /// </summary>
        /// <param name="nodePos">
        /// nodePos is 1 based int.  
        /// </param>
        public void RemoveNodeByPosition(int nodePos)
        {
            if((nodePos <= 0) || (nodePos > this.NodeCount))
                throw new ArgumentOutOfRangeException(nameof(nodePos));

            if (nodePos == 1)
                this.Root = this.Root.NextNode;
            else
            {
                var previousNode = this.Root;
                var currentNode = this.Root.NextNode;
                for (var i = 2; i < nodePos; i++)
                {
                    previousNode = previousNode.NextNode;
                    currentNode = currentNode.NextNode;
                }

                previousNode.NextNode = currentNode.NextNode;
            }

            --NodeCount;

        }

        public Node<T> GetRemoveNodeByPosition(int nodePos)
        {
            if ((nodePos <= 0) || (nodePos > this.NodeCount))
                throw new ArgumentOutOfRangeException(nameof(nodePos));

            var previousNode = this.Root;
            var currentNode = this.Root.NextNode;
            Node<T> removedNode = null;

            if (nodePos == 1)
            {
                removedNode = this.Root;
                this.Root = this.Root.NextNode;
                
            }
            else
            {  
                for (var i = 2; i < nodePos; i++)
                {
                    previousNode = previousNode.NextNode;
                    currentNode = currentNode.NextNode;
                }

                previousNode.NextNode = currentNode.NextNode;
                removedNode = currentNode;
            }

            --NodeCount;

            return removedNode;
        }
    }
}
