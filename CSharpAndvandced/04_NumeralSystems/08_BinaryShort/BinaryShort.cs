using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BinaryShort
{
    static void Main()
    {
        short number = short.Parse(Console.ReadLine());
        if (number < 0)
        {
            Console.WriteLine(Convert.ToString(number, 2));//.PadLeft(16, '0').Substring(16, 32));
            // string convertedNumber = ConvertDecimalToBinary(number).PadLeft(16, '0');
        }
        else
        {
            Console.WriteLine(ConvertDecimalToBinary(number).PadLeft(16, '0'));
        }
        
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

