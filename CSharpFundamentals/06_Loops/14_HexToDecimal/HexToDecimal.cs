using System;

class HexToDecimal
{
    static void Main()
    {
        string hexNum = Console.ReadLine();
        long decimalNum = 0;


        for (int i = 0; i < hexNum.Length; i++)
        {
            
            switch (hexNum[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    decimalNum += long.Parse(hexNum[i].ToString()) * (long)Math.Pow(16, hexNum.Length - 1 - i);
                    break;

                case 'A':
                    decimalNum += 10 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;
                case 'B':
                    decimalNum += 11 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;
                case 'C':
                    decimalNum += 12 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;
                case 'D':
                    decimalNum += 13 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;
                case 'E':
                    decimalNum += 14 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;
                case 'F':
                    decimalNum += 15 * (long)Math.Pow(16, hexNum.Length - 1 - i); break;

                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }

        Console.WriteLine(decimalNum);



    }
}

