using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TriangleSurfaceByTwoSidesAndAnAngle
{
    static double FindTriangleSurfaceByTwoSidesAndAnAngle(double firstSide, double secondSide, double angle)
    {
        double sin = Math.Sin(angle * Math.PI / 180);  //Math.Sin(30 * Math.PI/180) is sin of 30 degrees.
        double surface = 0.5 * ((firstSide * secondSide) * sin);  
        return surface;
    }

    static void Main()
    {
        double firstSide = double.Parse(Console.ReadLine());
        double secondSide = double.Parse(Console.ReadLine());
        double angleInDegrees = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2}", FindTriangleSurfaceByTwoSidesAndAnAngle(firstSide, secondSide, angleInDegrees));
    }
}

