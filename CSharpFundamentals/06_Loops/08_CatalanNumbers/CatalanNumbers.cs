using System;
using System.Numerics;

class CatalanNumbers
{
    static BigInteger Factorial(BigInteger n)
    {
        BigInteger factorial = 1;
        for (int i = 1; i <= n; i++)
			{
                factorial *= i;
			}

        return factorial; 
    }


    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger c = 1;

        for (int i = 1; i <= n; i++)
        {
            c = Factorial(2 * n) / (Factorial(n+1) * Factorial(n));
        }
        Console.WriteLine(c);
    }
}

