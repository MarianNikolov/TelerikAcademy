using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = int.MinValue;
        int curentSum = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            curentSum = array[i];
            for (int j = i + 1; j < array.Length; j++)
            {   
                curentSum += array[j];
                if (curentSum > maxSum)
                {
                    maxSum = curentSum;   
                }
            }
        }
        Console.WriteLine(maxSum);
    }
}

