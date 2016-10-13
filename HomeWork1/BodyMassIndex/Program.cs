using System;

namespace BodyMassIndex
{
    /// <summary>
    /// Ввести вес и рост человека. Расчитать и вывести индекс массы тела(ИМТ) по формуле
    /// I=m/(h* h); где m­массатела вкилограммах, h ­ рост вметрах
    /// * Интерпритировать показания ИМТ.
    /// 
    /// Выполнил Алексей Дорогов.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Введите массу тела (в кг): ");
            double weight = HomeWork1.Program.ParseConsoleInput();
            Console.Write("Введите рост (в см): ");
            double height = HomeWork1.Program.ParseConsoleInput();

            double bodyMassIndex = weight / Math.Pow(height / 100, 2);
            Console.WriteLine($"Индекс массы тела: {Math.Round(bodyMassIndex, 2)}");

            if (bodyMassIndex < 16)                             Console.WriteLine("Выраженный дефицит массы тела");
            if (bodyMassIndex >= 16   && bodyMassIndex < 18.5)  Console.WriteLine("Недостаточная масса тела");
            if (bodyMassIndex >= 18.5 && bodyMassIndex < 24.99) Console.WriteLine("Индекс массы тела в пределах нормы");
            if (bodyMassIndex >= 25   && bodyMassIndex < 30)    Console.WriteLine("Избыточная масса тела (предожирение)");
            if (bodyMassIndex >= 30   && bodyMassIndex < 35)    Console.WriteLine("Ожирение первой степени");
            if (bodyMassIndex >= 35   && bodyMassIndex < 40)    Console.WriteLine("Ожирение второй степени");
            if (bodyMassIndex > 40)                             Console.WriteLine("Ожирение третьей степени");

            Console.ReadKey();
        }
    }
}
