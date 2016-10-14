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
        private const string Login = "qwe";
        private const string Password = "123";

        static void Main(string[] args)
        {
            const int attempt = 1;

            ConsoleLogin(attempt);
            
            Console.Clear();

            PrintMenu();

        }

        private static void PrintMenu()
        {
            //Console.SetCursorPosition();
        }

        private static void ConsoleLogin(int attempt)
        {
            var height = Console.WindowHeight;
            var width = Console.WindowWidth;

            string login;
            string password;

            Console.Clear();
            if (attempt != 1)
            {
                string message = $"Неудачная попытка входа. Осталось {4 - attempt} попытки!";
                ConsoleHelper.Print(message, true, ConsoleColor.Red);
                Thread.Sleep(1000);
                Console.Clear();
            }
            if (attempt>3) Environment.Exit(0);

            AskForLogin(height, width, out login, out password);
            attempt++;

            if (login==Login && password==Password) return;
            ConsoleLogin(attempt);
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
