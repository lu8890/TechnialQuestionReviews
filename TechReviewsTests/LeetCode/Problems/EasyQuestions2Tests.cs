using System;
using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lu8890.TechReviews.LeetCode.Problems;


namespace lu8890.TechReviewsTests.LeetCode.Problems
{
    [TestClass]
    public class EasyQuestions2Tests
    {
        [TestMethod]
        public void RemoveElementTest()
        {
            var testFunc = new EasyQuestions();
            var testcase = new int[] {3, 2, 2, 3};
            var output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(2, output);
            var result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] {2, 2});

            testcase = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(5, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 0, 1, 3, 0, 4 });

            testcase = new int[] { 3, 2, 2, 3 };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(2, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 3,3 });

            testcase = new int[] { };
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(0, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { });

            testcase = new int[] { 1};
            output = testFunc.RemoveElement(testcase, 2);
            Assert.AreEqual(1, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 1});

            testcase = new int[] { 1 };
            output = testFunc.RemoveElement(testcase, 1);
            Assert.AreEqual(0, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { });

            testcase = new int[] { 3,3,1,2,4,3,3 };
            output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(3, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] {1,2,4});

            testcase = new int[] { 3, 3, 1, 2,3, 4, 3, 3 };
            output = testFunc.RemoveElement(testcase, 3);
            Assert.AreEqual(3, output);
            result = GenerateResultIntOutput(testcase, output);
            ValidateArrayElements(result, new int[] { 1, 2, 4 });
        }

        private static void ValidateArrayElements(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        private static int[] GenerateResultIntOutput(int[] input, int count)
        {
            if ((input == null) || (input.Length < count))
                return null;

            var output = new int[count];
            for (var i = 0; i < count; i++)
                output[i] = input[i];

            return output;
        }

        [TestMethod]
        public void StrStrTest()
        {
            var testFunc = new EasyQuestions();
            Assert.AreEqual(-1, testFunc.StrStr(string.Empty, "ll"));
            Assert.AreEqual(0, testFunc.StrStr("hello", string.Empty));
            Assert.AreEqual(0, testFunc.StrStr(string.Empty, string.Empty));
            Assert.AreEqual(2, testFunc.StrStr("hello","ll"));
            Assert.AreEqual(-1, testFunc.StrStr("aaaaa", "bba"));
            Assert.AreEqual(0, testFunc.StrStr("aaaaa", "aaa"));
            Assert.AreEqual(1, testFunc.StrStr("baaaaa", "aaa"));
        }

        [TestMethod]
        public void SearchInsertTest()
        {
            var testFunc = new EasyQuestions();
            Assert.AreEqual(2, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 5));
            Assert.AreEqual(1, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 2));
            Assert.AreEqual(4, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 7));
            Assert.AreEqual(0, testFunc.SearchInsert(new int[] {1, 3, 5, 6}, 0));

        }

        [TestMethod]
        public void CountAndSayTest()
        {
            var testFunc = new EasyQuestions();
            Assert.AreEqual("0", testFunc.CountAndSay(0));
            Assert.AreEqual("1", testFunc.CountAndSay(1));
            Assert.AreEqual("11", testFunc.CountAndSay(2));
            Assert.AreEqual("21", testFunc.CountAndSay(3));
            Assert.AreEqual("1211", testFunc.CountAndSay(4));
            Assert.AreEqual("111221", testFunc.CountAndSay(5));
            Assert.AreEqual("312211", testFunc.CountAndSay(6));
            Assert.AreEqual("13112221", testFunc.CountAndSay(7));
            Assert.AreEqual("1113213211", testFunc.CountAndSay(8));
        }

        [TestMethod]
        public void MaxSubArrayTest()
        {
            var testFunc = new MaxSubArrayTestDel(new EasyQuestions().MaxSubArray);
            RunMaxSubArrayTest(testFunc);
        }

        [TestMethod]
        public void MaxSubArray2Test()
        {
            var testFunc = new MaxSubArrayTestDel(new EasyQuestions().MaxSubArray2);
            RunMaxSubArrayTest(testFunc);
        }

        [TestMethod]
        public void MaxSubArray3Test()
        {
            var testFunc = new MaxSubArrayTestDel(new EasyQuestions().MaxSubArray3);
            RunMaxSubArrayTest(testFunc);
        }

        public delegate int MaxSubArrayTestDel(int[] nums);

        private void RunMaxSubArrayTest(MaxSubArrayTestDel testFunc)
        {
            Assert.AreEqual(0, testFunc.Invoke(new int[] { }));
            Assert.AreEqual(0, testFunc.Invoke(new int[] { 0 }));
            Assert.AreEqual(-1, testFunc.Invoke(new int[] { -1 }));
            Assert.AreEqual(10, testFunc.Invoke(new int[] { -1, 10 }));
            Assert.AreEqual(5, testFunc.Invoke(new int[] { -1, 3, 2 }));
            Assert.AreEqual(6, testFunc.Invoke(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));

        }

        [TestMethod]
        public void LengthOfLastWordTest()
        {
            var testCase = new EasyQuestions();
            Assert.AreEqual(5, testCase.LengthOfLastWord("Hello World"));
            Assert.AreEqual(0, testCase.LengthOfLastWord(""));
            Assert.AreEqual(0, testCase.LengthOfLastWord(" "));
            Assert.AreEqual(6, testCase.LengthOfLastWord("How are you doing?"));
            Assert.AreEqual(6, testCase.LengthOfLastWord("How are you doing? "));
        }

        [TestMethod]
        public void PlusOneTest()
        {
            var p = new EasyQuestions();
            var testFunc = new PlusOneDel(p.PlusOne);
            PlusOneTestDriver(testFunc);
        }

        [TestMethod]
        public void PlusOneTest2()
        {
            var p = new EasyQuestions();
            var testFunc = new PlusOneDel(p.PlusOne2);
            PlusOneTestDriver(testFunc);
        }

        public delegate int[] PlusOneDel(int[] input);

        private static void PlusOneTestDriver(PlusOneDel testFunc)
        {
            
            var result = testFunc.Invoke((new int[] { 1, 2, 3 }));
            Assert.AreEqual(4, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 1 });
            Assert.AreEqual(2, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 0 });
            Assert.AreEqual(1, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 4, 2, 3, 5 });
            Assert.AreEqual(6, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1 });
            Assert.AreEqual(2, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,1, 9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 1,9,9 });
            Assert.AreEqual(0, result.LastOrDefault());

            result = testFunc.Invoke(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            Assert.AreEqual(1, result.LastOrDefault());
        }

        [TestMethod]
        public void AddBinaryTest()
        {
            var p = new EasyQuestions();
            Assert.AreEqual("100", p.AddBinary("1", "11"));
            Assert.AreEqual("10101", p.AddBinary("1010", "1011"));
            Assert.AreEqual("110", p.AddBinary("11", "11"));
            Assert.AreEqual("11", p.AddBinary("11", ""));
            Assert.AreEqual("11", p.AddBinary("", "11"));
            Assert.AreEqual("0", p.AddBinary("0", "0"));
            Assert.AreEqual("10", p.AddBinary("1", "1"));
        }

        [TestMethod]
        public void MySqrtTest()
        {
            var p = new EasyQuestions();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt);
        }

        [TestMethod]
        public void MySqrtTest2()
        {
            var p = new EasyQuestions();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt2);
        }

        [TestMethod]
        public void MySqrtTest3()
        {
            var p = new EasyQuestions();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt3);
        }

        [TestMethod]
        public void MySqrtTest4()
        {
            var p = new EasyQuestions();
            MySqrtDel testFunc = new MySqrtDel(p.MySqrt4);
        }



        public delegate int MySqrtDel(int x);
        private static void RunMySqrtTest(MySqrtDel testFunc)
        {
            Assert.AreEqual(0, testFunc.Invoke(0));
            Assert.AreEqual(1, testFunc.Invoke(1));
            Assert.AreEqual(2, testFunc.Invoke(4));
            Assert.AreEqual(2, testFunc.Invoke(8));
        }
    }
}
