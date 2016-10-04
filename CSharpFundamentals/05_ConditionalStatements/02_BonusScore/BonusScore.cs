using System;

class BonusScore
{
    static void Main()
    {
        int digit = int.Parse(Console.ReadLine());

        if (digit >= 1 && digit <= 3)
        {
            Console.WriteLine(digit * 10);
        }
        else if (digit >= 4 && digit <= 6)
        {
            Console.WriteLine(digit * 100);
        }
        else if (digit >= 7 && digit <= 9)
        {
            Console.WriteLine(digit * 1000);
        }
        else
        {
            Console.WriteLine("invalid score");
        }

    }
}

