using System;
using System.Globalization;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class NumberOfDigits
    {
        public NumberOfDigits() {}

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

        internal int CountDigits(double number)
        {
            return number.ToString(CultureInfo.InvariantCulture).Trim('-').Length;
        }
    }
}