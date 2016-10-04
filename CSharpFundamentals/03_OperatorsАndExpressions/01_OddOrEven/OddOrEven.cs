using System;

class OddOrEven
{
    static void Main()
    {
        sbyte number = sbyte.Parse(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("even " + number);
        }
        else
        {
            Console.WriteLine("odd " + number);
        }
    }
}

