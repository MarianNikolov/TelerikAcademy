using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SoupScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] print = new string[n];

        // StringBuilder print = new StringBuilder();
        string line = string.Empty;
        int numScope = 0;

        for (int i = 0; i < n; i++)
        {
            line = Console.ReadLine();
            if (line.Trim() == "}")
            {
                numScope--;
                print[i] = line.Trim();
            }

            if (numScope > 0 && line.Trim() != "}")
            {
                for (int j = 0; j < numScope; j++)
                {
                    print[i] += "    ";
                }
                //print[i] = new string(' ', numScope * 4);
                print[i] += line;
            }

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '{')
                {
                    numScope++;
                }
                if (line[j] == '}')
                {
                    numScope--;
                }
            }
            print[i] = line;
        }


        // print
        for (int i = 0; i < n; i++)
			{
                Console.WriteLine(print[i]);			 
			}
    }
}
