using System;
using System.Text;
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

        [TestMethod()]
        public void MergeTwoListsTest()
        {
            var q = new EasyQuestions();
            var linkedList1 = new ListNode(1) {next = new ListNode(2)};
            linkedList1.next.next = new ListNode(4);

            var linkedList2 = new ListNode(1) { next = new ListNode(3) };
            linkedList2.next.next = new ListNode(4);

            var mergedList = q.MergeTwoLists(linkedList1, linkedList2);
            Assert.AreEqual("1 1 2 3 4 4", GetLinkedListItems(mergedList));

            linkedList1 = null;
            linkedList2 = new ListNode(0) {next = null};
            mergedList = q.MergeTwoLists(linkedList1, linkedList2);
            Assert.AreEqual("0", GetLinkedListItems(mergedList));

            linkedList2 = null;
            linkedList1 = new ListNode(0) { next = null };
            mergedList = q.MergeTwoLists(linkedList1, linkedList2);
            Assert.AreEqual("0", GetLinkedListItems(mergedList));

        }

        private static string GetLinkedListItems(ListNode input)
        {
            var outputBuilder = new StringBuilder();

            while (input != null)
            {
                outputBuilder.Append(input.val + " ");
                input = input.next;
            }

            return outputBuilder.ToString().Trim();
        }

        [TestMethod()]
        public void RemoveDuplicatesTest()
        {
            var q = new EasyQuestions();
            var test = new RemoveDuplicateFuncTests(q.RemoveDuplicates);
            RunRemoveDuplicateTests(test);
        }

        [TestMethod()]
        public void RemoveDuplicates2Test()
        {
            var q = new EasyQuestions();
            var test = new RemoveDuplicateFuncTests(q.RemoveDuplicates2);
            RunRemoveDuplicateTests(test);
        }

        [TestMethod()]
        public void RemoveDuplicates3Test()
        {
            var q = new EasyQuestions();
            var test = new RemoveDuplicateFuncTests(q.RemoveDuplicates3);
            RunRemoveDuplicateTests(test);
        }

        [TestMethod()]
        public void RemoveDuplicates4Test()
        {
            var q = new EasyQuestions();
            var test = new RemoveDuplicateFuncTests(q.RemoveDuplicates4);
            RunRemoveDuplicateTests(test);
        }

        public delegate int RemoveDuplicateFuncTests(int[] input);
        public void RunRemoveDuplicateTests(RemoveDuplicateFuncTests testDel)
        {
            var q = new EasyQuestions();
            var testcase = new int[] { 1, 1, 2 };
            var output = testDel.Invoke(testcase);
            Assert.AreEqual(2, output);
            ValidateArrayElements(new int[] { 1, 2 }, GenerateResultIntOutput(testcase, output));

            testcase = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(5, output);
            ValidateArrayElements(new int[] { 0, 1, 2, 3, 4 }, GenerateResultIntOutput(testcase, output));


            testcase = new[] { 1, 1 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(1, output);
            ValidateArrayElements(new int[] { 1 }, GenerateResultIntOutput(testcase, output));


            testcase = new[] { 1, 2, 2 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(2, output);
            ValidateArrayElements(new int[] { 1, 2 }, GenerateResultIntOutput(testcase, output));


            testcase = new[] { 1, 1, 2, 2 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(2, output);
            ValidateArrayElements(new int[] { 1, 2 }, GenerateResultIntOutput(testcase, output));


            testcase = new[] { 1, 2, 2, 3 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(3, output);
            ValidateArrayElements(new int[] { 1, 2, 3 }, GenerateResultIntOutput(testcase, output));

            testcase = new[] { 1,1,1 };
            output = testDel.Invoke(testcase);
            Assert.AreEqual(1, output);
            ValidateArrayElements(new int[] { 1 }, GenerateResultIntOutput(testcase, output));

            testcase = new[] { -3, -3, -2, -1, -1, 0, 0, 0, 0, 0};
            output = testDel.Invoke(testcase);
            Assert.AreEqual(4, output);
            ValidateArrayElements(new int[] { -3, -2, -1, 0 }, GenerateResultIntOutput(testcase, output));
        }

        private static void ValidateArrayElements(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for(var i=0; i< expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        private static int[] GenerateResultIntOutput(int[] input, int count)
        {
            if ((input == null) || (input.Length < count))
                return null;

            var output = new int[count];
            for (var i = 0; i < count; i++)
                output[i] = input[i];

            return output;
        }
    }
}