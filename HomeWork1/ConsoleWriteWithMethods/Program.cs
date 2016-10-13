using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekBrainsStudyClass;

namespace ConsoleWriteWithMethods
{
    /// <summary>
    /// Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.    ///
    /// Выполнил Алексей Дорогов.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод строки по центру");

            var loop = true;

            while (loop)
            {
                Console.WriteLine("Введите свою строку. Или не вводите, тогда я сам что-нибудь напишу.");
                var input = Console.ReadLine();
                if (input == string.Empty)
                    input = "Привет из Екатеринбурга, от А.Д.!";

                Console.Clear();
                ConsoleHelper.Print(input, true);

                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Еще разок? (y/n)");
                loop = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();
            }
        }
    }
}
