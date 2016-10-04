using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = 0;

      //  if (b % 2 == 0)
      //  {
      //      double k = b / 2;
      //      d = (Math.Pow(k, 2)) - 4 * a * c;
      //
      //      if (d < 0)
      //      {
      //          Console.WriteLine("no real roots");
      //      }
      //      if (d == 0)
      //      {
      //          double x = -k / a;
      //          Console.WriteLine("{0:f2}", x);
      //      }
      //      if (d > 0)
      //      {
      //          double x1 = (-k + Math.Sqrt(d)) / a;
      //          double x2 = (-k - Math.Sqrt(d)) / a;
      //          if (x1 < x2)
      //          {
      //              Console.WriteLine("{0:f2}", x1);
      //              Console.WriteLine("{0:f2}", x2);
      //          }
      //          else
      //          {
      //              Console.WriteLine("{0:f2}", x2);
      //              Console.WriteLine("{0:f2}", x1);
      //          }
      //      }
      //  }

        d = (Math.Pow(b, 2)) - (4 * a * c);

        if (d < 0)
        {
            Console.WriteLine("no real roots");
        }
        if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("{0:f2}", x);
        }
        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            if (x1 < x2)
            {
                Console.WriteLine("{0:f2}", x1);
                Console.WriteLine("{0:f2}", x2);
            }
            else
            {
                Console.WriteLine("{0:f2}", x2);
                Console.WriteLine("{0:f2}", x1);
            }

        }

    }
}

