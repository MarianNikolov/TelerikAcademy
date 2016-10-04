using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecimalToBase
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToBase(decimalNumber, 36));  
    }
    // max numeral system 36 symbols
    static string ConvertDecimalToBase(long decimalNumber, int numeralSystem)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            long digit = decimalNumber % numeralSystem; 
            if (digit >= 0 && digit <= 9)
            {
                result = (char)(digit + '0') + result;
            }
            else // vsqka ot 'A' do 'Z'
            {
                result = (char)((digit - 10) + 'A') + result;
            }
            decimalNumber /= numeralSystem;
        }
        return result;
    }
}

