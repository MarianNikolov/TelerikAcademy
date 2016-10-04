using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GetLargestNumber
{
    static int GetMax(int first, int second)
    {
        int max = first;
        if (max < second)
        {
            max = second;
        }
        return max;
    }

    static int[] ReadArray()
    {
        // { ",", " ", ", " }
        int[] array = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();
        return array;
    }

    static void Main()
    {
        int[] array = ReadArray();
        for (int i = 0; i < array.Length; i += 3)
        {
            Console.WriteLine(GetMax(GetMax(array[i], array[i + 1]), array[i + 2]));
        }
    }
}

