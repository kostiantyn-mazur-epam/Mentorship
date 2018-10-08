using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ShouldReturnZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestMethod]
        public void Add_SingleNumber_ShouldReturnNumber()
        {
            Assert.AreEqual(1, StringCalculator.Add("1"));
        }

        [TestMethod]
        public void Add_PairOfNumbers_ShouldReturnSumOfNumbers()
        {
            Assert.AreEqual(8, StringCalculator.Add("5,3"));
        }

        [TestMethod]
        public void Add_AnyNumberOfNumbers_ShouldReturnSumOfNumbers()
        {
            Assert.AreEqual(11, StringCalculator.Add("5,3,2,1"));
        }

        [TestMethod]
        public void Add_AnyNumberOfNumbersWithNewlineDelimiter_ShouldReturnSumOfNumbers()
        {
            var inputString = string.Format("5{0}3,2,1", Environment.NewLine);
            Assert.AreEqual(11, StringCalculator.Add(inputString));
        }

        [TestMethod]
        public void Add_AnyNumberOfNumbersWithWrongNewlineDelimiter_ShouldThrow()
        {
            var inputString = string.Format("5{0},2,1", Environment.NewLine);
            Assert.ThrowsException<ArgumentException>(() => StringCalculator.Add(inputString));
        }

        [TestMethod]
        public void Add_NumbersWithDelimiterStringAtBeginning_ShouldReturnSumOfNumbers()
        {
            var inputString = string.Format("//;{0}5;3;2;1", Environment.NewLine);
            Assert.AreEqual(11, StringCalculator.Add(inputString));
        }

        [TestMethod]
        public void Add_NegativeNumbers_ShouldThrow()
        {
            var inputString = string.Format("-5,3,-2,1", Environment.NewLine);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => StringCalculator.Add(inputString));
        }
    }
}
