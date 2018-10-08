using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringSum.Tests
{
    [TestClass]
    public class StringSumTests
    {
        [TestMethod]
        public void Sum_TwoEmptyStrings_ShouldReturnZero()
        {
            Assert.AreEqual("0", StringSum.Sum("", ""));
        }

        [TestMethod]
        public void Sum_TwoNaturalNumbers_ShouldReturnTheirSum()
        {
            Assert.AreEqual("2", StringSum.Sum("1", "1"));
        }

        [TestMethod]
        public void Sum_OneNotNaturalNumber_ShouldReturnSecondNumber()
        {
            Assert.AreEqual("1", StringSum.Sum("-1", "1"));
        }
    }
}
