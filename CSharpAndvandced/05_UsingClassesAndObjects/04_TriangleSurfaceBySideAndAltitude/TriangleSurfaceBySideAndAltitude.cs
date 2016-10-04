using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TriangleSurfaceBySideAndAltitude
{
    static decimal FindSurfaceOfTriangle(decimal lenghtOfASide, decimal altitude)
    {
        decimal divider = 0.5m;
        decimal surface = (lenghtOfASide * altitude);
        surface *= divider;
        return surface;
    }

    static void Main()
    {
        decimal lenghtOfASide = decimal.Parse(Console.ReadLine());
        decimal altitude = decimal.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2}", FindSurfaceOfTriangle(lenghtOfASide, altitude));

    // On the first line you will receive the length of a side of the triangle
    // On the second line you will receive the altitude to that side



    }
}

