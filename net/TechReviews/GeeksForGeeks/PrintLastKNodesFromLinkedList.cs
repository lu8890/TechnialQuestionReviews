using System;
using System.Text;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviews.GeeksForGeeks
{
    /*
     * https://www.geeksforgeeks.org/tag/Amazon/
     * https://www.geeksforgeeks.org/print-the-last-k-nodes-of-the-linked-list-in-reverse-order-iterative-approaches/
     * Print the last k nodes of the linked list in reverse order | Iterative Approaches
        Given a linked list containing N nodes and a positive integer K where K should be less than or equal to N. The task is to print the last K nodes of the list in reverse order.

        Examples:

        Input : list: 1->2->3->4->5, K = 2
        Output : 5 4

        Input : list: 3->10->6->9->12->2->8, K = 4
        Output : 8 2 12 9
     */
    public class PrintLastKNodesFromLinkedList
    {
        public StringBuilder OutputBuilder { get; set; }

        public void PrintLinkedListKNodesFromTheEnd(int[] inputs, int k)
        {
            if(k > inputs.Length)
                throw new ArgumentOutOfRangeException();

            var intStack = new Stack<int>(inputs);
            OutputBuilder = new StringBuilder();

            for (var i = 0; i < k; i++)
            {
                OutputBuilder.Append(intStack.Pop().NodeValue + " ");
            }
        }
    }
}
