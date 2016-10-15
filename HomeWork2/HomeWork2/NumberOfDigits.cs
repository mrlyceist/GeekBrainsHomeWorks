using System;
using System.Globalization;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Задача "Сумма разрядов" (№2 в методичке)
    /// 
    /// Выполнил Алексей Дорогов
    /// </summary>
    public class NumberOfDigits
    {
        #region Constructors
        /// <summary>
        /// Конструктор, необходимый для юнит-тестирования
        /// </summary>
        public NumberOfDigits() {}

        /// <summary>
        /// Отвечает за пользовательский интерфейс
        /// </summary>
        /// <param name="prompt">Строка приветствия</param>
        public NumberOfDigits(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(prompt);

                int number =
                    (int)
                        ConsoleHelper.GetDoubleFromConsole("Введите число, количество знаков которого Вы хотите узнать");

                Console.WriteLine($"Количество знаков во введенном числе: {CountDigits(number)}.");

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Возвращает количество разрядов числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal int CountDigits(double number)
        {
            return number.ToString(CultureInfo.InvariantCulture).Trim('-').Length;
        }
        #endregion
    }
}