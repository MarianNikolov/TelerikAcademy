using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HexadecimalToBinary
{
    static void Main()
    {
        string hexNumber = Console.ReadLine();
        Console.WriteLine(ConvertDecimalToBinary(ConvertHexadecimalToDecimal(hexNumber)));
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

    static long ConvertHexadecimalToDecimal(string hex)
    {
        long decimalNumber = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            int digit = 0;

            if (hex[i] >= '0' && hex[i] <= '9')
            {
                digit = hex[i] - '0';
            }

            else if (hex[i] >= 'A' && hex[i] <= 'F')
            {
                digit = hex[i] - 'A' + 10;
            }

            // POSITION  = hex.Length - i - 1 
            // math.pow(osnovata na sistemata na stepen poziciqta)
            decimalNumber += digit * (long)Math.Pow(16, hex.Length - i - 1);
        }
        return decimalNumber;
    }
}
