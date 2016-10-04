using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirstLargerThanNeighbours
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

    static int ReturnIndexOnTheFirstElementAtPositionInArrayIsLargerThanItsTwoNeighbours(int[] array)
    {
        int index = -1;
        if (array.Length > 2)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] < array[i] && array[i + 1] < array[i])
                {
                    index = i;
                    break;
                }
            }
        }
        
        return index;
    }

    static void Main()
    {
        int[] array = ReadAndFillArray();
        Console.WriteLine(ReturnIndexOnTheFirstElementAtPositionInArrayIsLargerThanItsTwoNeighbours(array));
    }
}

