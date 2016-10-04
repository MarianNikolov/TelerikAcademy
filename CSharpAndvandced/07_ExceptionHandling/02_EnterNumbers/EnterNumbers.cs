using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EnterNumbers
{
    static void Main()
    {
        int start = 1;
        int stop = 100;
        int[] array = new int[] { };

        try
        {
            array = ReadNumber(start, stop);
        }
        catch (Exception)
        {
            Console.WriteLine("Exception");
            return;
            // throw;Exception
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} < ", array[i]);
        }
        Console.Write(stop);

    }

    private static int[] ReadNumber(int start, int stop)
    {

        int[] array = new int[11];

        array[0] = start;

        for (int i = 1; i <= array.Length - 1; i++)
        {
            int curentNumber = int.Parse(Console.ReadLine());

            if (curentNumber > array[i - 1] && curentNumber < stop)
            {
                array[i] = curentNumber;
            }
            else
            {
                throw new ArgumentException();
                //Console.WriteLine("Exception");
            }
        }

        return array;
    }
}

