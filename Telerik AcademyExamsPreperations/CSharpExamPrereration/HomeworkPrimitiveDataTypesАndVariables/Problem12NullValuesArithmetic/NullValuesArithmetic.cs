using System;

class NullValuesArithmetic
{

    //Problem 12. Null Values Arithmetic

    //Create a program that assigns null values to an integer and to a double variable.
    //Try to print these variables at the console.
    //Try to add some number or the null literal to these variables and print the result.

    static void Main()
    {
        int? firstVar = null;
        double? secondVar = null;
        
        Console.WriteLine(firstVar);
        Console.WriteLine(secondVar);
        Console.WriteLine(firstVar + 5);
        Console.WriteLine(secondVar + 5);
        Console.WriteLine(firstVar + null);
        Console.WriteLine(secondVar + null);
        Console.WriteLine(firstVar + "aa");
        Console.WriteLine(secondVar + "bb");
    }
}

