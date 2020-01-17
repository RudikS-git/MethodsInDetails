using NUnit.Framework;
using MethodsInDetails;

namespace MethodsInDetailsTests
{
    public class Tests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string ConvertTests(double num)
        {
            return DoubleHelper.Convert(num);
        }

        [TestCase(12, 18, ExpectedResult = 6)]
        [TestCase(40, 25, ExpectedResult = 5)]
        [TestCase(0, 25, ExpectedResult = 25)]
        [TestCase(13, 39, ExpectedResult = 13)]
        [TestCase(0, -15, ExpectedResult = 15)]
        [TestCase(10, 0, ExpectedResult = 10)]
        [TestCase(-13, 63, ExpectedResult = 1)]
        [TestCase(1251, 6621, ExpectedResult = 3)]
        [TestCase(11, 15, ExpectedResult = 1)]
        [TestCase(1251, 6621, ExpectedResult = 3)]
        [TestCase(19, 57, ExpectedResult = 19)]
        public int GCDTestsTwo(int firstNum, int secondNum)
        {
            return AlgorithmGCD.SearchViaRemainder(firstNum, secondNum, out int mSec);
        }

        [TestCase(324, 111, 432, ExpectedResult = 3)]
        [TestCase(24, 12, 2, ExpectedResult = 2)]
        [TestCase(64, 8, 4, ExpectedResult = 4)]
        public int GCDTestsThree(int firstNum, int secondNum, int thirdNum)
        {
            return AlgorithmGCD.SearchViaRemainder(firstNum, secondNum, thirdNum, out int mSec);
        }

        [TestCase(new int[] { 534, 134, 576, 1316 }, ExpectedResult = 2)]
        [TestCase(new int[] { 3155, 1335, 65, 765 }, ExpectedResult = 5)]
        [TestCase(new int[] { 64, 28, 56, 258 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 137 }, ExpectedResult = 1)]
        public int GCDTestsArray(params int [] array)
        {
            return AlgorithmGCD.SearchViaRemainder(out int mSec, array);
        }

        [TestCase(12, 18, ExpectedResult = 6)]
        [TestCase(40, 25, ExpectedResult = 5)]
        [TestCase(0, 25, ExpectedResult = 25)]
        [TestCase(13, 39, ExpectedResult = 13)]
        [TestCase(0, -15, ExpectedResult = 15)]
        [TestCase(10, 0, ExpectedResult = 10)]
        [TestCase(-13, 63, ExpectedResult = 1)]
        [TestCase(1251, 6621, ExpectedResult = 3)]
        [TestCase(11, 15, ExpectedResult = 1)]
        [TestCase(1251, 6621, ExpectedResult = 3)]
        [TestCase(19, 57, ExpectedResult = 19)]

        public int GCDBinaryTestsTwo(int firstNum, int secondNum)
        {
            return AlgorithmGCD.SearchViaBinary(firstNum, secondNum, out int mSec);
        }

        [TestCase(324, 111, 432, ExpectedResult = 3)]
        [TestCase(24, 12, 2, ExpectedResult = 2)]
        [TestCase(64, 8, 4, ExpectedResult = 4)]
        public int GCDBinaryTestsThree(int firstNum, int secondNum, int thirdNum)
        {
            return AlgorithmGCD.SearchViaBinary(firstNum, secondNum, thirdNum, out int mSec);
        }

        [TestCase(new int[] { 534, 134, 576, 1316 }, ExpectedResult = 2)]
        [TestCase(new int[] { 3155, 1335, 65, 765 }, ExpectedResult = 5)]
        [TestCase(new int[] { 64, 28, 56, 258 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 137 }, ExpectedResult = 1)]
        public int GCDBinaryTestsArray(params int[] array)
        {
            return AlgorithmGCD.SearchViaBinary(out int mSec, array);
        }

        [TestCase(5, false)]
        [TestCase("test", false)]
        [TestCase(5.53, false)]
        [TestCase(true, false)]
        public void NullAbleTests<T>(T n, bool expectedIsNull)
        {
            Assert.AreEqual(expectedIsNull, n.IsNull());
        }
        
        [Test]
        public void NullAbleIntTests()
        {
            int? num = null;
            Assert.AreEqual(true, num.IsNull());
        }

        [Test]
        public void NullAbleBoolTests()
        {
            bool? num = null;
            Assert.AreEqual(true, num.IsNull());
        }

        [Test]
        public void NullAbleStringTests()
        {
            string? num = null;
            Assert.AreEqual(true, num.IsNull());
        }
    }
}