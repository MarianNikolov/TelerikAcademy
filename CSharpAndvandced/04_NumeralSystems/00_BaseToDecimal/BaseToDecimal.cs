using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BaseToDecimal
{
    static void Main()
    {
        string number = Console.ReadLine();
        Console.WriteLine(ConvertBaseToDecimal(number, 36));
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
            decimalNumber += digit * (long)Math.Pow(numeralSystem, number.Length - i - 1);
        }
        return decimalNumber;
    }
}

