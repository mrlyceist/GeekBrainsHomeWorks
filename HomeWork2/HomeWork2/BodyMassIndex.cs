using System;
using GeekBrainsStudyClass;

namespace HomeWork2
{
    public class BodyMassIndex
    {
        public BodyMassIndex() {}

        public BodyMassIndex(string prompt)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();

                Console.WriteLine(prompt);

                double height = ConsoleHelper.GetDoubleFromConsole("Введите рост (в см)");
                double weight = ConsoleHelper.GetDoubleFromConsole("Введите вес (в кг)");
                double index = GetIndex(weight, height);

                Console.WriteLine($"Ваш Индекс Массы Тела: {index:F} - {Interprete(index)}");
                Console.WriteLine(Advice(weight, height));

                Console.WriteLine("Еще разок? ('y' - повторить программу, 'n' - выход в главное меню.)");
                if (Console.ReadKey().Key != ConsoleKey.Y) loop = false;
            }
        }

        internal double GetIndex(double weight, double height)
        {
            if (height > 2.5) height = height/100;
            return weight/height/height;
        }

        internal string Interprete(double index)
        {
            if (index < 16) return "Выраженный дефицит массы тела";
            if (index >= 16 && index < 18.5) return "Недостаточная масса тела";
            if (index >= 18.5 && index < 24.99) return "Ваша масса в норме";
            if (index >= 25 && index < 30) return "Избыточная масса тела";
            if (index >= 30 && index < 35) return "Ожирение первой степени";
            if (index >= 35 && index < 40) return "Ожирение второй степени";
            return "Ожирение третьей степени";
        }

        internal int CalculateNormalMass(double height)
        {
            if (height > 2.5) height = height / 100;
            return (int) Math.Round(21.745*height*height);
        }

        internal string Advice(double weight, double height)
        {
            var index = GetIndex(weight, height);
            var normalWeight = CalculateNormalMass(height);
            var normalIndex = GetIndex(normalWeight, height);
            var delta = index - normalIndex;
            
            if (Math.Abs(delta) < 3.245) return "Так держать!";
            
            return "Вам не помешает " +
                   (delta < 0 ? $"набрать {normalWeight - weight}" : $"сбросить {weight - normalWeight}") + " кг.";
        }
    }
}