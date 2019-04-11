using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.InterviewQuestions;

namespace lu8890.TechReviewsTests.InterviewQuestions
{
    [TestClass]
    public class Amazon
    {
        [TestMethod]
        public void HasATriangleTest()
        {
            var testClass = new TechReviews.InterviewQuestions.Amazon();
            var output = testClass.HasATriangle(new int[] {1, 0, 2, 4, 3});
            Assert.AreEqual(true, output);

            output = testClass.HasATriangle(new int[] { });
            Assert.AreEqual(false, output);

            output = testClass.HasATriangle(new int[] {1});
            Assert.AreEqual(false, output);

            output = testClass.HasATriangle(new int[] {1, 2});
            Assert.AreEqual(false, output);

            output = testClass.HasATriangle(new int[] {3, 1, 2});
            Assert.AreEqual(true, output);

            output = testClass.HasATriangle(new int[] {3, 0, 1, 0, 2});
            Assert.AreEqual(true, output);

            output = testClass.HasATriangle(new int[] {0, 0, 3});
            Assert.AreEqual(false, output);

            output = testClass.HasATriangle(new int[] {1, 3, 1});
            Assert.AreEqual(false, output);

            output = testClass.HasATriangle(new int[] {1, 1, 1, 3, 1, 1, 0, 2});
            Assert.AreEqual(true, output);

            output = testClass.HasATriangle(new int[] {0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5});
            Assert.AreEqual(true, output);
        }
    }
}
