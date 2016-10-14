using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    class HomeWork
    {
        private static int _height;
        private static int _width;
        private const string Login = "qwe";
        private const string Password = "123";

        static void Main(string[] args)
        {
            const int attempt = 1;

            ConsoleLogin(attempt);

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
            
            return Console.ReadKey().Key;
        }

        private static void ConsoleLogin(int attempt)
        {
            RefreshSize();

            string login;
            string password;

            Console.Clear();
            if (attempt != 1)
            {
                string message = $"Неудачная попытка входа. Попыток осталось: {4 - attempt}.";
                ConsoleHelper.Print(message, true, ConsoleColor.Red);
                Thread.Sleep(1000);
                Console.Clear();
            }
            if (attempt>3) Environment.Exit(0);

            AskForLogin(_height, _width, out login, out password);
            attempt++;

            if (login==Login && password==Password) return;
            ConsoleLogin(attempt);
        }

        private static void RefreshSize()
        {
            _height = Console.WindowHeight;
            _width = Console.WindowWidth;
        }

        private static void AskForLogin(int height, int width, out string login, out string password)
        {
            var loginPrompt = "Введите логин:";
            var passwordPrompt = "Введите пароль:";
            ConsoleHelper.Print(loginPrompt, width / 2 - loginPrompt.Length / 2, height / 2 - 5);
            Console.CursorLeft = width / 2 - loginPrompt.Length / 2;
            login = ReadMasked(false);
            ConsoleHelper.Print(passwordPrompt, width / 2 - passwordPrompt.Length / 2, Console.CursorTop + 1);
            Console.CursorLeft = width / 2 - loginPrompt.Length / 2;
            password = ReadMasked(true);
        }

        private static string ReadMasked(bool mask)
        {
            ConsoleKeyInfo key;
            var @string = string.Empty;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (@string.Length==0) continue;
                    @string = @string.Substring(0, @string.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key!=ConsoleKey.Enter)
                {
                    @string += key.KeyChar;
                    Console.Write(!mask ? key.KeyChar : '*');
                }
            } while (key.Key != ConsoleKey.Enter);
            return @string;
        }
    }
}
