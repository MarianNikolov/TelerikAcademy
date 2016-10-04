using System;

class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double distance = (x * x) + (y * y);
        double newDistance = Math.Sqrt(distance);
        
        if ((x * x) + (y * y) <= 4)
        {
            Console.WriteLine("yes {0:F2}", newDistance);
        }
        else
	    {
            Console.WriteLine("no {0:F2}", newDistance);       
	    }
    }
}
