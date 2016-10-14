using System.Globalization;

namespace HomeWork2
{
    public class NumberOfDigits
    {
        internal int CountDigits(double number)
        {
            return number.ToString(CultureInfo.InvariantCulture).Trim('-').Length;
        }
    }
}