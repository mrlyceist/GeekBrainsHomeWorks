using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class NumberOfDigitsTests
    {
        [TestMethod]
        public void CountDigitsReturns3For666()
        {
            var num = new NumberOfDigits();

            int count = num.CountDigits(666);

            Assert.AreEqual(3, count);
        }
    }
}