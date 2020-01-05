using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.InterviewQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviewsTests.InterviewQuestions.Tests
{
    [TestClass()]
    public class McgHealthTests
    {
        [TestMethod()]   
        public void McgHealthTest()
        {
            var tester = GetTestInstance();
            Assert.AreEqual(tester.PrintTimeInWords(0, 0), "0:0 zero o'clock");
            Assert.AreEqual(tester.PrintTimeInWords(0, 30), "0:30 half past zero");
            Assert.AreEqual(tester.PrintTimeInWords(0, 1), "0:1 one past zero");
            Assert.AreEqual(tester.PrintTimeInWords(0, 15), "0:15 quater past zero");
            Assert.AreEqual(tester.PrintTimeInWords(0, 29), "0:29 twenty-nine past zero");
            Assert.AreEqual(tester.PrintTimeInWords(0, 31), "0:31 twenty-nine to one");
            Assert.AreEqual(tester.PrintTimeInWords(0, 45), "0:45 quater to one");
            Assert.AreEqual(tester.PrintTimeInWords(0, 59), "0:59 one to one");
        }

        private McgHealth GetTestInstance()
        {
            return new McgHealth();
        }
    }
}