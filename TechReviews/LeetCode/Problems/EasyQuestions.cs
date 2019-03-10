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
    }
}
