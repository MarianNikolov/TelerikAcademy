using System;
using System.Numerics;

class ConsoleApplication1
{
    static void Main()
    {
        string numberString = "444";
        string end = "END";
        int counterForEvenPosition = 0;
        int curentDigit = 1;
        BigInteger productOfAllDigits = 1;
        BigInteger sumOfAllProducts = 1;


        while (numberString != end)
        {
            numberString = Console.ReadLine();

            if (numberString == end)
            {
                break;
            }

            if (counterForEvenPosition % 2 == 1)
            {
                if (numberString.Length == 1 && numberString[0] == '0')
                {
                    numberString = "1";
                }

                // find product of digits
                for (int i = 0; i < numberString.Length; i++)
                {
                    if (numberString[i] == '0')
                    {
                        continue;
                    }
                    curentDigit = numberString[i] - '0';
                    productOfAllDigits = productOfAllDigits * curentDigit;
                }

                sumOfAllProducts *= productOfAllDigits;
                productOfAllDigits = 1;
            }

            counterForEvenPosition++;

            if (counterForEvenPosition == 10)
            {
                Console.WriteLine("{0}", sumOfAllProducts);
                sumOfAllProducts = 1;
            }

        }

        Console.WriteLine(sumOfAllProducts);
    }
}

