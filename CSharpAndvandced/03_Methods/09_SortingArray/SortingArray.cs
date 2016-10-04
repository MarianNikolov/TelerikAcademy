using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortingArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        PrintSortedArray(array);

    }

    static void PrintSortedArray(int[] array)
    {
        Array.Sort(array);
        string forPrint = string.Empty;
        for (int i = 0; i < array.Length; i++)
        {
            forPrint += array[i] + " ";
        }
        Console.WriteLine(forPrint);
    }

}

