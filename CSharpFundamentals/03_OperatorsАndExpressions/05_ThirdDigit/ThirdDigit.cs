using System;

class ThirdDigit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int number = n / 100;
        if (number % 10 == 7)
        {
            Console.WriteLine("true");
        }
        else
        {
            int numberPrint = number % 10;
            Console.WriteLine("false " + numberPrint);
        }
    }
}
