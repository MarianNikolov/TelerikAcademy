using System;

class FloatOrDouble
{

    //Problem 2. Float or Double?

    //Which of the following values can be assigned to a variable of type float and which to a variable of type double: 
    //34.567839023, 12.345, 8923.1234857, 3456.091?
    //Write a program to assign the numbers in variables and print them to ensure no precision is lost.

    static void Main()
    {
        double firstNumber = 34.567839023;
        float secondNumber = 12.345f;
        double thirdNumber = 8923.1234857;
        float fourthlyNumber = 3456.091f;
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
        Console.WriteLine(thirdNumber);
        Console.WriteLine(fourthlyNumber);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //from presentation
        Console.WriteLine("example of presentation");
        float floatPI = 3.141592653589793238f;
        double doublePI = 3.141592653589793238;
        Console.WriteLine("Float PI is: {0}", floatPI);
        Console.WriteLine("Double PI is: {0}", doublePI);


    }
}
