using System;
using System.Threading;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    /// <summary>
    /// Класс решения задачи "Авторизация" (№4 в методичке)
    /// 
    /// Выполнил Алексей Дорогов
    /// </summary>
    public static class ConsoleAuthorization
    {
        #region Fileds
        private static int _height;
        private static int _width;

        private const string Login    = "geekbrains";
        private const string Password = "geekbrains";
        #endregion

        #region Public Methods
        /// <summary>
        /// Предлагает ввести логин и пароль, проверяет правильность ввода данных.
        /// Дается три попытки.
        /// При неудачной попытке входа отображается сообщение об ошибке, после чего метод повторно вызывается.
        /// </summary>
        /// <param name="attempt">Номер попытки входа</param>
        public static void ConsoleLogin(int attempt)
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

            AskForLogin(out login, out password);
            attempt++;

            if (login == Login && password == Password) return;
            ConsoleLogin(attempt);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Отображает предложение ввести логин и пароль по центру окна консоли.
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        private static void AskForLogin(out string login, out string password)
        {
            var loginPrompt = "Введите логин:";
            var passwordPrompt = "Введите пароль:";

            ConsoleHelper.Print(loginPrompt, _width / 2 - loginPrompt.Length / 2, _height / 2 - 5);
            Console.CursorLeft = _width / 2 - loginPrompt.Length / 2;
            login = ReadMasked(false);

            ConsoleHelper.Print(passwordPrompt, _width / 2 - passwordPrompt.Length / 2, Console.CursorTop + 1);
            Console.CursorLeft = _width / 2 - loginPrompt.Length / 2;
            password = ReadMasked(true);
        }

        /// <summary>
        /// Считывает пользовательский ввод и маскирует его при необходимости.
        /// </summary>
        /// <param name="mask">Необходимость скрывать вводимые пользователем данные</param>
        /// <returns>Строка с пользовательскими данными</returns>
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

        /// <summary>
        /// Перечитывает размеры окна консоли.
        /// </summary>
        private static void RefreshSize()
        {
            _height = Console.WindowHeight;
            _width  = Console.WindowWidth;
        }
        #endregion
    }
}