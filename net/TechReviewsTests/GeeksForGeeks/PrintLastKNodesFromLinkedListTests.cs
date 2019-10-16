using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.GeeksForGeeks;

namespace lu8890.TechReviewsTests.GeeksForGeeks
{
    [TestClass()]
    public class PrintLastKNodesFromLinkedListTests
    {
        [TestMethod()]
        public void PrintLinkedListKNodesFromTheEndTest()
        {
            var test = new PrintLastKNodesFromLinkedList();
            test.PrintLinkedListKNodesFromTheEnd(new int[]{1,2}, 2 );
            Assert.AreEqual(test.OutputBuilder.ToString().Trim(),
                "2 1");

            test.PrintLinkedListKNodesFromTheEnd(new int[] { 1, 2, 3, 4, 5 }, 2);
            Assert.AreEqual(test.OutputBuilder.ToString().Trim(),
                "5 4");

            test.PrintLinkedListKNodesFromTheEnd(new int[] { 3, 10,6, 9, 12, 2, 8 }, 4);
            Assert.AreEqual(test.OutputBuilder.ToString().Trim(),
                "8 2 12 9");
        }
    }
}