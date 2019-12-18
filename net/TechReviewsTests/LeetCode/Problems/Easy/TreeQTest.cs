using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using lu8890.TechReviews.DataStructures;
using TreeNode = lu8890.TechReviews.LeetCode.Models.TreeNode;
using lu8890.TechReviews.LeetCode.Problems.Easy;
using lu8890.TechReviews.LeetCode.Models;
using Tree = lu8890.TechReviews.LeetCode.Models.Tree;

namespace lu8890.TechReviewsTests.LeetCode.Problems.Easy
{
    [TestClass]
    public class TreeQTest
    {
        [TestMethod]
        public void IsSameTreeTest()
        {
            var testClass = new TreeQ();
            var input1 = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
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
        public void IsSymeticTreeTest()
        {
            var testClass = new TreeQ();
            var input1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) };
            Assert.AreEqual(true, testClass.IsSymmetric(input1), "Testcase 01 Failed");

            input1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3)} };
            Assert.AreEqual(false, testClass.IsSymmetric(input1), "Testcase 02 Failed");

            input1 = new TreeNode(0) { right = new TreeNode(1), left = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3) } };
            Assert.AreEqual(false, testClass.IsSymmetric(input1), "Testcase 03 Failed");

            input1 = new TreeNode(0) { right = new TreeNode(1), left = new TreeNode(2) };
            Assert.AreEqual(false, testClass.IsSymmetric(input1), "Testcase 04 Failed");
        }

        [TestMethod]
        public void MaxDepthTest()
        {
            var testClass = new TreeQ();
            TreeNode input1 = null;
            Assert.AreEqual(0, testClass.MaxDepth(input1), "Testcase 01 Failed");

            input1 = new TreeNode(0);
            Assert.AreEqual(1, testClass.MaxDepth(input1), "Testcase 02 Failed");

            input1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) };
            Assert.AreEqual(2, testClass.MaxDepth(input1), "Testcase 03 Failed");

            input1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3) } };
            Assert.AreEqual(3, testClass.MaxDepth(input1), "Testcase 04 Failed");

            input1 = new TreeNode(0) { right = new TreeNode(1), left = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3) } };
            Assert.AreEqual(3, testClass.MaxDepth(input1), "Testcase 05 Failed");
        }

        [TestMethod]
        public void LevelOrderBottomTest()
        {
            var TestClass = new TreeQ();
            var input1 = new TreeNode(0) { left = new TreeNode(1), right = new TreeNode(1) };
            var output = TestClass.LevelOrderBottom(input1);
            var oCol = output.SelectMany(x => x).ToList();
            var expectedOutput = new List<int>() {1,1,0};
            CollectionAssert.AreEqual(expectedOutput, oCol, "Testcase 01 Failed");

            TestClass.treeValueCol = new Dictionary<int, IList<int>>();
            input1 = new TreeNode(0) { right = new TreeNode(1), left = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3) } };
            output = TestClass.LevelOrderBottom(input1);
            oCol = oCol = output.SelectMany(x => x).ToList();
            expectedOutput = new List<int>() { 3, 3, 1, 1, 0 };
            CollectionAssert.AreEqual(expectedOutput, oCol, "Testcase 02 Failed");


            TestClass.treeValueCol = new Dictionary<int, IList<int>>();
            input1 = new TreeNode(0) { right = new TreeNode(1) { left = new TreeNode(4), right = new TreeNode(5) }, left = new TreeNode(1) { left = new TreeNode(3), right = new TreeNode(3) } };
            output = TestClass.LevelOrderBottom(input1);
            oCol = oCol = output.SelectMany(x => x).ToList();
            expectedOutput = new List<int>() { 3, 3, 4, 5, 1, 1, 0};
            CollectionAssert.AreEqual(expectedOutput, oCol, "Testcase 03 Failed");

        }

        [TestMethod]
        public void SortedArrayToBSTTest()
        {
            var testclass = new TreeQ();
            var input = new int[] { -10, -3, 0, 5, 9};
            var output = testclass.SortedArrayToBST(input);
        }
    }

}
