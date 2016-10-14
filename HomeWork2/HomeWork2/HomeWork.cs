using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeekBrainsStudyClass;

[assembly: InternalsVisibleTo("HomeWork2Tests")]
namespace HomeWork2
{
    class HomeWork
    {
        private static int _height;
        private static int _width;

        static void Main(string[] args)
        {
            const int attempt = 1;

            ConsoleLogin.Login(attempt);

            var menuItems = new List<string>()
            {
                "1 - Минимальное из трех",
                "2 - Подсчет количества знаков числа",
                "3 - Сумма нечетных положительных чисел",
                "4 - Индекс Массы Тела (с интерпретацией)",
                "5 - Поиск \"Хороших\" чисел",
                "6 - Рекурсивный вывод чисел и их сумма"
            };

            var selection = PrintMenu(menuItems);

            Console.Clear();
            switch (selection)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("first");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("second");
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Input not allowed!");
                    break;
            }

            Console.ReadKey();
        }

        private static ConsoleKey PrintMenu(List<string> menuItems)
        {
            Console.Clear();
            RefreshSize();

            string prompt = "Выберите задание:";
            string longestItem = menuItems.OrderByDescending(s => s.Length).First();

            Console.SetCursorPosition(_width/2 - longestItem.Length/2, _height/2 - 5);
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            ConsoleHelper.Print(prompt, left, top);

            foreach (string item in menuItems)
            {
                ConsoleHelper.Print(item, left, top+menuItems.IndexOf(item)+1);
            }
            
            Console.SetCursorPosition(left, top+menuItems.Count+1);

            return Console.ReadKey().Key;
        }

        private static void RefreshSize()
        {
            _height = Console.WindowHeight;
            _width = Console.WindowWidth;
        }
    }
}
