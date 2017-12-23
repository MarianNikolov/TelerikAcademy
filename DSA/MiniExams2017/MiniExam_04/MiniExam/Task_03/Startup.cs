using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Startup
    {
        static void Main()
        {
            //List<int> input = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            var firstVertex = Console.ReadLine().Split(' ');
            var secondVertex = Console.ReadLine().Split(' ');

            var firstPoint = new Point();
            firstPoint.X = int.Parse(firstVertex[0]);
            firstPoint.Y = int.Parse(firstVertex[1]);

            var secondPoint = new Point();
            secondPoint.X = int.Parse(secondVertex[0]);
            secondPoint.Y = int.Parse(secondVertex[1]);

            var vertex3 = Console.ReadLine().Split(' ');
            var pointC = new Point();
            pointC.X = int.Parse(vertex3[0]);
            pointC.Y = int.Parse(vertex3[1]);

            var ABDistance = firstPoint.GetDistanceTo(secondPoint);
            var BCDistance = secondPoint.GetDistanceTo(pointC);
            var ACDistance = firstPoint.GetDistanceTo(pointC);
            var p = (ABDistance + BCDistance + ACDistance) / 2;
            var area1 = p * (p - ABDistance) * (p - BCDistance) * (p - ACDistance);
            var res = Math.Sqrt(area1);
            var heightAB = (2 * res) / ABDistance;
            var heightBC = (2 * res) / BCDistance;
            var heightAC = (2 * res) / ACDistance;


            Console.WriteLine("{0:0.00}", heightBC);
            Console.WriteLine("{0:0.00}", heightAC);
            Console.WriteLine("{0:0.00}", heightAB);
        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistanceTo(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
