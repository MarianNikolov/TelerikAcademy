namespace EuclidianSpace
{
    using System;
    using System.Linq;
    using Models;
    using Extensions;

    public class EuclidianSpaces
    {
        static void Main()
        {
            Point3D point = new Point3D(1, 2, 3);

            // Problem 1. Structure
            Console.WriteLine(point);

            // Problem 2. Static read-only field
            Console.WriteLine(Point3D.Origin);

            // Problem 3. Static class
            var distance = Point3DExtensions
                .CalculateDistance(point, Point3D.Origin);

            Console.WriteLine(distance);

            // Problem 4. Path
            var path = new Path();
            for (int i = 0; i < 10; i++)
            {
                path.AddPoint(new Point3D()
                    { X = i, Y = i * 2, Z = i + 3 });
            }

            string pathStr = "../../path.txt";
            PathStorage.SavePath(path, pathStr);
            var pathFromFile = PathStorage.LoadPath("../../path.txt");

            foreach (var p in pathFromFile)
            {
                Console.WriteLine(p);
            }

        }
    }
}
