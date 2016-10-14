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
            List<int> numbers = new List<int> {1, 2, 3, 4};

            List<int> foundOdds = pos.FindOdds(numbers);

            Assert.AreEqual(2, foundOdds.Count);
            Assert.IsTrue(foundOdds.Contains(1));
            Assert.IsTrue(foundOdds.Contains(3));
        }

        [TestMethod]
        public void FindOddsReturns1FromMinus1And1()
        {
            var pos = new PositiveOddSumm();
            List<int> odds = new List<int> {-1, 1};

            List<int> positives = pos.FindOdds(odds);

            Assert.AreEqual(1, positives.Count);
            Assert.IsTrue(positives.Contains(1));
        }
    }
}