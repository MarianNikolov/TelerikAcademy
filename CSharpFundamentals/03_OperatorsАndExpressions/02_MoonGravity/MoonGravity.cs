using System;

class MoonGravity
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        double moonGravity = 0.17;
        double youGravityOnTheMoon = moonGravity * weight;
        Console.WriteLine(youGravityOnTheMoon.ToString("N3"));
    }
}

