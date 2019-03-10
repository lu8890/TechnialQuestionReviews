using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviewsTests.DataStructures
{
    [TestClass()]
    public class QueueTests
    {
        [TestMethod()]
        public void IntQueueTest()
        {
            var intQueue = new lu8890.TechReviews.DataStructures.Queue<int>();
            Assert.AreEqual(intQueue.Root, null);
            Assert.AreEqual(intQueue.Length, 0);

            intQueue.EnQueue(new Node<int>(3));
            Assert.AreEqual(intQueue.Length, 1);
            Assert.AreEqual(intQueue.Root.NodeValue, 3);

            intQueue.EnQueue(new Node<int>(8));
            Assert.AreEqual(intQueue.Length, 2);
            Assert.AreEqual(intQueue.Root.NextNode.NodeValue, 8);

            intQueue.EnQueue(new Node<int>(-1));
            Assert.AreEqual(intQueue.Length, 3);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NodeValue, -1);

            intQueue.EnQueue(new Node<int>(4));
            Assert.AreEqual(intQueue.Length, 4);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NextNode.NodeValue, 4);

            intQueue.EnQueue(new Node<int>(0));
            Assert.AreEqual(intQueue.Length, 5);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NextNode.NextNode.NodeValue, 0);
        }

        [TestMethod()]
        public void StrQueueTest()
        {
            var intQueue = new lu8890.TechReviews.DataStructures.Queue<string>();
            Assert.AreEqual(intQueue.Root, null);
            Assert.AreEqual(intQueue.Length, 0);

            intQueue.EnQueue(new Node<string>("one"));
            Assert.AreEqual(intQueue.Length, 1);
            Assert.AreEqual(intQueue.Root.NodeValue, "one");

            intQueue.EnQueue(new Node<string>("two"));
            Assert.AreEqual(intQueue.Length, 2);
            Assert.AreEqual(intQueue.Root.NextNode.NodeValue, "two");

            intQueue.EnQueue(new Node<string>("three"));
            Assert.AreEqual(intQueue.Length, 3);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NodeValue, "three");

            intQueue.EnQueue(new Node<string>("four"));
            Assert.AreEqual(intQueue.Length, 4);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NextNode.NodeValue, "four");

            intQueue.EnQueue(new Node<string>("five"));
            Assert.AreEqual(intQueue.Length, 5);
            Assert.AreEqual(intQueue.Root.NextNode.NextNode.NextNode.NextNode.NodeValue, "five");
        }

        [TestMethod()]
        public void IntDequeueTest()
        {
            var intQueue = new lu8890.TechReviews.DataStructures.Queue<int>();
            Assert.AreEqual(intQueue.Length, 0);

            intQueue.EnQueue(new Node<int>(1));
            Assert.AreEqual(intQueue.Length, 1);
            intQueue.DeQueue();
            Assert.AreEqual(intQueue.Length, 0);

            intQueue.EnQueue(new Node<int>(2));
            intQueue.EnQueue(new Node<int>(3));
            Assert.AreEqual(intQueue.Length, 2);
            intQueue.DeQueue();
            intQueue.DeQueue();
            Assert.AreEqual(intQueue.Length, 0);

            intQueue.EnQueue(new Node<int>(4));
            intQueue.EnQueue(new Node<int>(5));
            intQueue.EnQueue(new Node<int>(6));
            intQueue.EnQueue(new Node<int>(7));
            intQueue.EnQueue(new Node<int>(8));
            Assert.AreEqual(intQueue.Length, 5);
            intQueue.DeQueue();
            Assert.AreEqual(intQueue.Length, 4);

            intQueue.EnQueue(new Node<int>(9));
            intQueue.EnQueue(new Node<int>(10));
            Assert.AreEqual(intQueue.Length, 6);
        }

        [TestMethod()]
        public void StrDequeueTest()
        {
            var strQueue = new lu8890.TechReviews.DataStructures.Queue<string>();
            Assert.AreEqual(strQueue.Length, 0);

            strQueue.EnQueue(new Node<string>("one"));
            Assert.AreEqual(strQueue.Length, 1);
            strQueue.DeQueue();
            Assert.AreEqual(strQueue.Length, 0);

            strQueue.EnQueue(new Node<string>("two"));
            strQueue.EnQueue(new Node<string>("three"));
            Assert.AreEqual(strQueue.Length, 2);
            strQueue.DeQueue();
            strQueue.DeQueue();
            Assert.AreEqual(strQueue.Length, 0);

            strQueue.EnQueue(new Node<string>("four"));
            strQueue.EnQueue(new Node<string>("five"));
            strQueue.EnQueue(new Node<string>("six"));
            strQueue.EnQueue(new Node<string>("seven"));
            strQueue.EnQueue(new Node<string>("eight"));
            Assert.AreEqual(strQueue.Length, 5);
            strQueue.DeQueue();
            Assert.AreEqual(strQueue.Length, 4);

            strQueue.EnQueue(new Node<string>("nine"));
            strQueue.EnQueue(new Node<string>("ten"));
            Assert.AreEqual(strQueue.Length, 6);

        }
    }
}