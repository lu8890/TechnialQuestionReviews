using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.LeetCode.Models;
using lu8890.TechReviews.LeetCode.Problems.Medium;

namespace lu8890.TechReviewsTests.LeetCode.Problems.Medium
{
    [TestClass]
    public class MediumQuestionsTests
    {
        private delegate ListNode AddTwoNumbsDel(ListNode l1, ListNode l2);

        [TestMethod]
        public void AddTwoNumbers2Test()
        {
            var testClass = new AddTwoNumbsDel(new MediumQuestions().AddTwoNumbers2);
            RunAddTwoNumbersTests(testClass);
        }


        [TestMethod]
        public void AddTwoNumbersTest()
        {
            var testClass = new AddTwoNumbsDel(new MediumQuestions().AddTwoNumbers);
            RunAddTwoNumbersTests(testClass);
        }

        [TestMethod]
        public void AddTwoNumbersTest3()
        {
            var testClass = new AddTwoNumbsDel(new MediumQuestions().AddTwoNumbers3);
            RunAddTwoNumbersTests(testClass);
        }

        private static void RunAddTwoNumbersTests(AddTwoNumbsDel testFunc)
        {
            
            var l1 = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } };
            var l2 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };
            var result = testFunc(l1, l2);
            var outPut = MediumQuestions.ConvertIntListNodeToArray(result);
            CollectionAssert.AreEqual(outPut, new List<int>(){7,0,8});

            l1 = new ListNode(3) { next = new ListNode(2) { next = new ListNode(1) } };
            l2 = new ListNode(6) { next = new ListNode(5) { next = new ListNode(4) } };
            result = testFunc(l1, l2);
            outPut = MediumQuestions.ConvertIntListNodeToArray(result);
            CollectionAssert.AreEqual(outPut, new List<int>() { 9, 7, 5 });

            l1 = new ListNode(5);
            l2 = new ListNode(5);
            result = testFunc(l1, l2);
            outPut = MediumQuestions.ConvertIntListNodeToArray(result);
            CollectionAssert.AreEqual(outPut, new List<int>() { 0, 1 });

            l1 = new ListNode(1) { next = new ListNode(8) };
            l2 = new ListNode(0);
            result = testFunc(l1, l2);
            outPut = MediumQuestions.ConvertIntListNodeToArray(result);
            CollectionAssert.AreEqual(outPut, new List<int>() { 1, 8 });

            l1 = new ListNode(1);
            l2 = new ListNode(9) { next = new ListNode(9) };
            result = testFunc(l1, l2);
            outPut = MediumQuestions.ConvertIntListNodeToArray(result);
            CollectionAssert.AreEqual(outPut, new List<int>() { 0, 0, 1 });
        }
    }
}
