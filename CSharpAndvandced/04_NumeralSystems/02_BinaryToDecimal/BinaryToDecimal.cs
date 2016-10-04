using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryToDecimal
{
    static void Main()
    {
        string binaryNumber = Console.ReadLine();
        Console.WriteLine(ConvertBinaryToDecimal(binaryNumber));
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
}

