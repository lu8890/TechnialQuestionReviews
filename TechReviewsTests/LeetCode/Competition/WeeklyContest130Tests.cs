using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.LeetCode.Competition;


namespace lu8890.TechReviewsTests.LeetCode.Competition
{
    /// <summary>
    /// Summary description for WeeklyContest130Tests
    /// </summary>
    [TestClass]
    public class WeeklyContest130Tests
    {
        public WeeklyContest130Tests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PrefixesDivBy5Test()
        {
            var test = new WeeklyContest130();
            RunPrefixDivBy5Tests(test.PrefixesDivBy5);
        }

        [TestMethod]
        public void PrefixDivBy5_2Test()
        {
            var test = new WeeklyContest130();
            RunPrefixDivBy5Tests(test.PrefixesDivBy5_2);
        }

        [TestMethod]
        public void PrefixDivBy5_3Test()
        {
            var test = new WeeklyContest130();
            RunPrefixDivBy5Tests(test.PrefixesDivBy5_3);
        }
        private void RunPrefixDivBy5Tests(PreFixDivBy5Del testFunc)
        {     
            var result = testFunc(new int[] {0, 1, 1});
            CollectionAssert.AreEqual(new List<bool>() { true, false, false }, result.ToList(), "Failed Testcase 01");
            result = testFunc(new int[] { 1, 1, 1 });
            CollectionAssert.AreEqual(new List<bool>() { false, false, false }, result.ToList(), "Failed Testcase 02");
            result = testFunc(new int[] {0, 1, 1, 1, 1, 1});
            CollectionAssert.AreEqual(new List<bool>() { true, false, false, false,true, false }, result.ToList(), "Failed Testcase 03");
            result = testFunc(new int[] { 1, 1, 1, 0, 1 });
            CollectionAssert.AreEqual(new List<bool>() { false, false, false, false, false }, result.ToList(), "Failed Testcase 04");
            result = testFunc(new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1 });
            CollectionAssert.AreEqual(new List<bool>() { false, false, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, false, false, false }, result.ToList(), "Failed Testcase 05");
            result = testFunc(new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 });
            CollectionAssert.AreEqual(new List<bool>() { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, true, true, false }, result.ToList(), "Failed Testcase 06");
            result = testFunc(new int[] {1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0});
            CollectionAssert.AreEqual(new List<bool>() { false, false, true, false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false, false, true, false, false, true, true, true, true, true, true, true, false, false, true, false, false, false, false, true, true }, result.ToList(), "Failed Testcase 07");
        }

        private delegate IList<bool> PreFixDivBy5Del(int[] A);
    }
}
