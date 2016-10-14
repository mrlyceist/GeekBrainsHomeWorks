using System.Collections.Generic;
using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class PositiveOddSummTests
    {
        [TestMethod]
        public void FindOddsReturns1And3From1234()
        {
            var pos = new PositiveOddSumm();
            List<double> numbers = new List<double> {1, 2, 3, 4};

            List<double> foundOdds = pos.FindOdds(numbers);

            Assert.AreEqual(2, foundOdds.Count);
            Assert.IsTrue(foundOdds.Contains(1));
            Assert.IsTrue(foundOdds.Contains(3));
        }

        [TestMethod]
        public void FindOddsReturns1FromMinus1And1()
        {
            var pos = new PositiveOddSumm();
            List<double> odds = new List<double> {-1, 1};

            List<double> positives = pos.FindOdds(odds);

            Assert.AreEqual(1, positives.Count);
            Assert.IsTrue(positives.Contains(1));
        }

        [TestMethod]
        public void CalculateSumReturns4ForDefaultSet()
        {
            var pos = new PositiveOddSumm();

            List<double> defaultDoubles = new List<double>
            {
                -1,
                2,
                1,
                3,
                4
            };

            double sum = pos.CalculateSum(defaultDoubles);

            Assert.AreEqual(4, sum);
        }
    }
}