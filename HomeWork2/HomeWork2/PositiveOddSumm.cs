using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    public class PositiveOddSumm
    {
        internal List<int> FindOdds(List<int> numbers)
        {
            return numbers.Where(n => n%2 != 0 && n > 0).ToList();
        }
    }
}