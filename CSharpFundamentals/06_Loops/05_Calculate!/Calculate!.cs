using System;

class Calculate
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double factorial = 1;
        double s = 1;
        int pow = 1;

        for (int i = 1; i <= n; i++)
        {
            //   S = 1 + 1!/x + 2!/x2 + … + N!/xN

            factorial = factorial * i;
            s += factorial / (Math.Pow(x, pow)); 

            pow++;
        }
        Console.WriteLine("{0:F5}", s);
    }
}

