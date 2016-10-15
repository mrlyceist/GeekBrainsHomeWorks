using System;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Класс для решения задачи "Рекурсивны вывод" (№ 7 в методичке)
    /// 
    /// Выполнил Алексей Дорогов
    /// </summary>
    internal class RecursiveOutput
    {
        #region Constructors
        /// <summary>
        /// Конструктор, необходимый для юнит-тестирования
        /// </summary>
        public RecursiveOutput() { }

        /// <summary>
        /// Отвечает за пользовательский интерфейс
        /// </summary>
        /// <param name="prompt">Строка приветствия</param>
        public RecursiveOutput(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(prompt);

                int start = (int)ConsoleHelper.GetDoubleFromConsole("Введите начало диапазона");
                int finish = (int)ConsoleHelper.GetDoubleFromConsole("Введите конец диапазона");

                Console.WriteLine(RecursivePrint(start, finish));
                Console.WriteLine($"Сумма чисел в диапазоне: {RecursiveSum(start, finish)}");

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Рекурсивно выводит все целые числа в диапазоне
        /// </summary>
        /// <param name="start">Начало диапазона</param>
        /// <param name="finish">Конец диапазона</param>
        /// <returns>Строка, содержащая все числа в диапазоне</returns>
        private string RecursivePrint(int start, int finish)
        {
            if (Math.Abs(finish - start) < 0.01) return start.ToString();
            if (start < finish) return $"{start} {RecursivePrint(start + 1, finish)}";
            return $"{start} {RecursivePrint(start - 1, finish)}";
        }

        /// <summary>
        /// Рекурсивно считает сумму всех чисел в диапазоне
        /// </summary>
        /// <param name="start">Начало диапазона</param>
        /// <param name="finish">Конец диапазона</param>
        /// <returns>Сумма</returns>
        internal int RecursiveSum(int start, int finish)
        {
            if (start == finish) return start;
            if (start < finish) return start + RecursiveSum(start+1, finish);
            return start + RecursiveSum(start - 1, finish);
        }
        #endregion
    }
}