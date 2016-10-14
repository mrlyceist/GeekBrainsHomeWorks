using System;
using System.Threading;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class ConsoleLogin
    {
        private static int _height;
        private static int _width;

        private const string _login = "qwe";
        private const string Password = "123";

        public static void Login(int attempt)
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
            if (attempt > 3) Environment.Exit(0);

            AskForLogin(_height, _width, out login, out password);
            attempt++;

            if (login == _login && password == Password) return;
            Login(attempt);
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
            var @string = String.Empty;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (@string.Length == 0) continue;
                    @string = @string.Substring(0, @string.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    @string += key.KeyChar;
                    Console.Write(!mask ? key.KeyChar : '*');
                }
            } while (key.Key != ConsoleKey.Enter);
            return @string;
        }

        private static void RefreshSize()
        {
            _height = Console.WindowHeight;
            _width = Console.WindowWidth;
        }
    }
}