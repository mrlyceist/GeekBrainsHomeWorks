using System;

namespace HomeWork1
{
    /// <summary>
    /// Написать программу “Анкета”. Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
    /// В результатевся информация выводится в одну строчку.
    /// 
    /// Выполнил Алексей Дорогов.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var loop = true;

            Console.WriteLine("Анкета");

            while (loop)
            {
                string name, lastName;
                int age, height;
                double weight;

                ReadData(out name, out lastName, out age, out height, out weight);
                WriteData(name, lastName, age, height, weight);

                Console.WriteLine("Еще разок? (y/n)");
                loop = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();
            }
        }

        private static void ReadData(out string name, out string lastName, out int age, out int height, out double weight)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Введите возраст: ");
            age = (int)ParseConsoleInput();
            Console.Write("Введите рост (в сантиметрах): ");
            height = (int)ParseConsoleInput();
            Console.Write("Введите вес (в килограммах): ");
            weight = ParseConsoleInput();
        }

        /// <summary>
        /// Tries to parse user console input.
        /// Prints error message if can't and suggests re-input.
        /// </summary>
        /// <returns>Parsed value</returns>
        public static double ParseConsoleInput()
        {
            double result;

            var parse = Console.ReadLine();
            if (double.TryParse(parse, out result)) return result;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Строка имела неверный формат! Попробуйте еще раз: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            result = ParseConsoleInput();

            return result;
        }

        private static void WriteData(string name, string lastName, int age, int height, double weight)
        {
            Console.WriteLine("Данные сохранены.");

            Console.WriteLine();
            Console.WriteLine("Конкатенированный вывод:");
            Console.WriteLine("Имя: " + name + "; Фамилия: " + lastName +
                ";\nВозраст: " + age + "; Рост: " + height + "; Вес: " + weight + ".");

            Console.WriteLine();
            Console.WriteLine("Форматированный вывод, стандарт C# 4.0:");
            Console.WriteLine("Возраст: {0}; Фамилия: {1};\nВозраст: {2}; Рост: {3}; Вес: {4}.",
                name, lastName, age, height, weight);

            Console.WriteLine();
            Console.WriteLine("Форматированный вывод, стандарт C# 6.0:");
            Console.WriteLine($"Возраст: {name}; Фамилия: {lastName};\nВозраст: {age}; Рост: {height}; Вес: {weight}.");
        }
    }
}