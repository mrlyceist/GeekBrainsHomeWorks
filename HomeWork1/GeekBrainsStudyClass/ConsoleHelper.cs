using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekBrainsStudyClass
{
    /// <summary>
    /// Simple methods, used to simplify console interactions
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Tries to parse user console input.
        /// Prints error message if can't and suggests re-input.
        /// </summary>
        /// <returns>Parsed value</returns>
        public static double ParseDouble()
        {
            double result;

            var parse = Console.ReadLine();
            if (double.TryParse(parse, out result)) return result;

            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Строка имела неверный формат! Попробуйте еще раз: ");
            Console.ForegroundColor = color;

            result = ParseDouble();

            return result;
        }

        /// <summary>
        /// Prints text at desired pposition of a console.
        /// </summary>
        /// <param name="string">Text to be printed</param>
        /// <param name="xPosition">The column position of the printed text. Numbered from left to right starting at 0.</param>
        /// <param name="yPosition">The row position of the printed text. Numbered from top to bottom starting at 0.</param>
        public static void Print(string @string, int xPosition, int yPosition)
        {
            var color = Console.ForegroundColor;

            int stringWidth = @string.Length;
            if (Console.WindowWidth < xPosition + stringWidth)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет, такая длинная строка здесь не влезет!");
                Console.ForegroundColor = color;
                return;
            }

            if (Console.WindowHeight < yPosition)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не влезает по высоте!");
                Console.ForegroundColor = color;
                return;
            }

            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine(@string);
        }

        /// <summary>
        /// Prints text at the center of a console.
        /// </summary>
        /// <param name="string">Text to be printed</param>
        /// <param name="centered">Centerness of the printed text.</param>
        public static void Print(string @string, bool centered)
        {
            if (!centered)
            {
                Console.WriteLine(@string);
                return;
            }

            int stringWidth = @string.Length;
            int xPosition = Console.WindowWidth / 2 - stringWidth / 2;
            int yPosition = Console.WindowHeight / 2;

            Print(@string, xPosition, yPosition);
        }

        /// <summary>
        /// Offeres user to input some number, that will be returned.
        /// </summary>
        /// <param name="prompt">Prompt text</param>
        /// <returns>Some double value</returns>
        public static double GetDoubleFromConsole(string prompt)
        {
            Console.Write($"{prompt}: ");
            return ParseDouble();
        }

        /// <summary>
        /// Offeres user to input some string, that will be returned.
        /// </summary>
        /// <param name="prompt">Prompt text</param>
        /// <returns>Some string</returns>
        public static string GetStringFromConsole(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints some text at the center of a console with some color.
        /// </summary>
        /// <param name="string">Text to be printed</param>
        /// <param name="centered">Centerness of a text</param>
        /// <param name="color">Color, which will be used to print text</param>
        public static void Print(string @string, bool centered, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Print(@string, centered);
            Console.ForegroundColor = oldColor;
        }

        /// <summary>
        /// Prints menu on the center of a screen, listens for a key to be pressed.
        /// </summary>
        /// <param name="menuItems">List of menu textual items</param>
        /// <returns>Console key</returns>
        public static ConsoleKey PrintMenu(List<string> menuItems)
        {
            Console.Clear();
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            string prompt = "Выберите задание (Esc для выхода):";
            string longestItem = menuItems.OrderByDescending(s => s.Length).First();

            Console.SetCursorPosition(width / 2 - longestItem.Length / 2, height / 2 - menuItems.Count / 2 - 2);
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            ConsoleHelper.Print(prompt, left, top);

            foreach (string item in menuItems)
            {
                ConsoleHelper.Print(item, left, top + menuItems.IndexOf(item) + 1);
            }

            Console.SetCursorPosition(left, top + menuItems.Count + 1);

            return Console.ReadKey().Key;
        }
    }
}
