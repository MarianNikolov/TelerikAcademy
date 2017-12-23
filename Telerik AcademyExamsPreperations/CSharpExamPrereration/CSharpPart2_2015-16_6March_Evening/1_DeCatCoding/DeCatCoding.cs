using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class DeCatCoding
{
    static long ConvertBaseToDecimal(string number, int numeralSystem)
    {

        long decimalNumber = 0;
        for (int i = 0; i < number.Length; i++)
        {
            int digit = 0;

            // if (number[i] >= '0' && number[i] <= '9')
            // {
            //     digit = number[i] - '0';
            // }

            //  else // (number[i] >= 'A' && number[i] <= 'Z')
            //  {
            digit = number[i] - 'a';
            //  }

            // POSITION  = hex.Length - i - 1 
            // math.pow(osnovata na sistemata na stepen poziciqta)
            decimalNumber += digit * (long)BigInteger.Pow(numeralSystem, number.Length - i - 1);
        }
        return decimalNumber;
    }


    // max numeral system 36 symbols
    static string ConvertDecimalToBase(long decimalNumber, int numeralSystem)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            long digit = decimalNumber % numeralSystem;
            //  if (digit >= 0 && digit <= 9)
            //  {
            //      result = (char)(digit + '0') + result;
            //  }
            //  else // vsqka ot 'A' do 'Z'
            //  {
            result = (char)(digit + 'a') + result;
            //   }
            decimalNumber /= numeralSystem;
        }
        return result;
    }



    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' });

        char[] numeralSystem = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 
                                   'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u' }; //v w x y z 

        for (int i = 0; i < input.Length; i++)
        {
            long inputToDecimal = ConvertBaseToDecimal(input[i], 21);
            string inputTo26NumeralSystem = ConvertDecimalToBase(inputToDecimal, 26);

            if (input.Length - 1 == i)
            {
                Console.Write("{0}", inputTo26NumeralSystem);
            }

            else
            {
                Console.Write("{0} ", inputTo26NumeralSystem);
            }
        }
    }
}

