using GeekBrainsStudyClass;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("HomeWork2Tests")]
namespace HomeWork2
{
    /// <summary>
    /// КУРС: C#, Уровень 1.
    /// Домашняя работа №2.
    /// Выполнил: Алексей Дорогов.
    /// 
    /// Структура приложения:
    ///     Каждая задача выполнена в своем классе.
    ///     При запуске запрашивается логин и пароль.
    ///     Логин:  geekbrains
    ///     Пароль: geekbrains
    ///     Меню позволяет выбрать задачу для проверки.
    /// В большинстве случаев реализована проверка на ошибки.
    /// Юнит-тесты логики представлены в проекте "HomeWork2UnitTests".
    /// </summary>
    class HomeWork
    {
        #region Fields
        private static List<string> _menuItems;
        #endregion

        static void Main(string[] args)
        {
            const int attempt = 1;

            ConsoleAuthorization.ConsoleLogin(attempt);

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

        #region Private Methods
        #region Task Starters
        private static void RunRecursiveOutput()
        {
            var prompt = "Рекурсивный вывод диапазона";
            Prompt(prompt);

            var recursiveOutput = new RecursiveOutput(prompt);

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
        #endregion

        #region Service Methods
        private static void Prompt(string prompt)
        {
            ConsoleHelper.Print(prompt, true, ConsoleColor.Green);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Обработка выбора элемента меню
        /// </summary>
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
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    RunRecursiveOutput();
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
        #endregion
        #endregion
    }
}
