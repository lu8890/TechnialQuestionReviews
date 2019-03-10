using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.LeetCode.Problems;

namespace lu8890.TechReviewsTests.LeetCode.Problems
{
    [TestClass()]
    public class EasyQuestionsTests
    {
        [TestMethod()]
        public void TwoSumTest()
        {
            var test = new EasyQuestions(); ;
            Assert.AreEqual(null, test.TwoSum(new int[] { }, 10));
            Assert.AreEqual(null, test.TwoSum(new int[] { 1 }, 10));
            Assert.AreEqual(null, test.TwoSum(new int[] { 2, 3 }, 10));
            Assert.AreEqual(string.Join(", ", new int[] { 0, 1 }).Trim(),
                string.Join(", ", test.TwoSum(new int[] { 5, 5 }, 10)).Trim());
            Assert.AreEqual(string.Join(", ", new int[] { 0, 1 }).Trim(),
                string.Join(", ", test.TwoSum(new int[] { 2, 7, 11, 15 }, 9)).Trim());

            Assert.AreEqual(string.Join(", ", new int[] { 0, 3 }).Trim(),
                string.Join(", ", test.TwoSum(new int[] { 2, 11, 15, 7 }, 9)).Trim());

            Assert.AreEqual(string.Join(", ", new int[] { 0, 3 }).Trim(),
                string.Join(", ", test.TwoSum(new int[] { 7, 11, 15, 2, 7 }, 9)).Trim());

            Assert.AreEqual(string.Join(", ", new int[] { 1, 2 }).Trim(),
                string.Join(", ", test.TwoSum(new int[] { 3, 2, 4 }, 6)).Trim());
        }

        [TestMethod()]
        public void ReverseTest()
        {
            EasyQuestions q = new EasyQuestions();
            Assert.AreEqual(q.Reverse(1),1);
            Assert.AreEqual(q.Reverse(-1), -1);
            Assert.AreEqual(q.Reverse(12),21);
            Assert.AreEqual(q.Reverse(123), 321);
            Assert.AreEqual(q.Reverse(-123), -321);
            Assert.AreEqual(q.Reverse(120), 21);
            Assert.AreEqual(q.Reverse(1534236469), 0);
        }

        [TestMethod()]
        public void IsPalindromeTest()
        {
            EasyQuestions q = new EasyQuestions();
            Assert.AreEqual(q.IsPalindrome(1), true);
            Assert.AreEqual(q.IsPalindrome(-1), false);
            Assert.AreEqual(q.IsPalindrome(12), false);
            Assert.AreEqual(q.IsPalindrome(121), true);
            Assert.AreEqual(q.IsPalindrome(-121), false);
            Assert.AreEqual(q.IsPalindrome(10), false);
            Assert.AreEqual(q.IsPalindrome(1234321), true);
            Assert.AreEqual(q.IsPalindrome(12344321), true);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            EasyQuestions q = new EasyQuestions();
            Assert.AreEqual(q.RomanToInt("I"), 1);
            Assert.AreEqual(q.RomanToInt("i"), 1);
            Assert.AreEqual(q.RomanToInt("III"), 3);
            Assert.AreEqual(q.RomanToInt("IV"), 4);
            Assert.AreEqual(q.RomanToInt("IX"), 9);
            Assert.AreEqual(q.RomanToInt("LVIII"), 58);
            Assert.AreEqual(q.RomanToInt("MCMXCIV"), 1994);
        }

        [TestMethod()]
        public void LongestCommonPrefixTest()
        {
            EasyQuestions q = new EasyQuestions();
            var testCase = new string[] {"TotalPackage"};
            Assert.AreEqual("TotalPackage", q.LongestCommonPrefix(testCase));
            testCase = new string[]{ "flower", "flow", "flight" };
            Assert.AreEqual("fl", q.LongestCommonPrefix(testCase));
            testCase = new string[] { "dog", "racecar", "car" };
            Assert.AreEqual("", q.LongestCommonPrefix(testCase));
        }

        [TestMethod()]
        public void IsValidTest()
        {
            EasyQuestions q = new EasyQuestions();
            Assert.AreEqual(true, q.IsValid(""));
            Assert.AreEqual(true, q.IsValid("()"));
            Assert.AreEqual(true, q.IsValid("()[]{}"));
            Assert.AreEqual(false, q.IsValid("(]"));
            Assert.AreEqual(false, q.IsValid("([)]"));
            Assert.AreEqual(true, q.IsValid("{[]}"));
            Assert.AreEqual(false, q.IsValid("(("));
        }
    }
}