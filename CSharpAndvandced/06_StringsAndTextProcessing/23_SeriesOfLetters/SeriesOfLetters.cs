using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder forPrint = new StringBuilder();
        forPrint.Append(input[0]);

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                forPrint.Append(input[i]);
            }
        }

        Console.WriteLine(forPrint.ToString());
    }
}

