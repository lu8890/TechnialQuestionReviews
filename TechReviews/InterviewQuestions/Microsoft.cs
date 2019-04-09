using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviews.InterviewQuestions
{
    public class Microsoft
    {
        /// <summary>
        /// Given a linked list.  Any node could created a loop / circular linked list by pointing to any previous node.
        /// Write a function to detect if input linked list has a loop.
        /// </summary>
        /// <param name="inputLinkedList"></param>
        /// <returns></returns>
        public bool IsACirtularLinkedList(Node<int> inputLinkedList)
        {
            if (inputLinkedList == null)
                return false;

            var traverseNode = inputLinkedList.NextNode;

            while ((inputLinkedList != null) && (traverseNode != null) && (traverseNode.NextNode != null))
            {
                inputLinkedList = inputLinkedList.NextNode;
                traverseNode = traverseNode.NextNode.NextNode;

                if (inputLinkedList == traverseNode)
                    return true;
            }

            return false;
        }
    }
}
