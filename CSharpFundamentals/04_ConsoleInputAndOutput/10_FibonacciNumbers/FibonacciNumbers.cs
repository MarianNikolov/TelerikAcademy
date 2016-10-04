using System;

class FibonacciNumbers
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long numberA = 0;
        long numberB = 1;
        long numberFibonacci = 0;
        
        if (n == 0)
        {
            Console.WriteLine("0");
            return;
        }
        
        if (n == 1)
        {
            Console.WriteLine(numberA);
            return;
        }
        
        if (n == 2)
        {
            Console.WriteLine(numberA + ", " + numberB + ", ");
            return;
        }

        Console.Write("{0}, {1}", numberA, numberB);
        
        for (int i = 0; i < n - 2; i++)
        {
            numberFibonacci = numberA + numberB;
            Console.Write(", {0}", numberFibonacci);
            numberA = numberB;
            numberB = numberFibonacci;
        }
    }
}

