using System;
using lu8890.TechReviews.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS = lu8890.TechReviews.InterviewQuestions.Microsoft;

namespace lu8890.TechReviewsTests.InterviewQuestions
{
    [TestClass]
    public class Microsoft
    {
        [TestMethod]
        public void IsACirtularLinkedListTest()
        {
            var testClass = new MS();
            var result = testClass.IsACirtularLinkedList(null);
            Assert.AreEqual(false, result);

            var testNode = new Node<int>(0);
            result = testClass.IsACirtularLinkedList(testNode);
            Assert.AreEqual(false, result);

            testNode = new Node<int>(0){NextNode = new Node<int>(10)};
            result = testClass.IsACirtularLinkedList(testNode);
            Assert.AreEqual(false, result);

            testNode = new Node<int>(0) { NextNode = new Node<int>(10) { NextNode = new Node<int>(20)} };
            result = testClass.IsACirtularLinkedList(testNode);
            Assert.AreEqual(false, result);

            //loop back to second node on the list
            testNode = new Node<int>(0)
                {NextNode = new Node<int>(10) {NextNode = new Node<int>(20) {NextNode = new Node<int>(30)}}};
            testNode.NextNode.NextNode.NextNode.NextNode = testNode.NextNode;
            result = testClass.IsACirtularLinkedList(testNode);
            Assert.AreEqual(true, result);

            //loop back to the head
            testNode = new Node<int>(0)
                { NextNode = new Node<int>(10) { NextNode = new Node<int>(20) { NextNode = new Node<int>(30) } } };
            testNode.NextNode.NextNode.NextNode.NextNode = testNode;
            result = testClass.IsACirtularLinkedList(testNode);
            Assert.AreEqual(true, result);

            //looping at self
            testNode = new Node<int>(0)
                { NextNode = new Node<int>(10) { NextNode = new Node<int>(20) { NextNode = new Node<int>(30) } } };
            testNode.NextNode.NextNode.NextNode.NextNode = testNode.NextNode.NextNode.NextNode;
            result = testClass.IsACirtularLinkedList(testNode);
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
    }
}
