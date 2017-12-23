using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_TextToNumber
{
    class TextToNumber
    {
        static void Main(string[] args)
        {
            long numberM = long.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            long result = 0;
            char curentChar = ' ';

            if (text[0] >= '0' && text[0] <= '9')
            {
                result = 1;
            }

            for (int i = 0; i < text.Length; i++)
            {
                curentChar = text[i];

                if (curentChar == '@')
                {
                    break;
                }

                else if (curentChar >= 'a' && curentChar <= 'z')
                {
                    result = result + (curentChar - 'a');
                }

                else if (curentChar >= 'A' && curentChar <= 'Z')
                {
                    result = result + (curentChar - 'A');
                }

                else if (curentChar >= '0' && curentChar <= '9')
                {
                    result = result * (curentChar - '0');
                }

                else
                {
                    result = result % numberM;
                }

            }
            Console.WriteLine(result);

        }
    }
}
