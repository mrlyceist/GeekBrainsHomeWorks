using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    public class MinimumOfThree
    {
        public double FindMinimal(double first, double second, double third)
        {
            var list = new List<double>() {first, second, third};
            return list.Min();
        }
    }
}