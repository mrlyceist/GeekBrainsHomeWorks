using System;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    internal class RecursiveOutput
    {
        public RecursiveOutput() { }

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

        private string RecursivePrint(int start, int finish)
        {
            if (Math.Abs(finish - start) < 0.01) return start.ToString();
            if (start < finish) return $"{start} {RecursivePrint(start + 1, finish)}";
            return $"{start} {RecursivePrint(start - 1, finish)}";
        }

        internal int RecursiveSum(int start, int finish)
        {
            if (start == finish) return start;
            if (start < finish) return start + RecursiveSum(start+1, finish);
            return start + RecursiveSum(start - 1, finish);
        }
    }
}