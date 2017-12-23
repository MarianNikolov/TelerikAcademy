using System;

class DrunkenNumbers
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());
        int countNumberDigits = 0;
        int middle = 0;
        int beerM = 0;
        int beerV = 0;

        for (int i = 0; i < rounds; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                number *= -1;
            }
            int numberForCoundDigits = number;
            while (numberForCoundDigits > 0)
            {
                numberForCoundDigits /= 10;
                countNumberDigits++;
            }

            if (countNumberDigits % 2 == 0)
            {
                for (int t = 0; t < countNumberDigits / 2; t++)
                {
                    beerV += (number % 10);
                    number /= 10;
                }
                for (int r = 0; r < countNumberDigits / 2; r++)
                {
                    beerM += (number % 10);
                    number /= 10;
                }
            }

            else
            {
                for (int t = 0; t < countNumberDigits / 2; t++)
                {
                    beerV += (number % 10);
                    number /= 10;
                }
                middle = number % 10;
                beerV += middle;
                beerM += middle;
                number /= 10;

                for (int r = 0; r < countNumberDigits / 2; r++)
                {
                    beerM += (number % 10);
                    number /= 10;
                }
            }

            countNumberDigits = 0;
        }

        if (beerM > beerV)
        {
            Console.WriteLine("M {0}", beerM - beerV);
        }
        else if (beerV > beerM)
        {
            Console.WriteLine("V {0}", beerV - beerM);
        }
        else
        {
            Console.WriteLine("No {0}", beerM + beerV);
        }
    }
}