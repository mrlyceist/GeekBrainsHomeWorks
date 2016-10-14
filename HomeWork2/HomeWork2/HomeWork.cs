using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeekBrainsStudyClass;

[assembly: InternalsVisibleTo("HomeWork2Tests")]
namespace HomeWork2
{
    class HomeWork
    {
        private static List<string> _menuItems;

        static void Main(string[] args)
        {
            const int attempt = 1;

            ConsoleLogin.Login(attempt);

            _menuItems = new List<string>()
            {
                "1 - Минимальное из трех",
                "2 - Подсчет количества знаков числа",
                "3 - Сумма нечетных положительных чисел",
                "4 - Индекс Массы Тела (с интерпретацией)",
                "5 - Поиск \"Хороших\" чисел",
                "6 - Рекурсивный вывод чисел и их сумма"
            };
            ShowMenu();

            Console.ReadKey();
        }

        private static void ShowMenu()
        {
            var selection = ConsoleHelper.PrintMenu(_menuItems);

            Console.Clear();
            switch (selection)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    RunMinimumOfThree();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    RunNumberOfDigits();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    RunPositiveOddSumm();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    RunBodyMassIndex();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    RunGoodNumbers();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Input not allowed!");
                    break;
            }
            ShowMenu();
        }

        private static void RunGoodNumbers()
        {
            var prompt = "Поиск \"Хороших\" чисел";
            Prompt(prompt);
            var goodNumbers = new GoodNumbers(prompt);

            ShowMenu();
        }

        private static void RunBodyMassIndex()
        {
            var prompt = "Рассчет индекса массы тела";
            Prompt(prompt);
            var bodyMassIndex = new BodyMassIndex(prompt);

            ShowMenu();
        }

        private static void RunPositiveOddSumm()
        {
            var prompt = "Вычисление суммы введенных положительных нечетных чисел";
            Prompt(prompt);
            var positiveOddNumbers = new PositiveOddSumm(prompt);

            ShowMenu();
        }

        private static void RunNumberOfDigits()
        {
            var prompt = "Вычисление количества знаков введенного числа";
            Prompt(prompt);
            var numberOfDigits = new NumberOfDigits(prompt);

            ShowMenu();
        }

        private static void RunMinimumOfThree()
        {
            var prompt = "Поиск минимального из трех введенных чисел";
            Prompt(prompt);
            var minimumOfThree = new MinimumOfThree(prompt);

            ShowMenu();
        }

        private static void Prompt(string prompt)
        {
            ConsoleHelper.Print(prompt, true, ConsoleColor.Green);
            Thread.Sleep(1000);
        }
    }
}
