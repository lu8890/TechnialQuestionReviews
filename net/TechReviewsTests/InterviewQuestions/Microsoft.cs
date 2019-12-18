using System;
using lu8890.TechReviews.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS = lu8890.TechReviews.InterviewQuestions.Microsoft;
using System.Collections.Generic;
using System.Linq;
using lu8890.TechReviews.InterviewQuestions;

namespace lu8890.TechReviewsTests.InterviewQuestions
{
    [TestClass]
    public class Microsoft
    {
        [TestMethod]
        public void IsACirtularLinkedListTest()
        {
            var testClass = new MS();
            var result = testClass.IsACircularLinkedList(null);
            Assert.AreEqual(false, result);

            var testNode = new Node<int>(0);
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(false, result);

            testNode = new Node<int>(0){NextNode = new Node<int>(10)};
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(false, result);

            testNode = new Node<int>(0) { NextNode = new Node<int>(10) { NextNode = new Node<int>(20)} };
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(false, result);

            //loop back to second node on the list
            testNode = new Node<int>(0)
                {NextNode = new Node<int>(10) {NextNode = new Node<int>(20) {NextNode = new Node<int>(30)}}};
            testNode.NextNode.NextNode.NextNode.NextNode = testNode.NextNode;
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(true, result);

            //loop back to the head
            testNode = new Node<int>(0)
                { NextNode = new Node<int>(10) { NextNode = new Node<int>(20) { NextNode = new Node<int>(30) } } };
            testNode.NextNode.NextNode.NextNode.NextNode = testNode;
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(true, result);

            //looping at self
            testNode = new Node<int>(0)
                { NextNode = new Node<int>(10) { NextNode = new Node<int>(20) { NextNode = new Node<int>(30) } } };
            testNode.NextNode.NextNode.NextNode.NextNode = testNode.NextNode.NextNode.NextNode;
            result = testClass.IsACircularLinkedList(testNode);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RemoveFirstNodeByValueTest()
        {
            var testClass = new MS();
            var result = testClass.RemoveFirstNodeByValue(10, null);
            Assert.AreEqual(null, result);

            var testNode = new Node<int>(0);
            result = testClass.RemoveFirstNodeByValue(1, testNode);
            Assert.AreEqual("0", result.Print(result));

            result = testClass.RemoveFirstNodeByValue(0, testNode);
            Assert.AreEqual(null, result);

            testNode = new Node<int>(0){ NextNode = new Node<int>(0)};
            result = testClass.RemoveFirstNodeByValue(0, testNode);
            Assert.AreEqual("0", result.Print(result));

            testNode = new Node<int>(0) { NextNode = new Node<int>(1) };
            result = testClass.RemoveFirstNodeByValue(0, testNode);
            Assert.AreEqual("1", result.Print(result));

            testNode = new Node<int>(0) { NextNode = new Node<int>(1) {NextNode = new Node<int>(2)} };
            result = testClass.RemoveFirstNodeByValue(1, testNode);
            Assert.AreEqual("0 2", result.Print(result));

            testNode = new Node<int>(0) { NextNode = new Node<int>(1) { NextNode = new Node<int>(2) } };
            result = testClass.RemoveFirstNodeByValue(2, testNode);
            Assert.AreEqual("0 1", result.Print(result));
        }

        [TestMethod]
        public void FindFirstUniqueCharTest()
        {
            var testClass = new MS();
            var result = testClass.FindFirstUniqueChar(null);
            Assert.AreEqual(' ', result);

            result = testClass.FindFirstUniqueChar(string.Empty);
            Assert.AreEqual(' ', result);

            result = testClass.FindFirstUniqueChar("I");
            Assert.AreEqual('I', result);

            result = testClass.FindFirstUniqueChar("II");
            Assert.AreEqual(' ', result);

            result = testClass.FindFirstUniqueChar("I am the King of Universe");
            Assert.AreEqual('A', result);

            result = testClass.FindFirstUniqueChar("I am an azz of the Universe P");
            Assert.AreEqual('M', result);

            result = testClass.FindFirstUniqueChar("I am an azz of the Unverse P");
            Assert.AreEqual('I', result);

            result = testClass.FindFirstUniqueChar("I am am azz of the Universe P");
            Assert.AreEqual('O', result);

            result = testClass.FindFirstUniqueChar("I am am azz ofF TthHe O UUnniivverrsse P");
            Assert.AreEqual('P', result);
        }

        [TestMethod]
        public void FindAnagramsTest()
        {
            var tester = new MS();
            var result = tester.FindAnagrams(new string[] {"Amy"});
            var expected = new List<List<string>>();
            var testItem = new List<string>() { "Amy" };
            expected.Add(testItem);
            Assert.IsTrue(FindAnagramsTestValidator(expected, result));

            result = tester.FindAnagrams(new string[] { "Amy", "Amy" });
            expected = new List<List<string>>();
            testItem = new List<string>() { "Amy", "Amy"};
            expected.Add(testItem);
            Assert.IsTrue(FindAnagramsTestValidator(expected, result));

            result = tester.FindAnagrams(new string[] { "Amy", "may", "yam" });
            expected = new List<List<string>>();
            testItem = new List<string>() { "Amy", "may", "yam" };
            expected.Add(testItem);
            Assert.IsTrue(FindAnagramsTestValidator(expected, result));

            result = tester.FindAnagrams(new string[] { "Amy", "Aim", "may", "yam" });
            expected = new List<List<string>>();
            testItem = new List<string>() { "Amy", "may", "yam" };
            expected.Add(testItem);
            testItem = new List<string>() { "Aim" };
            expected.Add(testItem);
            Assert.IsTrue(FindAnagramsTestValidator(expected, result));

            result = tester.FindAnagrams(new string[] { "Amy", "Aim", "may", "Gee", "yam", "EgE" });
            expected = new List<List<string>>();
            testItem = new List<string>() { "Amy", "may", "yam" };
            expected.Add(testItem);
            testItem = new List<string>() { "Aim" };
            expected.Add(testItem);
            testItem = new List<string>() { "Gee" , "EgE" };
            expected.Add(testItem);
            Assert.IsTrue(FindAnagramsTestValidator(expected, result));

        }

        private bool FindAnagramsTestValidator(List<List<string>> expected, List<List<string>> result)
        {
            if (expected.Count() != result.Count())
                return false;

            for(int i=0; i<expected.Count(); i++)
            {
                if (!expected[i].SequenceEqual(result[i]))
                    return false;
            }

            return true;
        }
    
    
        [TestMethod]
        public void Microsoft_Interview_Queue_Test()
        {
            var tester = new Microsoft_Interview_Queue();
            tester.Enqueue(0);
            tester.Enqueue(1);
            tester.Enqueue(10);
            tester.Enqueue(100);
            tester.Enqueue(150);
            tester.Enqueue(200);

            Assert.AreEqual(tester.Count, 6);

            var result = tester.Dequeue();
            Assert.AreEqual(tester.Count, 5);
            Assert.AreEqual(result, 0);

            result = tester.Dequeue();
            Assert.AreEqual(tester.Count, 4);
            Assert.AreEqual(result, 1);

            result = tester.Dequeue();
            Assert.AreEqual(tester.Count, 3);
            Assert.AreEqual(result, 10);

            result = tester.Dequeue();
            Assert.AreEqual(tester.Count, 2);
            Assert.AreEqual(result, 100);

            tester.Enqueue(250);
            Assert.AreEqual(tester.Count, 3);

            result = tester.Dequeue();
            Assert.AreEqual(tester.Count, 2);
            Assert.AreEqual(result, 150);

        }
    }
}
