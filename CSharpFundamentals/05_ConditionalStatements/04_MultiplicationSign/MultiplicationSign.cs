using System;

class MultiplicationSign
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine(0);
            return;
        }

        bool positive = true;

        if (a < 0)
        {
            positive = !positive;
        }

        if (b < 0)
        {
            positive = !positive;
        }

        if (c < 0)
        {
            positive = !positive;
        }

        if (positive)
        {
            Console.WriteLine('+');
        }
        else
        {
            Console.WriteLine('-');
        }
    }
}

