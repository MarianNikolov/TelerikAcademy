using System;

class ExchangeIfGreater
{
    static void Main()
    {
        double bigNumber = double.Parse(Console.ReadLine());
        double lowNumber = double.Parse(Console.ReadLine());

        if (lowNumber > bigNumber)
        {
            Console.WriteLine("{0} {1}", bigNumber, lowNumber);
        }

        else if (bigNumber > lowNumber)
        {
            Console.WriteLine("{0} {1}", lowNumber, bigNumber);
        }
        else
        {
            Console.WriteLine("{0} {1}", bigNumber, lowNumber);
        }
    }
}

