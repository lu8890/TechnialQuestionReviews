using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.DataStructures;

namespace lu8890.TechReviewsTests.DataStructures
{
    [TestClass()]
    public class TreeTests
    {
        [TestMethod()]
        public void TreeTest()
        {
            var testInput1 = new[] {1, 2, 5, 22, -3, 5};
            var tree1 = new Tree(testInput1);
            tree1.PrintTreePreOrder(tree1.Root);
            Assert.AreEqual(tree1.Output.ToString().Trim(), "5 1 -3 2 22 5");
            Console.WriteLine("------------------------------------");
            tree1.Output = new StringBuilder();
            tree1.PrintTreeInOrder(tree1.Root);
            Assert.AreEqual(tree1.Output.ToString().Trim(), "1 -3 2 5 22 5");
            Console.WriteLine("------------------------------------");
            tree1.Output = new StringBuilder();
            tree1.PrintTreePostOrder(tree1.Root);
            Assert.AreEqual(tree1.Output.ToString().Trim(), "1 -3 2 22 5 5");
        }
    }
}