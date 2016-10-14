using System;
using System.Collections.Generic;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class MinimumOfThree
    {
        public MinimumOfThree() { }

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

        internal double FindMinimal(double first, double second, double third)
        {
            var list = new List<double> {first, second, third};
            return list.Min();
        }
    }
}