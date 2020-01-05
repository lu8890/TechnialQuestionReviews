using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.InterviewQuestions;

namespace lu8890.TechReviewsTests.InterviewQuestions.Tests
{
    [TestClass()]
    public class PanoptoTests
    {
        [TestMethod()]
        public void RotateMatrixBy90DegressTest()
        {
            var p = new Panopto();
            var testCase = new int[,]
            {
                {1, 2, 3}
            };
            var result = p.RotateMatrixBy90Degress(testCase);
            Assert.AreEqual(result.GetLongLength(0), testCase.GetLongLength(1));
            Assert.AreEqual(result.GetLongLength(1), testCase.GetLongLength(0));
            var zz = GetMatrixValueInString(result);
            Assert.AreEqual(zz, "1 2 3");

            testCase = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            result = p.RotateMatrixBy90Degress(testCase);
            Assert.AreEqual(result.GetLongLength(0), testCase.GetLongLength(1));
            Assert.AreEqual(result.GetLongLength(1), testCase.GetLongLength(0));
            zz = GetMatrixValueInString(result);
            Assert.AreEqual(zz, "4 1 5 2 6 3");
            
            testCase = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            result = p.RotateMatrixBy90Degress(testCase);
            Assert.AreEqual(result.GetLongLength(0), testCase.GetLongLength(1));
            Assert.AreEqual(result.GetLongLength(1), testCase.GetLongLength(0));
            zz = GetMatrixValueInString(result);
            Assert.AreEqual(zz, "7 4 1 8 5 2 9 6 3");
        }

        private string GetMatrixValueInString(int[,] input)
        {
            var sb = new StringBuilder();

            foreach (var m in input)
            {
                sb.Append(m + " ");
            }

            return sb.ToString().Trim();
        }
    }
}