using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviewsTests.DataStructures
{
    [TestClass()]
    public class LinkedListTests
    {
        [TestMethod()]
        public void LinkedListTestInt()
        {
            var intLinkedList = new lu8890.TechReviews.DataStructures.LinkedList<int>();
            Assert.AreEqual(intLinkedList.Length, 0);

            intLinkedList.AddANode(new Node<int>(3));
            Assert.AreEqual(intLinkedList.Length, 1);          
            Assert.AreEqual(intLinkedList.Root.NodeValue, 3);

            intLinkedList.AddANode(new Node<int>(1));
            Assert.AreEqual(intLinkedList.Length, 2);
            Assert.AreEqual(intLinkedList.Root.NextNode.NodeValue, 1);

            intLinkedList.AddANode(new Node<int>(10));
            Assert.AreEqual(intLinkedList.Length, 3);
            Assert.AreEqual(intLinkedList.Root.NextNode.NextNode.NodeValue, 10);

        }

        [TestMethod()]
        public void LinkedListTestStr()
        {
            var strLinkedList = new lu8890.TechReviews.DataStructures.LinkedList<string>();
            Assert.AreEqual(strLinkedList.Length, 0);

            strLinkedList.AddANode(new Node<string>("my"));
            Assert.AreEqual(strLinkedList.Length, 1);
            Assert.AreEqual(strLinkedList.Root.NodeValue, "my");

            strLinkedList.AddANode(new Node<string>("name"));
            Assert.AreEqual(strLinkedList.Length, 2);
            Assert.AreEqual(strLinkedList.Root.NextNode.NodeValue, "name");

            strLinkedList.AddANode(new Node<string>("is"));
            Assert.AreEqual(strLinkedList.Length, 3);
            Assert.AreEqual(strLinkedList.Root.NextNode.NextNode.NodeValue, "is");
        }

        [TestMethod()]
        public void LinkedListIntRemoveNodeByPostion()
        {
            var strLinkedList = new lu8890.TechReviews.DataStructures.LinkedList<int>();
            strLinkedList.AddANode(new Node<int>(3));
            Assert.AreEqual(strLinkedList.Length, 1);
            strLinkedList.RemoveNodeByPosition(1);
            Assert.AreEqual(strLinkedList.Length, 0);
            strLinkedList.AddANode(new Node<int>(3));
            strLinkedList.AddANode(new Node<int>(4));
            Assert.AreEqual(strLinkedList.Length, 2);
            strLinkedList.RemoveNodeByPosition(2);
            Assert.AreEqual(strLinkedList.Length, 1);
            strLinkedList.RemoveNodeByPosition(1);
            Assert.AreEqual(strLinkedList.Length, 0);
            strLinkedList.AddANode(new Node<int>(3));
            strLinkedList.AddANode(new Node<int>(4));
            strLinkedList.AddANode(new Node<int>(5));
            strLinkedList.AddANode(new Node<int>(6));
            Assert.AreEqual(strLinkedList.Length, 4);
            strLinkedList.RemoveNodeByPosition(2);
            Assert.AreEqual(strLinkedList.Length, 3);
            strLinkedList.AddANode(new Node<int>(7));
            strLinkedList.AddANode(new Node<int>(8));
            strLinkedList.AddANode(new Node<int>(9));
            strLinkedList.AddANode(new Node<int>(10));
            Assert.AreEqual(strLinkedList.Length, 7);
            strLinkedList.RemoveNodeByPosition(7);
            Assert.AreEqual(strLinkedList.Length, 6);
        }

        [TestMethod()]
        public void LinkedListStrRemoveNodeByPostion()
        {
            var strLinkedList = new lu8890.TechReviews.DataStructures.LinkedList<string>();
            strLinkedList.AddANode(new Node<string>("One"));
            Assert.AreEqual(strLinkedList.Length, 1);
            strLinkedList.RemoveNodeByPosition(1);
            Assert.AreEqual(strLinkedList.Length, 0);
            strLinkedList.AddANode(new Node<string>("two"));
            strLinkedList.AddANode(new Node<string>("three"));
            Assert.AreEqual(strLinkedList.Length, 2);
            strLinkedList.RemoveNodeByPosition(2);
            Assert.AreEqual(strLinkedList.Length, 1);
            strLinkedList.RemoveNodeByPosition(1);
            Assert.AreEqual(strLinkedList.Length, 0);
            strLinkedList.AddANode(new Node<string>("four"));
            strLinkedList.AddANode(new Node<string>("five"));
            strLinkedList.AddANode(new Node<string>("six"));
            strLinkedList.AddANode(new Node<string>("seven"));
            Assert.AreEqual(strLinkedList.Length, 4);
            strLinkedList.RemoveNodeByPosition(2);
            Assert.AreEqual(strLinkedList.Length, 3);
            strLinkedList.AddANode(new Node<string>("eight"));
            strLinkedList.AddANode(new Node<string>("nine"));
            strLinkedList.AddANode(new Node<string>("ten"));
            strLinkedList.AddANode(new Node<string>("eleven"));
            Assert.AreEqual(strLinkedList.Length, 7);
            strLinkedList.RemoveNodeByPosition(7);
            Assert.AreEqual(strLinkedList.Length, 6);
        }
    }
}