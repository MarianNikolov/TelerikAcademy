using System;

class Program
{
    /*
        Write an expression that checks if given integer is odd or even.

        Examples:
        n 	Odd?
        3 	true
        2 	false
        -2 	false
        -1 	true
        0 	false
     */

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 1)
        {
            Console.WriteLine(true);
        }

        else
        {
            Console.WriteLine(false);
        }
    }
}

