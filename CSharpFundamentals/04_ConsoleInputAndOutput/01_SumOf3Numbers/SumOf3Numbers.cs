using System;

class SumOf3Numbers
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        double numberForPrint = firstNumber + secondNumber + thirdNumber;
        Console.WriteLine(numberForPrint);
    }
}
