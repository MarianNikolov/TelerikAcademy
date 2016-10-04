using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecimalToBinary
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToBinary(decimalNumber)); 
    }

    static string ConvertDecimalToBinary(long decimalNumber)
    {
        string binaryNumber = "";
        while (decimalNumber > 0)
        {
            long digit = decimalNumber % 2;
            binaryNumber = digit + binaryNumber; //  binaryNumber += digit
            decimalNumber = decimalNumber / 2;
        }

        // var numberAsCharArray = binaryNumber.ToCharArray();
        // Array.Reverse(numberAsCharArray);
        // binaryNumber = new string(numberAsCharArray);

        return binaryNumber;
    }
}

