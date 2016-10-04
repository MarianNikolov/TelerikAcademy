using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AppearanceCount
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

    static int FindHowManyTimesMeetingDigitInArray(int[] array, int digit)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == digit)
            {
                counter++;
            }
        }
        return counter;
    }
    static void Main()
    {
        int[] array = ReadAndFillArray();
        int digitForFind = int.Parse(Console.ReadLine());
        Console.WriteLine(FindHowManyTimesMeetingDigitInArray(array, digitForFind));
    }
}

