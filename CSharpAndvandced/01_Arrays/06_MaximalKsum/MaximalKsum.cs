using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalKsum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int[] arrayK = new int[k];
        int maxValue = 0;
        int indexOfMaxValue = 0;
        int sumOfK = 0;

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < k; i++)
        {
            maxValue = array[0];
            for (int e = 0; e < array.Length; e++)
            {
                if (maxValue <= array[e])
                {
                    maxValue = array[e];
                    indexOfMaxValue = e;
                }
            }
            array[indexOfMaxValue] = int.MinValue;
            sumOfK += maxValue;
        }
        Console.WriteLine(sumOfK);
    }
}

