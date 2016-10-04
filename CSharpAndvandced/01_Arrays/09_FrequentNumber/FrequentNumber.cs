using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FrequentNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        var counter = 1;
        int number = 0;
        int countFinds = 0;

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < array.Length; i++)
        {
            counter = 1;
            for (int j = 0; j < array.Length; j++)
            {
                if (i == j)
                {
                    continue; 
                }
                else
                {
                    if (array[i] == array[j])
                    {
                        counter++;
                        if (counter > countFinds)
                        {
                            countFinds = counter;
                            number = array[i];
                        }
                    }
                }
            }
        }
        Console.WriteLine("{0} ({1} times)", number, countFinds);

    }
}

