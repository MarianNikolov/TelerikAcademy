using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Task_07
    {
        static void Main()
        {
            var input1 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            var input2 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            var input3 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();


            Point2D p1 = new Point2D(input1[0], input1[1]);
            Point2D p2 = new Point2D(input2[0], input2[1]);
            Point2D p3 = new Point2D(input3[0], input3[1]);

            var res = FindCenter(p1, p2, p3);

            Console.WriteLine(string.Format("{0:F4} {1:F4}", res.X, res.Y));
        }


        public static Point2D FindCenter(Point2D p1, Point2D p2, Point2D p3)
        {
            double t = p2.X * p2.X + p2.Y * p2.Y;
            double bc = (p1.X * p1.X + p1.Y * p1.Y - t) / 2.0;
            double cd = (t - p3.X * p3.X - p3.Y * p3.Y) / 2.0;
            double det = (p1.X - p2.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p2.Y);

            if (Math.Abs(det) > 1.0e-6) // Determinant was found. Otherwise, radius will be left as zero.
            {
                det = 1 / det;
                double x = (bc * (p2.Y - p3.Y) - cd * (p1.Y - p2.Y)) * det;
                double y = ((p1.X - p2.X) * cd - (p2.X - p3.X) * bc) * det;
                //double r = Math.Sqrt((x - p1.X) * (x - p1.X) + (y - p1.Y) * (y - p1.Y));

                var Centre = new Point2D(x, y);
                //this.Radius = r;
                return Centre;
            }
            return null;
        }
    }

    class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}




