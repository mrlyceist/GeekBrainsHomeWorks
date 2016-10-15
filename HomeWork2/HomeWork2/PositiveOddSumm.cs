using System;
using System.Collections.Generic;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Класс для решения задачи "Сумма положительных нечетных чисел" (№3 в методичке)
    /// </summary>
    public class PositiveOddSumm
    {
        #region Fields
        private static List<double> _numbers;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор, необходимый для юнит-тестирования
        /// </summary>
        public PositiveOddSumm() {}

        /// <summary>
        /// Отвечает за пользовательский интерфейс
        /// </summary>
        /// <param name="prompt">Строка приветствия</param>
        public PositiveOddSumm(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine(prompt);

                Console.WriteLine("Вводите числа по одному.");
                _numbers = new List<double>() {};
                ReadNumbers();

                Console.WriteLine($"Сумма всех введенных положительных нечетных чисел - {CalculateSum(_numbers)}");

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Считывает числа, вводимые пользователем по одному
        /// </summary>
        private static void ReadNumbers()
        {
            var number = ConsoleHelper.ParseDouble();
            if (number == 0) return;
            _numbers.Add(number);
            ReadNumbers();
        }

        /// <summary>
        /// Ищет все положительные нечетные числа в наборе
        /// </summary>
        /// <param name="numbers">Набор чисел</param>
        /// <returns>Набор положительных нечетных чисел</returns>
        internal List<double> FindOdds(List<double> numbers)
        {
            return numbers.Where(n => n%2 != 0 && n > 0).ToList();
        }

        /// <summary>
        /// Считает сумму всех чисел в наборе
        /// </summary>
        /// <param name="doubles">Набор всех чисел</param>
        /// <returns>Сумма</returns>
        internal double CalculateSum(List<double> doubles)
        {
            return FindOdds(doubles).Sum();
        }
        #endregion
    }
}