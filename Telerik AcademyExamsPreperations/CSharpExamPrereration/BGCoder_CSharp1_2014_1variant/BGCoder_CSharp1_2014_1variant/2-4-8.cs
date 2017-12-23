using System;

class Program
{
    static void Main()
    {
        decimal numberA = decimal.Parse(Console.ReadLine());
        decimal numberB = decimal.Parse(Console.ReadLine());
        decimal numberC = decimal.Parse(Console.ReadLine());

        decimal numberR = 0;
        decimal newNumberR = 0;

        if (numberB == 2)
        {
            numberR = numberA % numberC;
        }

        if (numberB == 4)
        {
            numberR = numberA + numberC;
        }

        if (numberB == 8)
        {
            numberR = numberA * numberC;
        }

        newNumberR = numberR;

        if (newNumberR % 4 == 0)
        {
            newNumberR = newNumberR / 4;
            Console.WriteLine(newNumberR);
        }
        else
        {
            newNumberR = newNumberR % 4;
            Console.WriteLine(newNumberR);
        }
        Console.WriteLine(numberR);
    }
}

