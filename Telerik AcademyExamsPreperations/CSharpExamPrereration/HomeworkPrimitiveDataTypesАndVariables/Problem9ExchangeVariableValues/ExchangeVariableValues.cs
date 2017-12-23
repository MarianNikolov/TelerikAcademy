using System;

class ExchangeVariableValues
{
    //Problem 9. Exchange Variable Values

    //Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
    //Print the variable values before and after the exchange.

    static void Main(string[] args)
    {
        int a = 5;
        int b = 10;

        Console.WriteLine(a);
        Console.WriteLine(b);
        int newA = b;
        int newB = a;
        Console.WriteLine(newA);
        Console.WriteLine(newB);
    }
}

