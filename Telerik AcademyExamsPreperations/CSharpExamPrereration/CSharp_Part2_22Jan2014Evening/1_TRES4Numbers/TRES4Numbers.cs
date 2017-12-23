using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class TRES4Numbers
{
    // max numeral system 36 symbols
    static string ConvertDecimalToBase(BigInteger decimalNumber, int numeralSystem)
    {
        string result = "";

        while (decimalNumber > 0)
        {
            BigInteger digit = decimalNumber % numeralSystem;
            if (digit == 0)
            {
                result = "LON+" + result;
            }
            else if (digit == 1)
            {
                result = "VK-" + result;
                
            }
            else if (digit == 2)
            {
                result = "*ACAD" + result;

            }
            else if (digit == 3)
            {
                result = "^MIM" + result;

            }
            else if (digit == 4)
            {
                result = "ERIK|" + result;

            }
            else if (digit == 5)
            {
                result = "SEY&" + result;

            }
            else if (digit == 6)
            {
                result = "EMY>>" + result;

            }
            else if (digit == 7)
            {
                result = "/TEL" + result;

            }
            else if (digit == 8)
            {
                result = "<<DON" + result;

            }
            

           // switch (digit)
           // {
           //     case 0: result = "LON+" + result; break;
           //     case 1: result = "VK-" + result; break;
           //     case 2: result = "*ACAD" + result; break;
           //     case 3: result = "^MIM" + result; break;
           //     case 4: result = "ERIK|" + result; break;
           //     case 5: result = "SEY&" + result; break;
           //     case 6: result = "EMY>>" + result; break;
           //     case 7: result = "/TEL" + result; break;
           //     case 8: result = "<<DON" + result; break;
           //     default:
           //         break;
           // }
            decimalNumber /= numeralSystem;


            // if (digit >= 0 && digit <= 9)
            // {
            //     result = (char)(digit + '0') + result;
            // }
            // else // vsqka ot 'A' do 'Z'
            // {
            //     result = (char)((digit - 10) + 'A') + result;
            // }
            // decimalNumber /= numeralSystem;
        }
        return result;
    }


    static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine().Replace(" ", ""));

        if (input == 0)
        {
            Console.WriteLine("LON+");
        }
        else
        {
            Console.WriteLine(ConvertDecimalToBase(input, 9));
        }


    }
}

