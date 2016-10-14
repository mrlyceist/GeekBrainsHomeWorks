using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HomeWork2
{
    public class MinimumOfThree
    {
        internal double FindMinimal(double first, double second, double third)
        {
            var list = new List<double> {first, second, third};
            return list.Min();
        }
    }
}