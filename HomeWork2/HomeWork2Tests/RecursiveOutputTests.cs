using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class RecursiveOutputTests
    {
        [TestMethod]
        public void RecursiveSumReturnsRightValue()
        {
            var recOut = new RecursiveOutput();

            int sum = recOut.RecursiveSum(1, 5);
            int sum2 = recOut.RecursiveSum(5, 1);

            Assert.AreEqual(15, sum);
            Assert.AreEqual(15, sum2);
        }
    }
}