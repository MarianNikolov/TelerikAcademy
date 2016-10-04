using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SumIntegers
{
    static int SumArray(int[] array)
    {
        return array.Sum();
    }

    static void Main()
    {
        int[] array = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();
        Console.WriteLine(SumArray(array));
    }
}

