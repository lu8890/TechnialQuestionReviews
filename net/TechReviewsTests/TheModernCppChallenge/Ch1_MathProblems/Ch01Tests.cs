using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.TheModernCppChallenge.Ch1_MathProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.TheModernCppChallenge.Ch1_MathProblems.Tests
{
    [TestClass()]
    public class Ch01Tests
    {
        [TestMethod()]
        public void SumOfNaturalNumsDivisibleBy3And5Test()
        {
            var TestRunner = GetCh01Instance();
            var result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(0);
            Assert.AreEqual(0, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(1);
            Assert.AreEqual(0, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(2);
            Assert.AreEqual(0, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(3);
            Assert.AreEqual(3, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(4);
            Assert.AreEqual(3, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(5);
            Assert.AreEqual(8, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(6);
            Assert.AreEqual(14, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(7);
            Assert.AreEqual(14, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(8);
            Assert.AreEqual(14, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(9);
            Assert.AreEqual(23, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(10);
            Assert.AreEqual(33, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(11);
            Assert.AreEqual(33, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(12);
            Assert.AreEqual(45, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(13);
            Assert.AreEqual(45, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(14);
            Assert.AreEqual(45, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(15);
            Assert.AreEqual(60, result);
            result = TestRunner.SumOfNaturalNumsDivisibleBy3And5(16);
            Assert.AreEqual(60, result);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindGreatestCommonDivisorExceptionTest()
        {
            var TestRunner = GetCh01Instance();
            TestRunner.FindGreatestCommonDivisor(1,0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindGreatestCommonDivisorException2Test()
        {
            var TestRunner = GetCh01Instance();
            TestRunner.FindGreatestCommonDivisor(0, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindGreatestCommonDivisorException3Test()
        {
            var TestRunner = GetCh01Instance();
            TestRunner.FindGreatestCommonDivisor(0, 0);
        }

        [TestMethod()]
        public void FindGreatestCommonDivisorTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.FindGreatestCommonDivisor(1, 1);
            Assert.AreEqual(1, Result);
            Result = TestRunner.FindGreatestCommonDivisor(2, 1);
            Assert.AreEqual(1, Result);
            Result = TestRunner.FindGreatestCommonDivisor(1, 2);
            Assert.AreEqual(1, Result);
            Result = TestRunner.FindGreatestCommonDivisor(2, 2);
            Assert.AreEqual(2, Result);
            Result = TestRunner.FindGreatestCommonDivisor(2, 4);
            Assert.AreEqual(2, Result);
            Result = TestRunner.FindGreatestCommonDivisor(4, 2);
            Assert.AreEqual(2, Result);
            Result = TestRunner.FindGreatestCommonDivisor(16, 256);
            Assert.AreEqual(16, Result);
            Result = TestRunner.FindGreatestCommonDivisor(256, 16);
            Assert.AreEqual(16, Result);
            Result = TestRunner.FindGreatestCommonDivisor(2, -2);
            Assert.AreEqual(2, Result);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindLeastCommonMultipleExceptionTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 2, 0 });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindLeastCommonMultipleException2Test()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.FindLeastCommonMultiple(new List<int>() { -1, 0, 13 });
        }

        [TestMethod()]
        public void FindLeastCommonMultipleTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 2, 2 });
            Assert.AreEqual(2, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 12, 24 });
            Assert.AreEqual(24, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 3, 7 });
            Assert.AreEqual(21, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 2, 5 });
            Assert.AreEqual(10, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 3, 13 });
            Assert.AreEqual(39, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 9, 24 });
            Assert.AreEqual(72, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>());
            Assert.AreEqual(0, Result);
            Result = TestRunner.FindLeastCommonMultiple(null);
            Assert.AreEqual(0, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() {3, 8, 24 });
            Assert.AreEqual(24, Result);
            Result = TestRunner.FindLeastCommonMultiple(new List<int>() { 2, 3, 6 });
            Assert.AreEqual(6, Result);
        }



        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LargestPrimeNumberExceptionTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.LargestPrimeNumber(-1);
        }

        [TestMethod()]
        public void LargestPrimeNumberTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.LargestPrimeNumber(0);
            Assert.AreEqual(null, Result);
            Result = TestRunner.LargestPrimeNumber(1);
            Assert.AreEqual(null, Result);
            Result = TestRunner.LargestPrimeNumber(2);
            Assert.AreEqual(2, Result);
            Result = TestRunner.LargestPrimeNumber(3);
            Assert.AreEqual(3, Result);
            Result = TestRunner.LargestPrimeNumber(4);
            Assert.AreEqual(3, Result);
            Result = TestRunner.LargestPrimeNumber(5);
            Assert.AreEqual(5, Result);
            Result = TestRunner.LargestPrimeNumber(6);
            Assert.AreEqual(5, Result);
            Result = TestRunner.LargestPrimeNumber(7);
            Assert.AreEqual(7, Result);
            Result = TestRunner.LargestPrimeNumber(8);
            Assert.AreEqual(7, Result);
            Result = TestRunner.LargestPrimeNumber(9);
            Assert.AreEqual(7, Result);
            Result = TestRunner.LargestPrimeNumber(10);
            Assert.AreEqual(7, Result);
            Result = TestRunner.LargestPrimeNumber(11);
            Assert.AreEqual(11, Result);
            Result = TestRunner.LargestPrimeNumber(12);
            Assert.AreEqual(11, Result);
            Result = TestRunner.LargestPrimeNumber(13);
            Assert.AreEqual(13, Result);
            Result = TestRunner.LargestPrimeNumber(14);
            Assert.AreEqual(13, Result);
            Result = TestRunner.LargestPrimeNumber(15);
            Assert.AreEqual(13, Result);
            Result = TestRunner.LargestPrimeNumber(16);
            Assert.AreEqual(13, Result);
            Result = TestRunner.LargestPrimeNumber(17);
            Assert.AreEqual(17, Result);
            Result = TestRunner.LargestPrimeNumber(18);
            Assert.AreEqual(17, Result);
            Result = TestRunner.LargestPrimeNumber(19);
            Assert.AreEqual(19, Result);
            Result = TestRunner.LargestPrimeNumber(20);
            Assert.AreEqual(19, Result);
            Result = TestRunner.LargestPrimeNumber(199);
            Assert.AreEqual(199, Result);
            Result = TestRunner.LargestPrimeNumber(200);
            Assert.AreEqual(199, Result);
            Result = TestRunner.LargestPrimeNumber(195);
            Assert.AreEqual(193, Result);

        }


        [TestMethod()]
        public void GetSexyPrimePairsTest()
        {
            var TestRunner = GetCh01Instance();
            var Result = TestRunner.GetSexyPrimePairs(3);
            CollectionAssert.AreEqual(new Dictionary<int, int>(), Result);
            Result = TestRunner.GetSexyPrimePairs(11);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11} }, Result);
            Result = TestRunner.GetSexyPrimePairs(12);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11 } }, Result);
            Result = TestRunner.GetSexyPrimePairs(13);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11 }, {7, 13 } }, Result);
            Result = TestRunner.GetSexyPrimePairs(14);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11 }, { 7, 13 } }, Result);
            Result = TestRunner.GetSexyPrimePairs(17);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11 }, { 7, 13 }, { 11, 17 } }, Result);
            Result = TestRunner.GetSexyPrimePairs(19);
            CollectionAssert.AreEqual(new Dictionary<int, int>() { { 5, 11 }, { 7, 13 }, { 11, 17 }, { 13, 19 } }, Result);
        }

        private Ch01 GetCh01Instance()
        {
            return new Ch01();
        }
    }
}