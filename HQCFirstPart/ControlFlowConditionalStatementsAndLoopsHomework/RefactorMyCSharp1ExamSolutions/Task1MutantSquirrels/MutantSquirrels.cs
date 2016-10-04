using System;
using System.Numerics;

class MutantSquirrels
{
    static void Main(string[] args)
    {
        double trees = double.Parse(Console.ReadLine());
        double branches = double.Parse(Console.ReadLine());
        double squirrels = double.Parse(Console.ReadLine());
        double averageNumberOfTails = double.Parse(Console.ReadLine());

        double sum = trees * branches * squirrels * averageNumberOfTails;

        if (sum % 2 == 1)
        {
            sum = sum / 7;
            Console.WriteLine("{0:F3}", sum);
        }
        else
        {
            sum = sum * 376439;
            Console.WriteLine("{0:F3}", sum);

        }
    }
}

