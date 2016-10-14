using System;
using System.Collections.Generic;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class PositiveOddSumm
    {
        private static List<double> _numbers;

        public PositiveOddSumm() {}

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

        private static void ReadNumbers()
        {
            var number = ConsoleHelper.ParseDouble();
            if (number == 0) return;
            _numbers.Add(number);
            ReadNumbers();
        }

        internal List<double> FindOdds(List<double> numbers)
        {
            return numbers.Where(n => n%2 != 0 && n > 0).ToList();
        }

        public double CalculateSum(List<double> doubles)
        {
            return FindOdds(doubles).Sum();
        }
    }
}