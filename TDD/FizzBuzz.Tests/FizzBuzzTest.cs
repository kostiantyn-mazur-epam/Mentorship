using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void GetResult_AnyNumberWithinRange1To100_ShouldReturnCorrespondingString()
        {
            Assert.AreEqual("1", FizzBuzz.GetResult(1));
        }

        [TestMethod]
        public void GetResult_DivisibleByThreeNumber_ShouldReturnFizzString()
        {
            Assert.AreEqual("Fizz", FizzBuzz.GetResult(3));
        }

        [TestMethod]
        public void GetResult_DivisibleByFiveNumber_ShouldReturnBuzzString()
        {
            Assert.AreEqual("Buzz", FizzBuzz.GetResult(5));
        }

        [TestMethod]
        public void GetResult_DivisibleByThreeAndFiveNumber_ShouldReturnFizzBuzzString()
        {
            Assert.AreEqual("FizzBuzz", FizzBuzz.GetResult(15));
        }

        [TestMethod]
        public void GetResult_NegativeNumber_ShouldReturnZeroString()
        {
            Assert.AreEqual("0", FizzBuzz.GetResult(-15));
        }
    }
}
