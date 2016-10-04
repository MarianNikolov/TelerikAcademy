using System;

class ComparingFloats
{
    static void Main()
    {
        double numberA = double.Parse(Console.ReadLine());
        double numberB = double.Parse(Console.ReadLine());
        bool result = Math.Abs(numberA - numberB) <= 0.000001;
        if (result == true)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
        
        
    }
}

//  numberA = Math.Round(numberA, 6); 
//  numberB = Math.Round(numberB, 6);
//  Console.WriteLine(numberA);
//  Console.WriteLine(numberB);
