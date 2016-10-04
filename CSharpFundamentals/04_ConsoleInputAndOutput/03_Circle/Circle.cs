using System;

class Circle
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        double perimeter = Math.PI * (r * 2);
        double area = Math.PI* (r * r);
        Console.WriteLine("{0:F2} {1:F2}", perimeter, area);

    }
}
