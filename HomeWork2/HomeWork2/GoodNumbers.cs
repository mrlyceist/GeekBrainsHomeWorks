using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    public class GoodNumbers
    {
        internal int DigitSumm(int number)
        {
            return number.ToString().Sum(c => int.Parse(c.ToString()));
        }

        public bool Divisible(int number)
        {
            return number%DigitSumm(number) == 0;
        }

        public int FindGoodNumbers(int start, int finish)
        {
            int found = 0;
            for (int i = start; i < finish; i++)
            {
                if (Divisible(i)) found++;
            }
            return found;
        }
    }
}