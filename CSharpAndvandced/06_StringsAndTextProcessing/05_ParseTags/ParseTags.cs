using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ParseTags
{


    static void Main()
    {
        string start = "<upcase>";
        string stop = "</upcase>";

        string input = Console.ReadLine();

        StringBuilder printStrig = new StringBuilder();

        int curentIndex = input.IndexOf(start);
        int startIndex = 0;

        while (curentIndex != -1)
        {
            printStrig.Append(input.Substring(startIndex, curentIndex - startIndex));
            startIndex = curentIndex + start.Length;

            // upper
            curentIndex = input.IndexOf(stop, startIndex);
            printStrig.Append(input.Substring(startIndex, curentIndex - startIndex).ToUpper());

            startIndex = curentIndex + stop.Length;
            curentIndex = input.IndexOf(start, curentIndex);
        }

        if (!string.IsNullOrEmpty(printStrig.ToString()))
        {
            int lastTextIndex = input.LastIndexOf(stop) + stop.Length;
            printStrig.Append(input.Substring(lastTextIndex));
            Console.WriteLine(printStrig.ToString());

        }
        else
        {
            Console.WriteLine(input);
        }


    }
}

