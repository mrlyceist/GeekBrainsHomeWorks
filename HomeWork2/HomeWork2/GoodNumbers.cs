using System;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Класс решения задачи "Хорошие числа" (№6 в методичке)
    /// 
    /// Выполнил Алексей Дорогов
    /// </summary>
    public class GoodNumbers
    {
        #region Constructors
        /// <summary>
        /// Конструктор, необходимый для юнит-тестирования
        /// </summary>
        public GoodNumbers() { }

        /// <summary>
        /// Отвечает за пользовательский интерфейс
        /// </summary>
        /// <param name="prompt">Строка приветствия</param>
        public GoodNumbers(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(prompt);

                int start = (int) ConsoleHelper.GetDoubleFromConsole("Введите начало диапазона");
                int finish = (int) ConsoleHelper.GetDoubleFromConsole("Введите конец диапазона");

                var startTime = DateTime.Now;
                int count = FindGoodNumbers(start, finish);
                var stopTime = DateTime.Now;

                TimeSpan calculationTime = stopTime - startTime;

                Console.WriteLine($"Найдено \"Хороших\" чисел: {count}");
                Console.WriteLine($"Вычисления заняли {calculationTime.Milliseconds} милисекунд(ы)");

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Считает сумму всех цифр числа с помощью LINQ
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Сумма цифр числа</returns>
        internal int DigitSumm(int number)
        {
            return number.ToString().Sum(c => int.Parse(c.ToString()));
        }

        /// <summary>
        /// Проверяет, делится данное число на сумму своих разрядов
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Признак делимости на сумму разрядов</returns>
        internal bool Divisible(int number)
        {
            return number % DigitSumm(number) == 0;
        }

        /// <summary>
        /// Ищет все "хорошие" числа в диапазоне.
        /// </summary>
        /// <param name="start">Начало диапазона</param>
        /// <param name="finish">Конец диапазона</param>
        /// <returns>Количество "хорощих" чисел в данном диапазоне</returns>
        internal int FindGoodNumbers(int start, int finish)
        {
            int found = 0;
            for (int i = start; i < finish; i++)
            {
                if (Divisible(i)) found++;
            }
            return found;
        }
        #endregion
    }
}