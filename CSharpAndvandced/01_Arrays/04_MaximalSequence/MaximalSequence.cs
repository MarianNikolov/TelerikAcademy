using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaximalSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int counter = 1;
        int maxSequence = 0;

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine()); 
        }

        for (int e = 0; e < array.Length - 1; e++)
        {
            if (array[e] == array[e + 1])
            {
                counter++;
                if (counter > maxSequence)
                {
                    maxSequence = counter;
                }
            }
            else
            {
                counter = 1;
            }
        }
        Console.WriteLine(maxSequence);
    }
}

