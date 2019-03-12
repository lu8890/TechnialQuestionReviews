using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(!string.IsNullOrWhiteSpace(token.ToString()))
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

            for (var i=1; i < nums.Length; i++)
            {
                if (nums[i - 1] > 0)
                    nums[i] += nums[i - 1];
            }

            return nums.Max(x => x);
        }
    }
}
