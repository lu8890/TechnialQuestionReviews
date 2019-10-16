using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lu8890.TechReviews.LeetCode.Models;

namespace lu8890.TechReviews.LeetCode.Problems.Medium
{
    public partial class MediumQuestions
    {
        /// <summary>
        /// https://leetcode.com/problems/add-two-numbers/
        /// Runtime: 128 ms, faster than 56.20% of C# online submissions for Add Two Numbers.
        /// Memory Usage: 25.5 MB, less than 50.86% of C# online submissions for Add Two Numbers.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            var carryOver = false;
            var sum = 0;
            ListNode outPutNode = null;
            ListNode traverseNode = null;

            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + (carryOver ? 1 : 0);
                carryOver = false;

                if (sum >= 10)
                {
                    carryOver = true;
                }

                if (outPutNode == null)
                {
                    outPutNode = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }
                else
                {
                    traverseNode = outPutNode;
                    while (traverseNode.next != null)
                        traverseNode = traverseNode.next;
                    traverseNode.next = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                sum = l1.val + (carryOver ? 1 : 0);
                carryOver = false;

                if (sum >= 10)
                    carryOver = true;

                if (outPutNode == null)
                {
                    outPutNode = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }
                else
                {
                    traverseNode = outPutNode;
                    while (traverseNode.next != null)
                        traverseNode = traverseNode.next;
                    traverseNode.next = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }

                l1 = l1.next;
            }

            while (l2 != null)
            {
                sum = l2.val + (carryOver ? 1 : 0);
                carryOver = false;

                if (sum >= 10)
                    carryOver = true;

                if (outPutNode == null)
                {
                    outPutNode = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }
                else
                {
                    traverseNode = outPutNode;
                    while (traverseNode.next != null)
                        traverseNode = traverseNode.next;
                    traverseNode.next = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }

                l2 = l2.next;
            }

            if (carryOver)
            {

                traverseNode = outPutNode;
                while (traverseNode.next != null)
                    traverseNode = traverseNode.next;
                traverseNode.next = new ListNode(1);
            }

            return outPutNode;
        }

        /// <summary>
        /// Runtime: 152 ms, faster than 5.31% of C# online submissions for Add Two Numbers.
        /// Memory Usage: 25.9 MB, less than 5.14% of C# online submissions for Add Two Numbers.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            var l1List = ConvertIntListNodeToArray(l1);
            var l2List = ConvertIntListNodeToArray(l2);

            var l1ListCount = 0;
            var l2ListCount = 0;
            var output = new List<int>();
            var carryOver = false;
            var sum = 0;

            while ((l1ListCount < l1List.Count) && (l2ListCount < l2List.Count))
            {
                sum = (carryOver)
                    ? l1List[l1ListCount] + l2List[l2ListCount] + 1
                    : l1List[l1ListCount] + l2List[l2ListCount];
                carryOver = false;

                if (sum >= 10)
                {
                    output.Add((sum % 10));
                    carryOver = true;
                }
                else
                {
                    output.Add(sum);
                }

                ++l1ListCount;
                ++l2ListCount;
            }

            while (l1ListCount < l1List.Count)
            {
                sum = carryOver ? l1List[l1ListCount] + 1 : l1List[l1ListCount];
                carryOver = false;

                if (sum >= 10)
                {
                    carryOver = true;
                    output.Add(sum % 10);
                }
                else
                {
                    output.Add(sum);
                }

                ++l1ListCount;
            }

            while (l2ListCount < l2List.Count)
            {
                sum = carryOver ? l2List[l2ListCount] + 1 : l2List[l2ListCount];
                carryOver = false;

                if (sum >= 10)
                {
                    carryOver = true;
                    output.Add(sum % 10);
                }
                else
                {
                    output.Add(sum);
                }

                ++l2ListCount;
            }

            if (carryOver == true)
                output.Add(1);

            ListNode result = null;
            ListNode traverse = null;
            foreach (var n in output)
            {
                if (result == null)
                    result = new ListNode(n);
                else
                {
                    traverse = result;
                    while (traverse.next != null)
                        traverse = traverse.next;
                    traverse.next = new ListNode(n);
                }
            }

            return result;
        }

        public static List<int> ConvertIntListNodeToArray(ListNode l1)
        {
            if (l1 == null)
                return new List<int>();

            var output = new List<int>();
            while (l1 != null)
            {
                output.Add(l1.val);
                l1 = l1.next;
            }

            return output;
        }

        /// <summary>
        /// Runtime: 128 ms, faster than 56.20% of C# online submissions for Add Two Numbers.
        /// Memory Usage: 25.9 MB, less than 5.14% of C# online submissions for Add Two Numbers.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers3(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            var carryOver = false;
            var sum = 0;
            ListNode outPutNode = null;
            ListNode traverseNode = null;

            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + (carryOver ? 1 : 0);
                carryOver = false;

                if (sum >= 10)
                {
                    carryOver = true;
                }

                if (outPutNode == null)
                {
                    outPutNode = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }
                else
                {
                    traverseNode = outPutNode;
                    while (traverseNode.next != null)
                        traverseNode = traverseNode.next;
                    traverseNode.next = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null || l2 != null)
            {
                sum = ((l1 == null)
                    ? l2.val
                    : l1.val)
                      + (carryOver ? 1 : 0);
                carryOver = false;

                if (sum >= 10)
                    carryOver = true;

                if (outPutNode == null)
                {
                    outPutNode = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }
                else
                {
                    traverseNode = outPutNode;
                    while (traverseNode.next != null)
                        traverseNode = traverseNode.next;
                    traverseNode.next = carryOver
                        ? new ListNode(sum % 10)
                        : new ListNode(sum);
                }

                if (l1 == null)
                    l2 = l2.next;
                else
                {
                    l1 = l1.next;
                }
            }


            if (carryOver)
            {
                traverseNode = outPutNode;
                while (traverseNode.next != null)
                    traverseNode = traverseNode.next;
                traverseNode.next = new ListNode(1);
            }

            return outPutNode;
        }
    }
}
