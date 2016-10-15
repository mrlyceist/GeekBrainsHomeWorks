using System;
using System.Collections.Generic;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Класс решения задачи "Минимальное из трех" (№1 в методичке)
    /// 
    /// Выполнил Алексей Дорогов
    /// </summary>
    public class MinimumOfThree
    {
        #region Constructors
        /// <summary>
        /// Конструктор, необходимый для юнит-тестирования
        /// </summary>
        public MinimumOfThree() { }

        /// <summary>
        /// Отвечает за пользовательский интерфейс
        /// </summary>
        /// <param name="prompt">Строка приветствия</param>
        public MinimumOfThree(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(prompt);

                double first  = ConsoleHelper.GetDoubleFromConsole("Введите первое число");
                double second = ConsoleHelper.GetDoubleFromConsole("Введите второе число");
                double third  = ConsoleHelper.GetDoubleFromConsole("Введите третье число");

                Console.WriteLine($"Минимальное из введенных: {FindMinimal(first, second, third)}");

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Возвращает наименьшее из трех чисел
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns></returns>
        internal double FindMinimal(double first, double second, double third)
        {
            return new List<double> {first, second, third}.Min();
        }
        #endregion
    }
}