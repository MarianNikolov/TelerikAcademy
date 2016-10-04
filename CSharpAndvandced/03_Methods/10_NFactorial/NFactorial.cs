﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class NFactorial
{
    static BigInteger Factorial(int number)
    {
        BigInteger factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Factorial(number));
    }
}
