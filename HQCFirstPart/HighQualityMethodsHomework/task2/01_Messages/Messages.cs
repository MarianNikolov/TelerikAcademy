using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Messages
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string operation = Console.ReadLine();
        string secondLine = Console.ReadLine();


        StringBuilder firstNumber = new StringBuilder();;
        StringBuilder secondNumber = new StringBuilder();;

        for (int i = 0; i < firstLine.Length; i += 3)
        {
            if (firstLine[i] == 'c' && firstLine[i + 1] == 'a'&& firstLine[i + 2] == 'd')
            {
                firstNumber.Append('0');
            }
            else if (firstLine[i] == 'x' && firstLine[i + 1] == 'o' && firstLine[i + 2] == 'z')
            {
                firstNumber.Append('1'); 
            }
            else if (firstLine[i] == 'n' && firstLine[i + 1] == 'o' && firstLine[i + 2] == 'p')
            {
                firstNumber.Append('2');
            }
            else if (firstLine[i] == 'c' && firstLine[i + 1] == 'y' && firstLine[i + 2] == 'k')
            {
                firstNumber.Append('3');
            }
            else if (firstLine[i] == 'm' && firstLine[i + 1] == 'i' && firstLine[i + 2] == 'n')
            {
                 firstNumber.Append('4');
            }
            else if (firstLine[i] == 'm' && firstLine[i + 1] == 'a' && firstLine[i + 2] == 'r')
            {
                 firstNumber.Append('5');
            }
            else if (firstLine[i] == 'k' && firstLine[i + 1] == 'o' && firstLine[i + 2] == 'n')
            {
                 firstNumber.Append('6');
            }
            else if (firstLine[i] == 'i' && firstLine[i + 1] == 'v' && firstLine[i + 2] == 'a')
            {
                 firstNumber.Append('7');
            }
            else if (firstLine[i] == 'o' && firstLine[i + 1] == 'g' && firstLine[i + 2] == 'i')
            {
                 firstNumber.Append('8');
            }
            else if (firstLine[i] == 'y' && firstLine[i + 1] == 'a' && firstLine[i + 2] == 'n')
            {
                 firstNumber.Append('9');
            }
        }

        for (int i = 0; i < secondLine.Length; i += 3)
        {
            if (secondLine[i] == 'c' && secondLine[i + 1] == 'a' && secondLine[i + 2] == 'd')
            {
                secondNumber.Append('0');
            }
            else if (secondLine[i] == 'x' && secondLine[i + 1] == 'o' && secondLine[i + 2] == 'z')
            {
                secondNumber.Append('1');
            }
            else if (secondLine[i] == 'n' && secondLine[i + 1] == 'o' && secondLine[i + 2] == 'p')
            {
                secondNumber.Append('2');
            }
            else if (secondLine[i] == 'c' && secondLine[i + 1] == 'y' && secondLine[i + 2] == 'k')
            {
               secondNumber.Append('3');
            }
            else if (secondLine[i] == 'm' && secondLine[i + 1] == 'i' && secondLine[i + 2] == 'n')
            {
                secondNumber.Append('4');
            }
            else if (secondLine[i] == 'm' && secondLine[i + 1] == 'a' && secondLine[i + 2] == 'r')
            {
                secondNumber.Append('5');
            }
            else if (secondLine[i] == 'k' && secondLine[i + 1] == 'o' && secondLine[i + 2] == 'n')
            {
                secondNumber.Append('6');
            }
            else if (secondLine[i] == 'i' && secondLine[i + 1] == 'v' && secondLine[i + 2] == 'a')
            {
                secondNumber.Append('7');
            }
            else if (secondLine[i] == 'o' && secondLine[i + 1] == 'g' && secondLine[i + 2] == 'i')
            {
                secondNumber.Append('8');
            }
            else if (secondLine[i] == 'y' && secondLine[i + 1] == 'a' && secondLine[i + 2] == 'n')
            {
                secondNumber.Append('9');
            }
        }
        BigInteger first = BigInteger.Parse(firstNumber.ToString());
        BigInteger second = BigInteger.Parse(secondNumber.ToString());
        BigInteger result = 0;

        if (operation == "-")
        {
            result = first - second;
        }
        else
        {
            result = first + second;
        }

        string curentResult = result.ToString();
        StringBuilder print = new StringBuilder();

        for (int i = 0; i < curentResult.Length; i++)
        {
            if (curentResult[i] == '0')
            {
                print.Append("cad");
            }
            else if (curentResult[i] == '1')
            {
                print.Append("xoz");
            }
            else if (curentResult[i] == '2')
            {
                print.Append("nop");
            }
            else if (curentResult[i] == '3')
            {
                print.Append("cyk");
            }
            else if (curentResult[i] == '4')
            {
                print.Append("min");
            }
            else if (curentResult[i] == '5')
            {
                print.Append("mar");
            }
            else if (curentResult[i] == '6')
            {
                print.Append("kon");
            }
            else if (curentResult[i] == '7')
            {
                print.Append("iva");
            }
            else if (curentResult[i] == '8')
            {
                print.Append("ogi");
            }
            else if (curentResult[i] == '9')
            {
                print.Append("yan");
            }
        }
        Console.WriteLine(print);
    }
}

