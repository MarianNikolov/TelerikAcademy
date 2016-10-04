using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargerThanNeighbours
{
    static int[] ReadAndFillArray()
    {
        // { ",", " ", ", " }
        int lenghtOfArray = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();
        return array;
    }

    static int ChecksElementAtPositionInArrayIsLargerThanItsTwoNeighbours(int[] array)
    {
        int counetr = 0;
        if (array.Length > 2)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] < array[i] && array[i + 1] < array[i] )
                {
                    counetr++;
                }
            }
        }
        return counetr;
    }

    static void Main()
    {
        int[] array = ReadAndFillArray();
        Console.WriteLine(ChecksElementAtPositionInArrayIsLargerThanItsTwoNeighbours(array));
    }
}