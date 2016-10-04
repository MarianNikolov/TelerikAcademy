using System;
using System.Numerics;

class CalculateAgain
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger k = BigInteger.Parse(Console.ReadLine());
        BigInteger factorialN = 1;
        BigInteger factorialK = 1;

        for (int i = 1; i <= n; i++)
        {
            if (i <= k)
            {
                factorialK *= i;
            }
            factorialN *= i;
        }
        Console.WriteLine(factorialN / factorialK);
    }
}

