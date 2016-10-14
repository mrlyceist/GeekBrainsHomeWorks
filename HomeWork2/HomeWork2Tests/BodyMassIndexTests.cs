using System;
using HomeWork2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork2Tests
{
    [TestClass]
    public class BodyMassIndexTests
    {
        [TestMethod]
        public void IndexIsCalculatedCorrectly()
        {
            var bmi = new BodyMassIndex();

            var height = 1.7;
            var weight = 60;
            double index = bmi.GetIndex(weight, height);

            Assert.AreEqual(20.8, Math.Round(index, 1));
        }

        [TestMethod]
        public void IndexCorrectsCantimeters()
        {
            var bmi = new BodyMassIndex();

            var height = 170;
            var weight = 60;
            double index = bmi.GetIndex(weight, height);

            Assert.AreEqual(20.8, Math.Round(index, 1));
        }

        [TestMethod]
        public void InterpreteReturnsRightStringsForDifferentBmis()
        {
            var bmi = new BodyMassIndex();

            var normal = 20;
            var lessThenNormal = 16.5;
            var moreThenNormal = 31;

            string normalResult = bmi.Interprete(normal);
            string littleResult = bmi.Interprete(lessThenNormal);
            string muchResult = bmi.Interprete(moreThenNormal);

            Assert.AreEqual("Ваша масса в норме", normalResult);
            Assert.AreEqual("Недостаточная масса тела", littleResult);
            Assert.AreEqual("Ожирение первой степени", muchResult);
        }

        [TestMethod]
        public void NormalMassReturns63For170()
        {
            var bmi = new BodyMassIndex();

            var height = 1.7;

            int weight = bmi.CalculateNormalMass(height);

            Assert.AreEqual(63, weight);
        }

        [TestMethod]
        public void AdviceAdvises()
        {
            var bmi = new BodyMassIndex();

            var weight = 100;
            var w2 = 43;
            var w3 = 60;
            var height = 1.7;

            string advice1 = bmi.Advice(weight, height);
            string advice2 = bmi.Advice(w2, height);
            string advice3 = bmi.Advice(w3, height);

            Assert.AreEqual("Вам не помешает сбросить 37 кг.", advice1);
            Assert.AreEqual("Вам не помешает набрать 20 кг.", advice2);
            Assert.AreEqual("Так держать!", advice3);

        }
    }
}