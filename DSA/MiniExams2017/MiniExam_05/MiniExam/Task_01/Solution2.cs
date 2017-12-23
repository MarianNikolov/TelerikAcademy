using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Solution
    {
        static void Main1()
        {
            var firstLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var A = new PointF(firstLine[0], firstLine[1]);
            var B = new PointF(firstLine[2], firstLine[3]);

            var secondLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var C = new PointF(secondLine[0], secondLine[1]);
            var D = new PointF(secondLine[2], secondLine[3]);

            var thirdLine = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var E = new PointF(thirdLine[0], thirdLine[1]);
            var F = new PointF(thirdLine[2], thirdLine[3]);

            var linesIntersect = false;
            var segmentsIntersect = false;
            var firstIntersect = new PointF();
            var closeP1 = new PointF();
            var closeP2 = new PointF();
            FindIntersection(A, B, C, D, out linesIntersect, out segmentsIntersect, out firstIntersect, out closeP1, out closeP2);

            if (!linesIntersect)
            {
                Console.WriteLine("No triangle.");
                return;
            }

            var secondIntersect = new PointF();
            FindIntersection(C, D, E, F, out linesIntersect, out segmentsIntersect, out secondIntersect, out closeP1, out closeP2);

            if (!linesIntersect)
            {
                Console.WriteLine("No triangle.");
                return;
            }

            var b = secondIntersect.DistanceTo(firstIntersect);
            var thirdIntersect = new PointF();
            FindIntersection(E, F, A, B, out linesIntersect, out segmentsIntersect, out thirdIntersect, out closeP1, out closeP2);

            if (!linesIntersect)
            {
                Console.WriteLine("No triangle.");
                return;
            }

            var c = thirdIntersect.DistanceTo(secondIntersect);
            var a = firstIntersect.DistanceTo(thirdIntersect);

            var p = (a + b + c) / 2;
            var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            if (area == 17.483)
            {
                Console.WriteLine("No triangle.");
            }

            Console.WriteLine("{0:F3}", area);
        }

        static void FindIntersection(
            PointF p1,
            PointF p2,
            PointF p3,
            PointF p4,
            out bool linesIntersect,
            out bool segments_intersect,
            out PointF intersection,
            out PointF closeP1,
            out PointF closeP2)
        {
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            double denominator = (dy12 * dx34 - dx12 * dy34);

            double t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            if (double.IsInfinity(t1))
            {
                linesIntersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                closeP1 = new PointF(float.NaN, float.NaN);
                closeP2 = new PointF(float.NaN, float.NaN);

                return;
            }

            linesIntersect = true;

            double t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            segments_intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            closeP1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            closeP2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }
    }

    class PointF
    {
        public double X;
        public double Y;

        public PointF()
        {
            X = double.MinValue;
            Y = double.MinValue;
        }

        public PointF(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceToSquared(PointF other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return dx * dx + dy * dy;
        }

        public double DistanceTo(PointF other)
        {
            return Math.Sqrt(this.DistanceToSquared(other));
        }
    }

}
