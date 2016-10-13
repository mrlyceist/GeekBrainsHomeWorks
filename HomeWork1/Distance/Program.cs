using System;

namespace Distance
{
    /// <summary>
    /// Написать программу, которая подсчитывает расстояние между точками
    /// с координатами x1, y1 и x2, y2по формулеr=Math.Sqrt(Math.Pow(x2­x1,2)+Math.Pow(y2­ 1,2).
    /// Вывести результат используя спецификаторформата .2f (с двумязнаками послезапятой);
    /// 
    /// Выполнил Алексей Дорогов.
    /// </summary>
    class Program
    {
        /// <summary>
        /// По-хорошему, надо бы создавать отдельный класс "Point" и объявлять в нем метод "Distance"
        /// а здесь просто его использовать.
        /// Но это выходит за рамки данного задания.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление расстояния между двумя точками.");

            Console.WriteLine("Первая точка:");
            Console.Write("Координата \"X\": ");
            double x1 = HomeWork1.Program.ParseConsoleInput();
            Console.Write("Координата \"Y\": ");
            double y1 = HomeWork1.Program.ParseConsoleInput();

            Console.WriteLine("Вторая точка:");
            Console.Write("Координата \"X\": ");
            double x2 = HomeWork1.Program.ParseConsoleInput();
            Console.Write("Координата \"Y\": ");
            double y2 = HomeWork1.Program.ParseConsoleInput();

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            var distanceFromMethod = CalculateDistance(x1, y1, x2, y2);

            Console.WriteLine("Дистанция, рассчитанная непосредственно в теле программы:");
            Console.WriteLine($"{distance:F}");
            Console.WriteLine();
            Console.WriteLine("Дистанция, рассчитанная в выделенном методе:");
            Console.WriteLine($"{distanceFromMethod:F}");

            Console.ReadKey();
        }

        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
