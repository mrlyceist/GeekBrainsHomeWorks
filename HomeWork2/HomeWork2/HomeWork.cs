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
            if (!ConsoleLogin()) return;
            Console.WriteLine("WAT");
            Console.ReadKey();
        }

        private static bool ConsoleLogin()
        {
            int i = 1;
                var height = Console.WindowHeight;
                var width = Console.WindowWidth;
            
            do
            {
                Console.Title = i.ToString();
                string login = string.Empty;
                string password=string.Empty;

                    Console.Clear();
                    ConsoleHelper.Print("ERROR", true, ConsoleColor.Red);
                    Thread.Sleep(1000);
                    Console.Clear();
                    AskForLogin(height, width, out login, out password);
                    i++;

                if (login == Login && password == Password)
                {
                    return true;
                }
            } while (i <= 3);
            return false;
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
