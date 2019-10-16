using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using lu8890.TechReviews.LeetCode.Problems;
using lu8890.TechReviews.DataStructures;
using TreeNode = lu8890.TechReviews.LeetCode.Models.TreeNode;
//using TreeNode2 = lu8890.TechReviews.DataStructures.TreeNode;
using lu8890.TechReviews.LeetCode.Problems.Easy;
using lu8890.TechReviews.LeetCode.Models;

namespace lu8890.TechReviewsTests.LeetCode.Problems
{
    [TestClass]
    public class EasyQuestions2Tests
    {
        [TestMethod]
        public void RemoveElementTest()
        {
            var testFunc = new ArrayQ();
            var testcase = new int[] {3, 2, 2, 3};
            var output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(2, output);
            var result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] {2, 2});

            testcase = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(5, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 0, 1, 3, 0, 4 });

            testcase = new int[] { 3, 2, 2, 3 };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(2, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 3,3 });

            testcase = new int[] { };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(0, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { });

            testcase = new int[] { 1};
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(1, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 1});

            testcase = new int[] { 1 };
            output = testFunc.RemoveElement(testcase, 1);
            Assert.AreEqual(0, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { });

            testcase = new int[] { 3,3,1,2,4,3,3 };
            output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(3, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] {1,2,4});

            testcase = new int[] { 3, 3, 1, 2,3, 4, 3, 3 };
            output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(3, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 1, 2, 4 });
        }

        private static void ValidateArrayElements(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
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

        [TestMethod]
        public void StrStrTest()
        {
            var testFunc = new ArrayQ();
            Assert.AreEqual(-1, testFunc.StrStr(string.Empty, "ll"));
            Assert.AreEqual(0, testFunc.StrStr("hello", string.Empty));
            Assert.AreEqual(0, testFunc.StrStr(string.Empty, string.Empty));
            Assert.AreEqual(2, testFunc.StrStr("hello","ll"));
            Assert.AreEqual(-1, testFunc.StrStr("aaaaa", "bba"));
            Assert.AreEqual(0, testFunc.StrStr("aaaaa", "aaa"));
            Assert.AreEqual(1, testFunc.StrStr("baaaaa", "aaa"));
        }

        [TestMethod]
        public void SearchInsertTest()
        {
            var testFunc = new ArrayQ();
            Assert.AreEqual(2, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 5));
            Assert.AreEqual(1, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 2));
            Assert.AreEqual(4, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 7));
            Assert.AreEqual(0, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 0));

        }

        [TestMethod]
        public void CountAndSayTest()
        {
            var testFunc = new ArrayQ();
            Assert.AreEqual("0", testFunc.CountAndSay(0));
            Assert.AreEqual("1", testFunc.CountAndSay(1));
            Assert.AreEqual("11", testFunc.CountAndSay(2));
            Assert.AreEqual("21", testFunc.CountAndSay(3));
            Assert.AreEqual("1211", testFunc.CountAndSay(4));
            Assert.AreEqual("111221", testFunc.CountAndSay(5));
            Assert.AreEqual("312211", testFunc.CountAndSay(6));
            Assert.AreEqual("13112221", testFunc.CountAndSay(7));
            Assert.AreEqual("1113213211", testFunc.CountAndSay(8));
        }

        [TestMethod]
        public void MaxSubArrayTest()
        {
            var testFunc = new MaxSubArrayTestDel(new ArrayQ().MaxSubArray);
            RunMaxSubArrayTest(testFunc);
        }

        [TestMethod]
        public void MaxSubArray2Test()
        {
            var testFunc = new MaxSubArrayTestDel(new ArrayQ().MaxSubArray2);
            RunMaxSubArrayTest(testFunc);
        }

        [TestMethod]
        public void MaxSubArray3Test()
        {
            var testFunc = new MaxSubArrayTestDel(new ArrayQ().MaxSubArray3);
            RunMaxSubArrayTest(testFunc);
        }

        public delegate int MaxSubArrayTestDel(int[] nums);

        private void RunMaxSubArrayTest(MaxSubArrayTestDel testFunc)
        {
            Assert.AreEqual(0, testFunc.Invoke(new int[] { }));
            Assert.AreEqual(0, testFunc.Invoke(new int[] { 0 }));
            Assert.AreEqual(-1, testFunc.Invoke(new int[] { -1 }));
            Assert.AreEqual(10, testFunc.Invoke(new int[] { -1, 10 }));
            Assert.AreEqual(5, testFunc.Invoke(new int[] { -1, 3, 2 }));
            Assert.AreEqual(6, testFunc.Invoke(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));

        }

        [TestMethod]
        public void LengthOfLastWordTest()
        {
            var testCase = new ArrayQ();
            Assert.AreEqual(5, testCase.LengthOfLastWord("Hello World"));
            Assert.AreEqual(0, testCase.LengthOfLastWord(""));
            Assert.AreEqual(0, testCase.LengthOfLastWord(" "));
            Assert.AreEqual(6, testCase.LengthOfLastWord("How are you doing?"));
            Assert.AreEqual(6, testCase.LengthOfLastWord("How are you doing? "));
        }

        [TestMethod]
        public void PlusOneTest()
        {
            var p = new ArrayQ();
            var testFunc = new PlusOneDel(p.PlusOne);
            PlusOneTestDriver(testFunc);
        }

        [TestMethod]
        public void PlusOneTest2()
        {
            var p = new ArrayQ();
            var testFunc = new PlusOneDel(p.PlusOne2);
            PlusOneTestDriver(testFunc);
        }

        public delegate int[] PlusOneDel(int[] input);

        private static void PlusOneTestDriver(PlusOneDel testFunc)
        {
            
            var result = testFunc.Invoke((new int[] { 1, 2, 3 }));
            Assert.AreEqual(4, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 1 });
            Assert.AreEqual(2, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 0 });
            Assert.AreEqual(1, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 5 });
            Assert.AreEqual(6, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1 });
            Assert.AreEqual(2, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,1, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,9,9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            Assert.AreEqual(1, result.LastOrDefault());
        }

        [TestMethod]
        public void AddBinaryTest()
        {
            var p = new ArrayQ();
            Assert.AreEqual("100", p.AddBinary("1", "11"));
            Assert.AreEqual("10101", p.AddBinary("1010", "1011"));
            Assert.AreEqual("110", p.AddBinary("11", "11"));
            Assert.AreEqual("11", p.AddBinary("11", ""));
            Assert.AreEqual("11", p.AddBinary("", "11"));
            Assert.AreEqual("0", p.AddBinary("0", "0"));
            Assert.AreEqual("10", p.AddBinary("1", "1"));
        }

        [TestMethod]
        public void MySqrtTest()
        {
            var p = new ArrayQ();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt);
        }

        [TestMethod]
        public void MySqrtTest2()
        {
            var p = new ArrayQ();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt2);
        }

        [TestMethod]
        public void MySqrtTest3()
        {
            var p = new ArrayQ();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt3);
        }

        [TestMethod]
        public void MySqrtTest4()
        {
            var p = new ArrayQ();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt4);
        }

        public delegate int MySqrtDel(int x);
        private static void RunMySqrtTest(MySqrtDel testFunc)
        {
            Assert.AreEqual(0, testFunc.Invoke(0));
            Assert.AreEqual(1, testFunc.Invoke(1));
            Assert.AreEqual(2, testFunc.Invoke(4));
            Assert.AreEqual(2, testFunc.Invoke(8));
        }

        [TestMethod]
        public void ClimbStairsTest()
        {
            var testp = new ArrayQ();
            Assert.AreEqual(1,testp.ClimbStairs(1));
            Assert.AreEqual(2, testp.ClimbStairs(2));
            Assert.AreEqual(3, testp.ClimbStairs(3));
            Assert.AreEqual(5, testp.ClimbStairs(4));
            Assert.AreEqual(8, testp.ClimbStairs(5));
            Assert.AreEqual(13, testp.ClimbStairs(6));
            Assert.AreEqual(21, testp.ClimbStairs(7));
            Assert.AreEqual(34, testp.ClimbStairs(8));
            Assert.AreEqual(55, testp.ClimbStairs(9));
            Assert.AreEqual(89, testp.ClimbStairs(10));
        }

        [TestMethod]
        public void DeleteDuplicatesTest()
        {
            var testp = new ArrayQ();
            var testcase = new ListNode(1);
            var result = testp.DeleteDuplicates(null);
            Assert.AreEqual(null, result);

            testcase = new ListNode(1){next = new ListNode(1)};
            testcase.next.next = new ListNode(2);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1 2", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(1) };
            testcase.next.next = new ListNode(2);
            testcase.next.next.next = new ListNode(3);
            testcase.next.next.next.next = new ListNode(3);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1 2 3", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(2) };
            testcase.next.next = new ListNode(3);
            testcase.next.next.next = new ListNode(1);
            testcase.next.next.next.next = new ListNode(2);
            testcase.next.next.next.next.next = new ListNode(3);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1 2 3 1 2 3", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(2) };
            testcase.next.next = new ListNode(2);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1 2", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(1) };
            testcase.next.next = new ListNode(2);
            testcase.next.next.next = new ListNode(3);
            testcase.next.next.next.next = new ListNode(3);
            testcase.next.next.next.next.next = new ListNode(4);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1 2 3 4", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(1) };
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1", EasyQuestionsTests.GetLinkedListItems(result));

            testcase = new ListNode(1) { next = new ListNode(1) };
            testcase.next.next = new ListNode(1);
            result = testp.DeleteDuplicates(testcase);
            Assert.AreEqual("1", EasyQuestionsTests.GetLinkedListItems(result));
        }

        [TestMethod]
        public void MergeTest()
        {
            var testP = new ArrayQ();
            var nums1 = new int[] {1, 2, 3, 0, 0, 0};
            var m = 3;
            var nums2 = new int[] {2, 5, 6};
            var n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("1 2 2 3 5 6", string.Join(" ", nums1));

            nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 2, 5 };
            n = 2;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("1 2 2 3 5 0", string.Join(" ", nums1));

            nums1 = new int[] { 6, 7, 8, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 2, 3, 5 };
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("2 3 5 6 7 8", string.Join(" ", nums1));

            nums1 = new int[] { 6, 7, 8, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 9, 10, 11};
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("6 7 8 9 10 11", string.Join(" ", nums1));

            nums1 = new int[] { 6, 7, 12, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 9, 10, 11 };
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("6 7 9 10 11 12", string.Join(" ", nums1));

            nums1 = new int[] { 6, 7, 12, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 8, 8, 8 };
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("6 7 8 8 8 12", string.Join(" ", nums1));

            nums1 = new int[] { 8, 8, 8, 0, 0, 0 };
            m = 3;
            nums2 = new int[] { 9, 10, 11 };
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("8 8 8 9 10 11", string.Join(" ", nums1));

            nums1 = new int[] { -1, 0, 0, 3, 3, 3, 0, 0, 0 };
            m = 6;
            nums2 = new int[] { 1, 2, 2 };
            n = 3;
            testP.Merge(nums1, m, nums2, n);
            Assert.AreEqual("-1 0 0 1 2 2 3 3 3", string.Join(" ", nums1));
        }

        [TestMethod]
        public void IsSameTreeTest()
        {
            var testClass = new TreeQ();
            var input1 = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3)};
            var input2 = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
            Assert.AreEqual(true, testClass.IsSameTree(input1, input2), "testcase 01 failed");

            input1 = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
            input2 = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(2) };
            Assert.AreEqual(false, testClass.IsSameTree(input1, input2), "testcase 02 failed");

            input1 = new TreeNode(1) { right = new TreeNode(3) };
            input2 = new TreeNode(1) { left = new TreeNode(3) };
            Assert.AreEqual(false, testClass.IsSameTree(input1, input2), "testcase 03 failed");
        }

        [TestMethod]
        public void tempTest()
        {
            var t1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(2) };
            List<int> inp = new List<int>();
            Tree Tree1 = new Tree(inp);
            Tree1.Root = t1;

            Console.WriteLine("-------------- Test1 -------------");
            Console.WriteLine("-------------- In Order -------------");
            Tree1.PrintTreeInOrder(t1);
            Console.WriteLine("\n-------------- Post Order -------------");
            Tree1.PrintTreePostOrder(t1);
            Console.WriteLine("\n-------------- Pre Order -------------");
            Tree1.PrintTreePreOrder(t1);

            t1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) };
            Console.WriteLine("\n\n-------------- Test2 -------------");
            Console.WriteLine("-------------- In Order -------------");
            Tree1.PrintTreeInOrder(t1);
            Console.WriteLine("\n-------------- Post Order -------------");
            Tree1.PrintTreePostOrder(t1);
            Console.WriteLine("\n-------------- Pre Order -------------");
            Tree1.PrintTreePreOrder(t1);

            t1 = new TreeNode(0) { left = new TreeNode(1){left = new TreeNode(3)}, right = new TreeNode(1){ right = new TreeNode(3)} };
            Console.WriteLine("\n\n-------------- Test3 -------------");
            Console.WriteLine("-------------- In Order -------------");
            Tree1.PrintTreeInOrder(t1);
            Console.WriteLine("\n-------------- Post Order -------------");
            Tree1.PrintTreePostOrder(t1);
            Console.WriteLine("\n-------------- Pre Order -------------");
            Tree1.PrintTreePreOrder(t1);

            t1 = new TreeNode(0) { left = new TreeNode(1) { left = new TreeNode(2) }, right = new TreeNode(3) { right = new TreeNode(4) } };
            Console.WriteLine("\n\n-------------- Test4 -------------");
            Console.WriteLine("-------------- In Order -------------");
            Tree1.PrintTreeInOrder(t1);
            Console.WriteLine("\n-------------- Post Order -------------");
            Tree1.PrintTreePostOrder(t1);
            Console.WriteLine("\n-------------- Pre Order -------------");
            Tree1.PrintTreePreOrder(t1);

            t1 = new TreeNode(0) { left = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(4)}, right = new TreeNode(2) { left = new TreeNode(5),right = new TreeNode(6) } };
            Console.WriteLine("\n\n-------------- Test5 -------------");
            Console.WriteLine("-------------- In Order -------------");
            Tree1.PrintTreeInOrder(t1);
            Console.WriteLine("\n-------------- Post Order -------------");
            Tree1.PrintTreePostOrder(t1);
            Console.WriteLine("\n-------------- Pre Order -------------");
            Tree1.PrintTreePreOrder(t1);
        }
    }
}
