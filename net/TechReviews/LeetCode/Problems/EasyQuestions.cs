using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lu8890.TechReviews.LeetCode.Problems
{
    public partial class EasyQuestions
    {

        /// <summary>
        ///     https://leetcode.com/problems/two-sum/submissions/
        ///     Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        ///     You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///     Example:
        ///         Given nums = [2, 7, 11, 15], target = 9,
        ///         Because nums[0] + nums[1] = 2 + 7 = 9,
        ///         return [0, 1].
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length < 2)
                return null;
            var secondNumPos = -1;
            IEnumerable<int> tempArray = nums;
            //int skipCount = 0;
            
            for (var i = 0; i < nums.Length - 1; i++)
            {
                tempArray = tempArray.Skip(1);
                //++skipCount;

                if (tempArray.Contains(target - nums[i]))
                {         
                    secondNumPos = Array.IndexOf(tempArray.ToArray(), target - nums[i]);
                    if (secondNumPos != -1)
                        return new int[] {i, secondNumPos + i + 1};
                }
            }

            return null;
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-integer/submissions/
        /// Runtime: 44 ms, faster than 90.35% of C# online submissions for Reverse Integer.
        /// Memory Usage: 13.5 MB, less than 11.31% of C# online submissions for Reverse Integer.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            var isNegative = (x < 0) ? true : false;
            var input = x.ToString().ToCharArray();
            if ((input.Length == 0) || (input.Length == 1) || (isNegative && input.Length == 2))
                return x;

            var inputValue = x;
            while ((inputValue % 10) == 0)
                inputValue = inputValue / 10;

            input = inputValue.ToString().ToCharArray();

            var startIndex = isNegative ? 1 : 0; 
            var endIndex = input.Length - 1;
            var result = new char[input.Length];
            while (startIndex <= endIndex)
            {
                if (!isNegative)
                {
                    result[startIndex] = input[endIndex];
                    result[endIndex] = input[startIndex];
                }
                else
                {
                    result[startIndex - 1] = input[endIndex];
                    result[endIndex -1] = input[startIndex];
                }
               
                ++startIndex;
                --endIndex;
            }

            var returnValue = isNegative
                ? "-" + string.Join("", result)
                : string.Join("", result);

            try
            {
                return Convert.ToInt32(returnValue.Trim());
            }
            catch (OverflowException)
            {
                return 0;
            }          
        }

        /// <summary>
        /// https://leetcode.com/problems/palindrome-number/submissions/
        /// Runtime: 88 ms, faster than 91.79% of C# online submissions for Palindrome Number.
        /// Memory Usage: 16.9 MB, less than 12.83% of C# online submissions for Palindrome Number
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            var input = x.ToString().ToCharArray();
            if (input.Length == 0)
                return false;
            if (input.Length == 1)
                return true;

            var startIndex = 0;
            var endIndex = input.Length - 1;

            while (startIndex <= endIndex)
            {
                if (input[startIndex] != input[endIndex])
                    return false;

                ++startIndex;
                --endIndex;
            }

            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/roman-to-integer/
        /// Runtime: 96 ms, faster than 96.30% of C# online submissions for Roman to Integer.
        /// Memory Usage: 23.6 MB, less than 30.43% of C# online submissions for Roman to Integer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            var input = s.ToUpper().ToCharArray();
            var sum = 0;
            var romanValuesCol = GetRomanValue();

            if (input.Length == 1)
            {
                if (romanValuesCol.ContainsKey(input[0]))
                    return romanValuesCol[input[0]];
                else
                    return -1;
            }

            for (var i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    if (romanValuesCol.ContainsKey(input[0]))
                        sum = romanValuesCol[input[0]];
                    else
                        return -1;
                }
                else
                {
                    if (romanValuesCol.ContainsKey(input[i]))
                    {
                        if (romanValuesCol[input[i-1]] >= romanValuesCol[input[i]])
                            sum += romanValuesCol[input[i]];
                        else
                            sum += (romanValuesCol[input[i]] - romanValuesCol[input[i - 1]]) - romanValuesCol[input[i - 1]];
                    }
                    else
                        return -1;
                }
            }

            return sum;
        }

        private static Dictionary<char, int> GetRomanValue()
        {
            var romanValueKeyMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            return romanValueKeyMap;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-common-prefix/
        /// Runtime: 104 ms, faster than 92.48% of C# online submissions for Longest Common Prefix.
        /// Memory Usage: 22.8 MB, less than 39.84% of C# online submissions for Longest Common Prefix.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            var output = new StringBuilder();
            if (strs.Length < 2)
                return string.Join("", strs);

            var matching = true;
            var orderedInputs = strs.Select(x => x.ToLower()).OrderBy(x => x.Length).ToArray();

            for (var j = 0; j < orderedInputs[0].Length; j++)
            {
                for (var i = 1; i < orderedInputs.Count(); i++)
                {
                    if (!orderedInputs[0][j].Equals(orderedInputs[i][j]))
                    {
                        matching = false;
                        break;
                    }
                }

                if (matching)
                    output.Append(orderedInputs[0][j]);
                else
                    break;
            }

            return output.ToString();
        }


        private static readonly Dictionary<char, char> ValidParenCol = BuildValidCharCol();

        /// <summary>
        /// https://leetcode.com/problems/valid-parentheses/
        /// Runtime: 92 ms, faster than 37.03% of C# online submissions for Valid Parentheses.
        /// Memory Usage: 20.7 MB, less than 5.38% of C# online submissions for Valid Parentheses.
        ///
        /// round 2:
        /// Runtime: 76 ms, faster than 91.55% of C# online submissions for Valid Parentheses.
        /// Memory Usage: 20.5 MB, less than 6.45% of C# online submissions for Valid Parentheses.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if ((s.Length % 2) != 0)
                return false;
            if (string.IsNullOrWhiteSpace(s))
                return true;

            var charArray = s.ToCharArray();
            var validInputs = charArray.Select(x => ValidParenCol.Keys.Contains(x)).ToArray();
            if (validInputs.Length != charArray.Length)
                return false;


            return IsValidParan(charArray);
        }

        private bool IsValidParan(char[] charArray)
        {
            var openParent = new[] {'(', '{', '['};
            var closedParent = new[] { ')', '}', ']' };
            var trackingOpenParent = new List<char>();

            //if started with closing Parent, then we know for sure its invalid.
            if (closedParent.Contains(charArray[0]))
                return false;

            foreach (var t in charArray)
            {
                if ((trackingOpenParent.Count == 0) && (closedParent.Contains(t)))
                    return false;
                if(openParent.Contains(t))
                    trackingOpenParent.Add(t);
                else if (closedParent.Contains(t))
                {
                    var targetOpenParent = trackingOpenParent[trackingOpenParent.Count - 1];
                    if (ValidParenCol[targetOpenParent].Equals(t))
                        trackingOpenParent.RemoveAt(trackingOpenParent.Count - 1);
                    else
                    {
                        return false;
                    }
                }
            }

            if (trackingOpenParent.Count != 0)
                return false;

            return true;
        }

        private static Dictionary<char,char> BuildValidCharCol()
        {
            return new Dictionary<char, char>()
            {
                {'(', ')'},
                {')', '('},
                {'{', '}'},
                {'}', '{'},
                {'[', ']'},
                {']', '['}
            };
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// Runtime: 92 ms, faster than 100.00% of C# online submissions for Merge Two Sorted Lists.
        /// Memory Usage: 23.7 MB, less than 30.22% of C# online submissions for Merge Two Sorted Lists.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (!IsSortedList(l1) || (!IsSortedList(l2)))
                return null;

            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            ListNode mergedNode = null;
            ListNode traverseNode = null;

            while ((l1 != null) && (l2 != null))
            {
                if (l1.val <= l2.val)
                {
                    if (mergedNode == null)
                    {
                        mergedNode = new ListNode(l1.val){ next = null};
                    }
                    else
                    {
                        traverseNode = mergedNode;
                        while (traverseNode.next != null)
                        {
                            traverseNode = traverseNode.next;
                        }

                        traverseNode.next = new ListNode(l1.val) { next = null };
                    }
                    l1 = l1.next;
                }
                else
                {
                    if (mergedNode == null)
                    {
                        mergedNode = new ListNode(l2.val) { next = null };   
                    }
                    else
                    {
                        traverseNode = mergedNode;
                        while (traverseNode.next != null)
                            traverseNode = traverseNode.next;
                        traverseNode.next = new ListNode(l2.val) { next = null };
                    }
                    l2 = l2.next;
                }
            }

            while (l1 != null)
            {
                traverseNode = mergedNode;
                while (traverseNode.next != null)
                    traverseNode = traverseNode.next;
                traverseNode.next = l1;
                l1 = null;
            }

            while (l2 != null)
            {
                traverseNode = mergedNode;
                while (traverseNode.next != null)
                    traverseNode = traverseNode.next;
                traverseNode.next = l2;
                l2 = null;
            }

            return mergedNode;
        }

        private static bool IsSortedList(ListNode inputList)
        {
            if (inputList == null)
                return true;
            var min = inputList.val;
            inputList = inputList.next;

            while (inputList != null)
            {
                if (inputList.val < min)
                    return false;
                min = inputList.val;
                inputList = inputList.next;
            }

            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// Runtime: 596 ms, faster than 5.07% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.5 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        ///
        /// second submission:
        /// Runtime: 424 ms, faster than 11.42% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.6 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null)
                return 0;
            else if (nums.Length <= 2)
                return nums.Distinct().ToArray().Length;

            nums.OrderBy(x => x).ToArray();

            var currentIndex = 0;
            var endIndex = 1;
            var reachedEndOfList = false;
            var traverseIndex = 0;
            var swapInt = 0;

            while (endIndex <= nums.Length - 1)
            {
                if (nums[currentIndex] != nums[endIndex])
                {
                    if (endIndex == (currentIndex + 1))
                    {
                        currentIndex++;
                        endIndex++;
                    }
                    else
                    {
                        reachedEndOfList = ReachedEndOfList(nums.Length, endIndex);
                        while (!reachedEndOfList && (nums[endIndex + 1] == nums[endIndex]))
                        {
                            ++endIndex;
                            reachedEndOfList = ReachedEndOfList(nums.Length, endIndex);
                        }
                        traverseIndex = endIndex;
                        while (traverseIndex > currentIndex + 1)
                        {
                            swapInt = nums[traverseIndex - 1];
                            nums[traverseIndex - 1] = nums[traverseIndex];
                            nums[traverseIndex] = swapInt;
                            --traverseIndex;

                        }
                        ++currentIndex;
                        ++endIndex;
                    }

                }
                else
                {
                    //searching for the next unique number
                    ++endIndex;
                    reachedEndOfList = ReachedEndOfList(nums.Length, endIndex);

                    while (!reachedEndOfList && (nums[currentIndex] == nums[endIndex]))
                    {
                        ++endIndex;
                        reachedEndOfList = ReachedEndOfList(nums.Length, endIndex);
                    }

                    //check if the new value is unique.  If not, get the last position
                    if (!reachedEndOfList)
                    {
                        while ((!reachedEndOfList) && (nums[endIndex] == nums[endIndex + 1]))
                        {
                            ++endIndex;
                            reachedEndOfList = ReachedEndOfList(nums.Length, endIndex);
                        }
                    }

                    if (endIndex <= nums.Length -1)
                    {
                        traverseIndex = endIndex;
                        while (traverseIndex > currentIndex + 1)
                        {
                            swapInt = nums[traverseIndex - 1];
                            nums[traverseIndex - 1] = nums[traverseIndex];
                            nums[traverseIndex] = swapInt;
                            --traverseIndex;

                        }
                    }

                    ++currentIndex;
                    ++endIndex;
                }
            }

            return nums.Distinct().ToArray().Length;            
        }

        private static bool ReachedEndOfList(int arraySize, int index)
        {
            return index >= (arraySize -1);
        }

        /// <summary>
        /// Runtime: 268 ms, faster than 84.86% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.6 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        ///
        /// second run:
        /// Runtime: 264 ms, faster than 86.01% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.6 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates2(int[] nums)
        {
            if (nums == null)
                return 0;
            nums.OrderBy(x => x).ToArray();

            if (nums.Length <= 2)
                return nums.Distinct().ToArray().Length;

            var startIndex = 0;
            var endIndex = 1;
            var IsEndOfTraverse = false;
            var swapInt = 0;

            while (!IsEndOfTraverse)
            {
                IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                if (nums[startIndex] != nums[endIndex])
                {
                    if (startIndex == endIndex - 1)
                    {
                        IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                    }
                    else
                    {
                        while (!IsEndOfTraverse && (nums[endIndex] == nums[endIndex + 1]))
                        {
                            ++endIndex;
                            IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                        }

                        swapInt = nums[endIndex];
                        nums[endIndex] = nums[startIndex + 1];
                        nums[startIndex + 1] = swapInt;
                    }
                }
                else
                {
                    //traverse endIndex to find the next unique number
                    while (!IsEndOfTraverse && (nums[endIndex] == nums[endIndex + 1]))
                    {
                        ++endIndex;
                        IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                    }

                    if (IsEndOfTraverse)
                    {
                        if (nums[startIndex] != nums[endIndex])
                        {
                            swapInt = nums[endIndex];
                            nums[endIndex] = nums[startIndex + 1];
                            nums[startIndex + 1] = swapInt;
                        }
                    }
                    else
                    {
                        //after next unique number identified.  Loop thru the last index of this unique number
                        ++endIndex;
                        IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                        while (!IsEndOfTraverse && nums[endIndex] == nums[endIndex + 1])
                        {
                            ++endIndex;
                            IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                        }
                        //either we reached end of traverse, or we locate the last unique number
                        swapInt = nums[endIndex];
                        nums[endIndex] = nums[startIndex + 1];
                        nums[startIndex + 1] = swapInt;
                    }
                }

                ++startIndex;
                ++endIndex;
                
            }
            return nums.Distinct().ToArray().Length;
        }

        /// <summary>
        /// Note: this solution was found in the discussion.  Used to compare the performance.
        /// Runtime: 260 ms, faster than 88.75% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 31.4 MB, less than 74.36% of C# online submissions for Remove Duplicates from Sorted Array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates3(int[] nums)
        {
            int l = 0;
            int r = 1;
            int n = nums.Length;
            int i = 1;

            if (n == 0)
            {
                return 0;
            }
            else
            {
                while (r <= n - 1)
                {
                    if (nums[l] == nums[r])
                    {
                        r++;
                    }
                    else
                    {
                        nums[i] = nums[r];
                        l = r;
                        r = r + 1;
                        i++;
                    }
                }
            }
            return i;
        }

        /// <summary>
        /// Runtime: 268 ms, faster than 84.86% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.7 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        ///
        /// second submit (after refactor)
        /// Runtime: 268 ms, faster than 84.86% of C# online submissions for Remove Duplicates from Sorted Array.
        /// Memory Usage: 32.6 MB, less than 5.13% of C# online submissions for Remove Duplicates from Sorted Array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates4(int[] nums)
        {
            if (nums == null)
                return 0;
            nums.OrderBy(x => x).ToArray();

            if (nums.Length <= 2)
                return nums.Distinct().ToArray().Length;

            var startIndex = 0;
            var endIndex = 1;
            var isEndOfTraverse = false;

            while (!isEndOfTraverse)
            {
                isEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                if (nums[startIndex] != nums[endIndex])
                {
                    if (startIndex == endIndex - 1)
                    {
                        isEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                    }
                    else
                    {
                        FindNextArrayElement(nums, ref endIndex);
                        ArrayElementSwap(nums, startIndex + 1, endIndex);
                        isEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                    }
                }
                else
                {
                    //traverse endIndex to find the next unique number
                    FindNextArrayElement(nums, ref endIndex);
                    isEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);

                    if (isEndOfTraverse)
                    {
                        if (nums[startIndex] != nums[endIndex])
                        {
                            ArrayElementSwap(nums, startIndex + 1, endIndex);
                        }
                    }
                    else
                    {
                        //after next unique number identified.  Loop thru the last index of this unique number
                        ++endIndex;
                        FindNextArrayElement(nums, ref endIndex);
                        ArrayElementSwap(nums, startIndex + 1, endIndex);
                        isEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
                    }
                }

                ++startIndex;
                ++endIndex;

            }
            return nums.Distinct().ToArray().Length;
        }

        private static void FindNextArrayElement(int[] nums, ref int endIndex)
        {
            var IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
            while (!IsEndOfTraverse && nums[endIndex] == nums[endIndex + 1])
            {
                ++endIndex;
                IsEndOfTraverse = ReachedEndOfList(nums.Length, endIndex);
            }
        }

        private static void ArrayElementSwap(int[] nums, int startIndex, int endIndex)
        {
            if ((nums.Length >= startIndex) && (nums.Length >= endIndex))
            {
                var tempInt = nums[startIndex];
                nums[startIndex] = nums[endIndex];
                nums[endIndex] = tempInt;
            }
        }
    }




    public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
