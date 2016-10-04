using System;

class PointCircleRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double xCircle = x - 1;
        double yCircle = y - 1;
        
        if ((xCircle * xCircle) + (yCircle * yCircle) <= Math.Pow(1.5, 2))
        {
            Console.Write("inside circle ");
            if (x >= -1 && x <= 5 && y <= 1 && y >= -1)
            {
                Console.Write("inside rectangle");
            }
            else
            {
                Console.Write("outside rectangle");
            }
        }
        else
        {
            Console.Write("outside circle ");
            if (x >= -1 && x <= 5 && y <= 1 && y >= -1)
            {
                Console.Write("inside rectangle");
            }
            else
            {
                Console.Write("outside rectangle");
            }
        }
    }
}

