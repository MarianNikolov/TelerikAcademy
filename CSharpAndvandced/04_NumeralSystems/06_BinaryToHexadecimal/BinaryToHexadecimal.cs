using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryToHexadecimal
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        Console.WriteLine(ConvertDecimalToHexadecimal(ConvertBinaryToDecimal(binaryNumber)));
    }

    static long ConvertBinaryToDecimal(string binaryNumber)
    {
        long decimalNumber = 0;

        for (int i = 0; i < binaryNumber.Length; i++)
        {
            // bynaryNumber[i]  ----> '0' or '1'
            int digit = binaryNumber[i];
            digit = binaryNumber[i] - '0';
            int position = binaryNumber.Length - i - 1;
            decimalNumber += digit * (long)Math.Pow(2, position); // vdigame sistemata na stepen poziciqta
        }
        return decimalNumber;
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
