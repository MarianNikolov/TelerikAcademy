using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MultiverseCommunication
{

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var alphabet = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
        
        long decimalRepresentation = 0;

        for (int i = 0; i < input.Length; i += 3)
        {
            var digitOn13 = input.Substring(i, 3);

            int decimalValue = alphabet.IndexOf(digitOn13);

            decimalRepresentation *= 13;  // numeral system e 13
            decimalRepresentation += decimalValue;
        }

        Console.WriteLine(decimalRepresentation);

    }
}


    //const int NumeralSystemBase = 12;

    //static int ConvertZergDigitToInt(string curentZergDigit)
    //{
    //    int digit = 0;
    //    string[] zergNumeralSystem = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
    //    for (int i = 0; i < zergNumeralSystem.Length; i++)
    //    {
    //        if (zergNumeralSystem[i] == curentZergDigit)
    //        {
    //            digit = i;
    //        }
    //    }
    //    return digit;
    //}

    //static long PowerOfFifteen(int power)
    //{
    //    long result = 1;

    //    for (int i = 0; i < power; i++)
    //    {
    //        result *= NumeralSystemBase;
    //    }

    //    return result;
    //}

    //static void Main(string[] args)
    //{
    //    string zergNumber = Console.ReadLine();
    //    long result = 0;

    //    int position = zergNumber.Length / 3 - 1; 

    //    string currentZergDigit = "";

    //    for (int i = 0; i < zergNumber.Length; i += 3)
    //    {
    //        currentZergDigit = zergNumber.Substring(i, 3);

    //        result += ConvertZergDigitToInt(currentZergDigit) * PowerOfFifteen(position);

    //        position--;
    //    }
    //    Console.WriteLine(result);
