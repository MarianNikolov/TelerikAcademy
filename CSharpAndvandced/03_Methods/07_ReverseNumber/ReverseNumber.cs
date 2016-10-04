using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseNumber
{
    static string ReadNumberAndReversTheDigits()
    {
        string number = Console.ReadLine();
        string newNumber = "";
        for (int i = number.Length - 1; i >= 0 ; i--)
        {
            newNumber += number[i];
        }
        return newNumber;
    }

    static void Main()
    {
        Console.WriteLine(ReadNumberAndReversTheDigits());
    }
}

