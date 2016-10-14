using System;
using System.Linq;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class GoodNumbers
    {
        public GoodNumbers() { }

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

        internal int DigitSumm(int number)
        {
            return number.ToString().Sum(c => int.Parse(c.ToString()));
        }

        public bool Divisible(int number)
        {
            return number % DigitSumm(number) == 0;
        }

        public int FindGoodNumbers(int start, int finish)
        {
            int found = 0;
            for (int i = start; i < finish; i++)
            {
                if (Divisible(i)) found++;
            }
            return found;
        }
    }
}