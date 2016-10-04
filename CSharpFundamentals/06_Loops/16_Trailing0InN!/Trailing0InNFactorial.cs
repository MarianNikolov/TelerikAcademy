using System;
using System.Numerics;

class Trailing0InNFactorial
{

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 1;
        int counter = 0;

        while (n / Math.Pow(5, count) >= 1)
        {
            counter += n / (int)(Math.Pow(5, count));
            count++;
        }
        Console.WriteLine(counter);


       // int n = int.Parse(Console.ReadLine());
        
       // int counter = -1;
       // BigInteger digit = 0;
       // BigInteger factorial = 1;
       // for (int i = 1; i <= n; i++)
       // {
       //     factorial *= i;
       // }

       //// string numberString = factorial.ToString();
       //// for (int i = 0; i < numberString.Length; i++)
       //// {
       //// }

       // while (digit == 0)
       // {
       //     digit = factorial % 10;
       //     factorial /= 10;

       //     counter++;
       // }
       // Console.WriteLine(counter);
    }
}

