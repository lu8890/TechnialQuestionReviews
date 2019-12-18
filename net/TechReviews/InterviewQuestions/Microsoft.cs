using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lu8890.TechReviews.DataStructures;
using System.Collections;


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
        public bool IsACircularLinkedList(Node<int> inputLinkedList)
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

        /// <summary>
        /// Remove first occurred node with a specified node value
        /// </summary>
        /// <param name="val"></param>
        /// <param name="inputLinkedList"></param>
        public Node<int> RemoveFirstNodeByValue(int val, Node<int> inputLinkedList)
        {
            var traverseNode = inputLinkedList;

            if (inputLinkedList != null)
            {
                if (inputLinkedList.NodeValue == val)
                    return traverseNode = traverseNode.NextNode;
                else
                {
                    while (traverseNode.NextNode != null)
                    {
                        if (traverseNode.NextNode.NodeValue == val)
                        {
                            traverseNode.NextNode = traverseNode.NextNode.NextNode;
                            GC.Collect();
                            break;
                        }
                        else
                        {
                            traverseNode = traverseNode.NextNode;
                        }
                    }
                }
            }

            return inputLinkedList;
        }

        /// <summary>
        /// find first uniquie character from an input string.
        ///   rq1: case in-sensative
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public char FindFirstUniqueChar(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ' ';

            if (input.Length == 1)
                return input[0];

            var charMap = new Dictionary<char, int>();
            foreach (var charTarget in input.ToUpper().Trim())
            {
                if (!charMap.ContainsKey(charTarget))
                    charMap.Add(charTarget, 1);
                else
                {
                    ++charMap[charTarget];
                }
            }

            var outP = charMap.FirstOrDefault(x => x.Value == 1).Key;

            return (outP == 0) ? ' ' : outP;
        }

        /// <summary>
        /// Implement a function that will take an list of strings, and find anagrams among the inputs
        /// And return a list of string lists 
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public List<List<string>> FindAnagrams(string[] inputs)
        {
            if ((inputs == null) || (inputs.Length == 0))
                throw new NullReferenceException();

            var output = new Dictionary<string, List<string>>();
            foreach(var input in inputs)
            {
                var key = string.Concat(input.ToUpperInvariant().OrderBy(x => x));

                if (!output.ContainsKey(key))
                    output.Add(key.ToString(), new List<string>());

                output[key].Add(input);                    
            }

            var result = new List<List<string>>(); 
            foreach(var key in output.Keys)
            {
                result.Add(output[key]);
            }

            return result;
        }
    
    }

    /// <summary>
    /// Implement a Queue class using stack functionality
    /// </summary>
    public class Microsoft_Interview_Queue
    {
        private System.Collections.Generic.Stack<int> Queue { get; set; }
        public int Count { get { return Queue.Count(); } }

        public Microsoft_Interview_Queue()
        {
            Queue = null;
        }

        public void Enqueue(int inputValue)
        {
            if (Queue == null)
                Queue = new System.Collections.Generic.Stack<int>();

            Queue.Push(inputValue);
        }

        public int Dequeue()
        {
            if ((Queue == null) || (Queue.Count == 0))
                throw new NullReferenceException();

            if (Queue.Count == 1)
                return Queue.Pop();

            var reversedQueue = new System.Collections.Generic.Stack<int>();

            while ((Queue.Count != 0) && (Queue != null))
                reversedQueue.Push(Queue.Pop());

            var poppedValue = reversedQueue.Pop();

            while ((reversedQueue.Count != 0) && (reversedQueue != null))
                Queue.Push(reversedQueue.Pop());



            return poppedValue;
        }

    }
}
