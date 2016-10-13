using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableValueChange
{
    /// <summary>
    /// Написать программу обмена значениями двух переменных
    /// 
    /// Выполнил Алексей Дорогов.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var loop = true;

            Console.WriteLine("Обмен значениями переменных.");

            while (loop)
            {
                Console.Write("Введите первую переменную: ");
                var first = Console.ReadLine();

                Console.Write("Введите вторую переменную: ");
                var second = Console.ReadLine();

                int int1, int2;
                //
                // Надеюсь, этот небольшой трюк не сочтут за жульничество - технически, хоть я и объявляю
                // новые переменные, обмен значениями происходит без посредников.
                // Новые переменные нужны только для того, что бы гарантированно работать с целыми числами.
                // Метод не сработает для строк по очевидным причинам, а для чисел с плавающей запятой
                // мы можем запнуться о потерю точности.
                //
                if (int.TryParse(first, out int1) && int.TryParse(second, out int2))
                {
                    Console.WriteLine("Ба, да это ж целые числа! Тогда нам не нужна временная переменная!");
                    int1 = int1 + int2;
                    int2 = int1 - int2;
                    int1 = int1 - int2;
                    first  = int1.ToString();
                    second = int2.ToString();
                }

                else
                {
                    var tmp = first;
                    first = second;
                    second = tmp;
                }
                Console.WriteLine($"Новые значения: первая переменная = {first}, вторая переменная = {second}\n");

                Console.WriteLine("Еще разок? (y/n)");
                loop = Console.ReadKey().Key == ConsoleKey.Y;
                Console.WriteLine();
            }
        }
    }
}
