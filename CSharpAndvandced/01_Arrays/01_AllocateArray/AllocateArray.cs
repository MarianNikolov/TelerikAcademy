using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AllocateArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];


        for (int i = 0; i < n; i++)
        {
            array[i] = i * 5;
            Console.WriteLine(array[i]);
        }
    }
}

