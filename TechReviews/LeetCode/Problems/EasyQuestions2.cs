using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lu8890.TechReviews.LeetCode.Problems
{
    public partial class EasyQuestions
    {
        /// <summary>
        /// https://leetcode.com/problems/remove-element/
        /// Runtime: 252 ms, faster than 84.53% of C# online submissions for Remove Element.
        /// Memory Usage: 28.5 MB, less than 5.06% of C# online submissions for Remove Element.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            if (!nums.Contains(val))
                return nums.Length;
            if (nums.Count(x => x != val) == nums.Length)
                return 0;

            var startIndex = 0;
            var traverse = 0;
            var swapInt = 0;

            while (startIndex < nums.Length)
            {
                if (nums[startIndex] == val)
                {
                    traverse = startIndex + 1;
                    while (traverse < nums.Length)
                    {
                        if (nums[traverse] == val)
                            ++traverse;
                        else
                        {
                            swapInt = nums[startIndex];
                            nums[startIndex] = nums[traverse];
                            nums[traverse] = swapInt;
                            break;
                        }
                    }
                }

                ++startIndex;
            }

            return nums.Count(x => x != val);
        }

        /// <summary>
        /// https://leetcode.com/problems/implement-strstr/
        /// Runtime: 72 ms, faster than 100.00% of C# online submissions for Implement strStr().
        /// Memory Usage: 20.4 MB, less than 47.83% of C# online submissions for Implement strStr().
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(haystack) && string.IsNullOrEmpty(needle))
                return 0;
            if ((string.IsNullOrWhiteSpace(haystack)) || (needle.Length > haystack.Length))
                return -1;
            if (string.IsNullOrEmpty(needle))
                return 0;

            return haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// https://leetcode.com/problems/search-insert-position/
        /// Runtime: 96 ms, faster than 85.26% of C# online submissions for Search Insert Position.
        /// Memory Usage: 22.9 MB, less than 8.33% of C# online submissions for Search Insert Position.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if ((nums == null) || (nums.Length == 0))
                return 1;

            if (nums.Contains(target))
            {
                return nums.Length - nums.SkipWhile(x => x != target).Count();
            }
            else
            {
                return nums.Length - nums.SkipWhile(x => x < target).Count();
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/count-and-say/
        /// Runtime: 84 ms, faster than 94.73% of C# online submissions for Count and Say.
        /// Memory Usage: 23.7 MB, less than 46.51% of C# online submissions for Count and Say.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n <= 0)
                return "0";
            else if (n == 1)
                return "1";
            else if (n == 2)
                return "11";
            else
            {
                var CAS = "11";

                for (var i = 2; i < n; i++)
                {
                    CAS = BuildCountAndSay(CAS);
                }

                return CAS;
            }
        }

        private static string BuildCountAndSay(string input)
        {
            var inArray = input.ToCharArray();
            var map = new List<StringBuilder>();

            char key = inArray[0];
            var token = new StringBuilder();
            token.Append(key);

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == key)
                    token.Append(input[i]);
                else
                {
                    map.Add(token);
                    token = new StringBuilder();
                    token.Append(input[i]);
                    key = input[i];
                }
            }

            if (!string.IsNullOrWhiteSpace(token.ToString()))
                map.Add(token);

            var resultBuilder = new StringBuilder();
            foreach (var t in map)
            {
                var lineArray = t.ToString().ToCharArray();
                resultBuilder.Append(lineArray.Length);
                resultBuilder.Append(Convert.ToString(lineArray[0]));
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-subarray/
        /// Time Limited Exceeded
        /// Submission failed with Time Limited Exceeded after passed 200/202 test cases.
        /// The failing test case has with nums.Length > 3000
        ///
        /// round 2:
        /// Runtime: 400 ms, faster than 8.72% of C# online submissions for Maximum Subarray.
        /// Memory Usage: 23.3 MB, less than 29.25% of C# online submissions for Maximum Subarray.
        ///
        /// round 3:
        /// Runtime: 396 ms, faster than 9.01% of C# online submissions for Maximum Subarray.
        /// Memory Usage: 23.4 MB, less than 8.49% of C# online submissions for Maximum Subarray.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if ((nums == null) || (nums.Length == 0))
                return 0;
            if (nums.Length == 1)
                return nums[0];

            var sum = nums[0];
            var traverseIndex = 0;
            int max = nums[0];

            for (var i = 0; i < nums.Length; i++)
            {
                sum = nums[i];
                if (nums[i] > max)
                    max = nums[i];

                traverseIndex = i + 1;
                while (traverseIndex < nums.Length)
                {
                    sum += nums[traverseIndex];
                    if (sum > max)
                        max = sum;
                    ++traverseIndex;
                }
            }

            return max;
        }

        /// <summary>
        /// This is the copy/modification of a C++ solution found in discussion section.
        /// https://leetcode.com/problems/maximum-subarray/
        /// Runtime: 104 ms, faster than 80.82% of C# online submissions for Maximum Subarray.
        /// Memory Usage: 23.2 MB, less than 73.58% of C# online submissions for Maximum Subarray.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray2(int[] nums)
        {
            if ((nums == null) || (nums.Length == 0))
                return 0;
            if (nums.Length == 1)
                return nums[0];

            var sum = nums[0];
            var maxSum = sum;

            for (var i = 1; i < nums.Length; i++)
            {
                sum = (nums[i] > sum + nums[i])
                    ? nums[i]
                    : sum + nums[i];

                maxSum = (sum > maxSum)
                    ? sum
                    : maxSum;
            }

            return maxSum;
        }

        /// <summary>
        /// from a Python solution in discussion
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray3(int[] nums)
        {
            if ((nums == null) || (nums.Length == 0))
                return 0;
            if (nums.Length == 1)
                return nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > 0)
                    nums[i] += nums[i - 1];
            }

            return nums.Max(x => x);
        }

        /// <summary>
        /// https://leetcode.com/problems/length-of-last-word/
        /// Runtime: 76 ms, faster than 91.70% of C# online submissions for Length of Last Word.
        /// Memory Usage: 20.3 MB, less than 21.28% of C# online submissions for Length of Last Word.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s.Trim()))
                return 0;

            var wordTokens = s.Trim().Split(' ');
            if (wordTokens.Length == 0)
                return 0;
            else
                return wordTokens.LastOrDefault().Length;
        }

        /// <summary>
        /// https://leetcode.com/problems/plus-one/
        /// this solution generally working until int of int[] is becoming bigger than int.Max
        /// it breaks the test case with input [9,8,7,6,5,4,3,2,1,0] with System.OverflowException
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            if ((digits == null) || (digits.Length == 0))
                return new int[] { };

            var input = string.Join("", digits);
            int output;
            try
            {
                output = Convert.ToInt32(input);
            }
            catch (OverflowException e)
            {
                return PlusOne2(digits);
            }

            ++output;
            var outp = output.ToString()
                .ToCharArray()
                .Select(x => Char.GetNumericValue(x))
                .Select(y => (int) y)
                .ToArray();

            return outp;
        }

        /// <summary>
        /// Runtime: 280 ms, faster than 72.58% of C# online submissions for Plus One.
        /// Memory Usage: 28.3 MB, less than 5.48% of C# online submissions for Plus One.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne2(int[] digits)
        {
            if ((digits == null) || (digits.Length == 0))
                return new int[] { };

            var willOverflow = false;

            for (var i = 0; i < digits.Length; i++)
            {
                if (digits[i] != 9)
                {
                    willOverflow = false;
                    break;
                }

                willOverflow = true;
            }

            int[] output;

            if (willOverflow)
            {
                output = new int[digits.Length + 1];
                output[0] = 1;
                for (int j = 1; j < output.Length; j++)
                    output[j] = 0;

                return output;
            }

            output = digits;
            if (digits[digits.Length - 1] < 9)
            {
                ++digits[digits.Length - 1];

                return output;
            }
            else
            {
                output[digits.Length - 1] = 0;
                int traverse = digits.Length - 2;
                while (traverse >= 0)
                {
                    if (output[traverse] != 9)
                    {
                        ++output[traverse];
                        break;
                    }
                    else
                    {
                        output[traverse] = 0;
                        --traverse;
                    }
                }

                return output;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/add-binary/
        /// Runtime: 88 ms, faster than 92.49% of C# online submissions for Add Binary.
        /// Memory Usage: 22.6 MB, less than 89.39% of C# online submissions for Add Binary.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a))
                return b;
            else if (string.IsNullOrWhiteSpace(b))
                return a;

            var length = (a.Length > b.Length)
                ? a.Length
                : b.Length;

            StringBuilder resultBuilder = new StringBuilder();


            var arrayA = a.ToCharArray();
            var arrayB = b.ToCharArray();
            var traverseIndexA = arrayA.Length - 1;
            var traverseIndexB = arrayB.Length - 1;
            var carryOver = false;
            var sum = 0;

            while (length > 0)
            {
                if (traverseIndexA >= 0 && traverseIndexB >= 0)
                {
                    sum = (int) Char.GetNumericValue(arrayA[traverseIndexA]) +
                          (int) Char.GetNumericValue(arrayB[traverseIndexB]);
                    if (carryOver)
                    {
                        ++sum;
                        carryOver = false;
                    }

                    if (sum == 3)
                    {
                        resultBuilder.Insert(0, '1');
                        carryOver = true;
                    }
                    else if (sum == 2)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = true;
                    }
                    else if (sum == 1)
                    {
                        resultBuilder.Insert(0, '1');
                        carryOver = false;
                    }
                    else if (sum == 0)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = false;
                    }
                }
                else if (traverseIndexA >= 0)
                {
                    sum = (int) Char.GetNumericValue(arrayA[traverseIndexA]);
                    if (carryOver)
                    {
                        ++sum;
                        carryOver = false;
                    }

                    if (sum == 0)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = false;
                    }
                    else if (sum == 1)
                    {
                        resultBuilder.Insert(0, '1');
                        carryOver = false;
                    }
                    else if (sum == 2)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = true;
                    }

                }
                else if (traverseIndexB >= 0)
                {
                    sum = (int) Char.GetNumericValue(arrayB[traverseIndexB]);
                    if (carryOver)
                    {
                        ++sum;
                        carryOver = false;
                    }

                    if (sum == 0)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = false;
                    }
                    else if (sum == 1)
                    {
                        resultBuilder.Insert(0, '1');
                        carryOver = false;
                    }
                    else if (sum == 2)
                    {
                        resultBuilder.Insert(0, '0');
                        carryOver = true;
                    }
                }

                --traverseIndexA;
                --traverseIndexB;
                --length;
                sum = 0;
            }

            if (carryOver)
                resultBuilder.Insert(0, '1');

            return resultBuilder.ToString();
        }

        /// <summary>
        /// https://leetcode.com/problems/sqrtx/
        /// Runtime: 40 ms, faster than 100.00% of C# online submissions for Sqrt(x).
        /// Memory Usage: 13 MB, less than 52.46% of C# online submissions for Sqrt(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            if ((x == 0) || (x == 1))
                return x;

            return (int) Math.Sqrt(x);
        }

        /// <summary>
        /// got this solution from the discussion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt2(int x)
        {
            if (x == 0)
                return 0;
            int left = 1, right = Int32.MaxValue;
            while (true)
            {
                int mid = left + (right - left) / 2;
                if (mid > x / mid)
                {
                    right = mid - 1;
                }
                else
                {
                    if (mid + 1 > x / (mid + 1))
                        return mid;
                    left = mid + 1;
                }
            }
        }

        /// <summary>
        /// got this solution from the discussion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt3(int x)
        {
            int tmp = 1;
            while (tmp <= x / tmp)
            {
                tmp++;
            }

            return tmp - 1;
        }

        /// <summary>
        /// got this solution from the discussion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt4(int x)
        {
            long l = 1;
            long r = x;
            while (l < r)
            {
                long mid = l + (r - l) / 2;
                if (mid == x / mid)
                {
                    return (int) mid;
                }
                else if (mid > x / mid)
                {
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }

            return l > x / l ? (int) l - 1 : (int) l;
        }

        /// <summary>
        /// got this solution from the discussion
        /// this algorithm was written in C, which is having issue in C# with following statement:
        ///     int mid = start + (end - mid) / 2;
        /// did not know you can declare a variable and assign its value to it.... wondering how does it work..
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public int MySqrt5(int x)
        //{
        //    if (x == 0 || x == 1)
        //    {
        //        return x;
        //    }

        //    int start = 1;
        //    int end = x / 2;
        //    // standard binary search template
        //    while (start + 1 < end)
        //    {
        //        int mid = start + (end - mid) / 2;
        //        // why not mid * mid <= x? because it may cause overflow when mid is very large
        //        if (mid <= x / mid)
        //        {
        //            start = mid;
        //        }
        //        else
        //        {
        //            end = mid - 1;
        //        }
        //    }
        //    return end <= x / end ? end : start;
        //}


        ///https://leetcode.com/problems/climbing-stairs/submissions/
        ///Runtime: 36 ms, faster than 100.00% of C# online submissions for Climbing Stairs.
        ///Memory Usage: 12.9 MB, less than 10.78% of C# online submissions for Climbing Stairs.
        /// 
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            var pos1 = 1;
            var pos2 = 2;
            for (var i = 3; i <= n; i++)
            {
                pos2 = pos2 + pos1;
                pos1 = pos2 - pos1;
            }

            return pos2;
        }

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list/
        /// Runtime: 92 ms, faster than 100.00% of C# online submissions for Remove Duplicates from Sorted List.
        /// Memory Usage: 23.9 MB, less than 16.28% of C# online submissions for Remove Duplicates from Sorted List.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if ((head == null) || (head.next == null))
                return head;

            if (!IsSortedList(head))
                return head;

            var travers = head;
            while (travers.next != null)
            {
                if (travers.val == travers.next.val)
                {
                    travers.next = travers.next.next;
                }
                else
                    travers = travers.next;
            }

            return head;
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-sorted-array/
        /// Runtime: 268 ms, faster than 80.39% of C# online submissions for Merge Sorted Array.
        /// Memory Usage: 28.5 MB, less than 93.44% of C# online submissions for Merge Sorted Array.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var nums1Index = 0;
            var nums2Index = 0;

            while ((nums2Index < n) && (n <= nums2.Length))
            {
                while ((nums1Index < nums1.Length))
                {
                    if ((nums2[nums2Index] > nums1[nums1Index]) && (nums1Index < m))
                        ++nums1Index;
                    else
                    {
                        var end1Index = nums1.Length - 1;
                        while (end1Index != nums1Index)
                        {
                            nums1[end1Index] = nums1[end1Index - 1];
                            --end1Index;
                        }

                        nums1[nums1Index] = nums2[nums2Index];
                        ++m;
                        break;
                    }
                }

                ++nums2Index;
            }
        }

        /// <summary>
        /// This logic works, execpt nums1 = results.ToArray() would assign a new memory for nums1,
        /// hence, calling function will not get the modified results.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int[] output = new int[nums1.Length];

            List<int> result = new List<int>();
            var nums1Index = 0;
            var nums2Index = 0;

            while (nums1Index < m && nums2Index < n)
            {
                if ((nums1[nums1Index] < nums2[nums2Index]) && (nums1[nums1Index] != 0))
                {
                    result.Add(nums1[nums1Index]);
                    ++nums1Index;
                }
                else
                {
                    result.Add(nums2[nums2Index]);
                    ++nums2Index;
                }
            }

            while (nums1Index < m)
            {
                result.Add(nums1[nums1Index]);
                ++nums1Index;
            }

            while (nums2Index < n)
            {
                result.Add(nums2[nums2Index]);
                ++nums2Index;
            }

            nums1 = result.ToArray();
        }
    }
}
