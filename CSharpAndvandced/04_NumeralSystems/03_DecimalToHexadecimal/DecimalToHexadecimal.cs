using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecimalToHexadecimal
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToHexadecimal(decimalNumber));
    }

    static string ConvertDecimalToHexadecimal(long decimalNumber)
    {
        string hexNumber = "";

        while (decimalNumber > 0)
        {
            long digit = decimalNumber % 16; // 0-9 and 10-15
            if (digit >= 0 && digit <= 9)
            {
                hexNumber = (char)(digit + '0') + hexNumber;
            }
            else if (digit >= 10 && digit <= 15)
            {
                hexNumber = (char)((digit - 10) + 'A') + hexNumber;
            }
            decimalNumber /= 16;
        }
        return hexNumber;
    }

}

