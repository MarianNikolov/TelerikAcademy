using System;

class Sort3Numbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a > b && a > c )
        {
            Console.Write(a);
            if (b > c)
            {
                Console.WriteLine(" {0} {1}", b, c);
            }
            else
            {
                Console.WriteLine(" {0} {1}", c, b);

            }
            return;
        }

        if (b > a && b > c)
        {
            Console.Write(b);
            if (a > c)
            {
                Console.WriteLine(" {0} {1}", a, c);
            }
            else
            {
                Console.WriteLine(" {0} {1}", c, a);

            }
            return;
        }

        if (c > a && c > b)
        {
            Console.Write(c);
            if (a > b)
            {
                Console.WriteLine(" {0} {1}", a, b);
            }
            else
            {
                Console.WriteLine(" {0} {1}", b, a);

            }
            return;
        }
        if (a == b && a == c && c ==b)
        {
            Console.WriteLine("{0} {1} {2}", a, b, c);
        }

    }
}

