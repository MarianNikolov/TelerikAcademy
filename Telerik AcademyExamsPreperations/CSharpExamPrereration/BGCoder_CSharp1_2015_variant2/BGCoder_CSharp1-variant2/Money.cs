using System;

class Money
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());

        decimal biggest = Math.Max(Math.Max(a, b), c);
        Console.WriteLine(biggest);
        decimal smallest = Math.Min(Math.Min(a, b), c);
        Console.WriteLine(smallest);

        Console.WriteLine("{0:F2}", ((a + b) + c) / 3);

    }
}

