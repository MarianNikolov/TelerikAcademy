using System;
using System.Numerics;

class SaddyKopper
{
    static void Main()
    {
        string numberString = Console.ReadLine();
        int counter = 0;
        int sum = 0;
        BigInteger multiplication = 1;

        while (numberString.Length > 1)
        {

            while (numberString.Length > 1)
            {
                numberString = numberString.Substring(0, numberString.Length - 1);

                for (int i = 0; i < numberString.Length; i += 2)
                {
                    sum += numberString[i] - '0';
                }
                multiplication *= sum;
                sum = 0;
            }
            counter++;
            numberString = multiplication.ToString();
            multiplication = 1;
            if (counter == 10)
            {
                Console.WriteLine(numberString);
                return;
            }
        }

        Console.WriteLine(counter);
        Console.WriteLine(numberString);

    }

}

