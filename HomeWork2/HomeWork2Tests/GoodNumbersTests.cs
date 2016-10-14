using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class GoodNumbersTests
    {
        [TestMethod]
        public void DigitSummReturns6For123()
        {
            var gNums = new GoodNumbers();

            int sum = gNums.DigitSumm(123);

            Assert.AreEqual(6, sum);
        }

        [TestMethod]
        public void DivisibleReturnsTrueFor12()
        {
            var gNums = new GoodNumbers();

            bool divisible = gNums.Divisible(12);
            bool undivisible = gNums.Divisible(13);

            Assert.IsTrue(divisible);
            Assert.IsFalse(undivisible);
        }

        [TestMethod]
        public void FindGoodNumbersFinds11NumbersFrom1To15()
        {
            var gNums = new GoodNumbers();

            int found = gNums.FindGoodNumbers(1, 15);

            Assert.AreEqual(11, found);
        }
    }
}