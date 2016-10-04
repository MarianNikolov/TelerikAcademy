using System;

class Rectangles
{
    static void Main()
    {
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());
        decimal area = width * height;
        decimal perimeter = (width * 2) + (height * 2);
        Console.WriteLine("{0:F2} {1:F2}", area, perimeter);
    }
}
