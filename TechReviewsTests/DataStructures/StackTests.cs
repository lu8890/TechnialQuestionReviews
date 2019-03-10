using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviewsTests.DataStructures
{
    [TestClass()]
    public class StackTests
    {
        [TestMethod()]
        public void PushTest()
        {
            var intStack = new lu8890.TechReviews.DataStructures.Stack<int>();
            intStack.Push(new Node<int>(0));
            Assert.AreEqual(intStack.Length, 1);
            var outNode = intStack.Pop();
            Assert.AreEqual(outNode.NodeValue, 0);
            Assert.AreEqual(intStack.Length, 0);

            intStack.Push(new Node<int>(0));
            intStack.Push(new Node<int>(1));
            Assert.AreEqual(intStack.Length, 2);
            outNode = intStack.Pop();
            Assert.AreEqual(outNode.NodeValue, 1);
            Assert.AreEqual(intStack.Length, 1);
            outNode = intStack.Pop();
            Assert.AreEqual(outNode.NodeValue, 0);
            Assert.AreEqual(intStack.Length, 0);

            intStack.Push(new Node<int>(0));
            intStack.Push(new Node<int>(1));
            intStack.Push(new Node<int>(2));
            intStack.Push(new Node<int>(3));
            intStack.Push(new Node<int>(4));
            intStack.Push(new Node<int>(5));
            Assert.AreEqual(intStack.Length, 6);
            outNode = intStack.Pop();
            Assert.AreEqual(outNode.NodeValue, 5);
            Assert.AreEqual(intStack.Length, 5);
        }
    }
}