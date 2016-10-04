using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class OneSystemToAnyOther
{
    static void Main()
    {
        int baseS = int.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        int baseD = int.Parse(Console.ReadLine());
        Console.WriteLine(ConvertDecimalToBase(ConvertBaseToDecimal(number, baseS), baseD));
    }

    static long ConvertBaseToDecimal(string number, int numeralSystem)
    {
        
        long decimalNumber = 0;
        for (int i = 0; i < number.Length; i++)
        {
            int digit = 0;

            if (number[i] >= '0' && number[i] <= '9')
            {
                digit = number[i] - '0';
            }

            else // (number[i] >= 'A' && number[i] <= 'Z')
            {
                digit = number[i] - 'A' + 10;
            }

            // POSITION  = hex.Length - i - 1 
            // math.pow(osnovata na sistemata na stepen poziciqta)
            decimalNumber += digit * (long)BigInteger.Pow(numeralSystem, number.Length - i - 1);
        }
        return decimalNumber;
    }

    static string ConvertDecimalToBase(long decimalNumber, int numeralSystem)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            long digit = decimalNumber % numeralSystem;
            if (digit >= 0 && digit <= 9)
            {
                result = (char)(digit + '0') + result;
            }
            else // vsqka ot 'A' do 'Z'
            {
                result = (char)((digit - 10) + 'A') + result;
            }
            decimalNumber /= numeralSystem;
        }
        return result;
    }
}

