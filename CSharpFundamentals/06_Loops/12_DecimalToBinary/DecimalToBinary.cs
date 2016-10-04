using System;

class DecimalToBinary
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());
        string binaryNumber = string.Empty;


        while (num > 0)
        {
            binaryNumber += num % 2;
            num = num / 2;
        }


        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            Console.Write(binaryNumber[i]);
        }



    }
}

