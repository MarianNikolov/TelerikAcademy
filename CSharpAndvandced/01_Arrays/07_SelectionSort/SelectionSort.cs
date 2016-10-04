using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SelectionSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        int exchange = -1;
        int minValue = int.MaxValue;
        int indexForExchange = -1;

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (i == array.Length)
            {
                break;
            }
            else
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < minValue)
                    {
                        minValue = array[j];
                        indexForExchange = j;
                    }
                }
                
                exchange = array[indexForExchange];
                array[indexForExchange] = array[i];
                array[i] = exchange;

                minValue = int.MaxValue;
                indexForExchange = -1;
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

        

        //while (sorted)
        //{
        //    for (int i = 0; i < array.Length - 1; i++)
        //    {
        //        if (array[i] > array[i + 1])
        //        {
        //            exchange = array[i + 1];
        //            array[i + 1] = array[i];
        //            array[i] = exchange;
        //            counterForExchange++;
        //        }
        //    }

        //    if (counterForExchange == 0)
        //    {
        //        for (int i = 0; i < array.Length; i++)
        //        {
        //            Console.WriteLine(array[i]);
        //            sorted = false;
        //        }
        //    }
        //    counterForExchange = 0;
        //}
    }
}

