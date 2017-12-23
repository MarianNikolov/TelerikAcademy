using System;

class Decoding
{
    static void Main()
    {
        int salt = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char curentChar = ' ';
        decimal sumForPrint = 0;

        for (int i = 0; i < text.Length; i++)
        {
            curentChar = text[i];

            // break
            if (text[i] == '@')
            {
                break;
            }

            // letter
            if ((text[i] >= 'A' && text[i] <= 'Z') || (text[i] >= 'a' && text[i] <= 'z'))
            {
                sumForPrint = (curentChar * salt) + 1000;
            }

            // bigit

            else if ((text[i] >= '0' && text[i] <= '9'))
            {
                sumForPrint = (curentChar + salt) + 500;
            }

            else
            {
                sumForPrint = curentChar - salt;
            }

            // output
            if (i % 2 == 0)
            {
                Console.WriteLine("{0:F2}", sumForPrint / 100);
            }
            else
            {
                Console.WriteLine("{0}", sumForPrint * 100);
            }
        }
    }
}

