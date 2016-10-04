using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TriangleSurfaceByThreeSides
{
    static double FindTriangleSurfaceByThreeSides(double firstSide, double secondSide, double thirdSide)
    {
        double semiPerimeter = (firstSide + secondSide + thirdSide);
        semiPerimeter /= 2;
        double surface = 
            semiPerimeter 
            * ((semiPerimeter - firstSide) 
            * (semiPerimeter - secondSide) 
            * (semiPerimeter - thirdSide));
        surface = Math.Sqrt(surface);
        return surface;
    }

    static void Main()
    {
        double firstSide = double.Parse(Console.ReadLine());
        double secondSide = double.Parse(Console.ReadLine());
        double thirdSide = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2}", FindTriangleSurfaceByThreeSides(firstSide, secondSide, thirdSide));
    }
}

