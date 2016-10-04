using System;

class IntDoubleAndString
{
    static void Main()
    {
        string typeOfInput = Console.ReadLine();

        if (typeOfInput == "integer")
        {
            int valueOfVariableInt = int.Parse(Console.ReadLine());
            Console.WriteLine(valueOfVariableInt + 1);
        }

        else if (typeOfInput == "real")
        {
            double valueOfVariableDouble = double.Parse(Console.ReadLine());
            double printValue = valueOfVariableDouble + 1;
            Console.WriteLine("{0:F2}", printValue);
        }
        else
        {
            string valueOfVariable = Console.ReadLine();
            Console.WriteLine(valueOfVariable + "*");
        }
    }
}

