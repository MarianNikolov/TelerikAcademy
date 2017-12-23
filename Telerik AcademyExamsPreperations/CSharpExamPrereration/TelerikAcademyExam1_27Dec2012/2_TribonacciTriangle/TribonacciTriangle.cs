using System;

class TribonacciTriangle
{
    static void Main()
    {
        long firstNumber = long.Parse(Console.ReadLine());
        long secondNumber = long.Parse(Console.ReadLine());
        long thirdNumber = long.Parse(Console.ReadLine());
        long numberOfRows = long.Parse(Console.ReadLine());
        long numberForCalculation = 0;

        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber + " " + thirdNumber);

        for (int i = 3; i < n; i++)
        {
            numberForCalculation = firstNumber + secondNumber + thirdNumber;
            
            Console.Write(numberForCalculation + " ");
            
            firstNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = numberForCalculation;
            
        }
    }
}

