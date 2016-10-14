using System;
using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class MinimumOfThreeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var minOfThree = new MinimumOfThree();

            var minimal = minOfThree.FindMinimal(1, 2, 3);

            Assert.AreEqual(1, minimal);
        }
    }
}
