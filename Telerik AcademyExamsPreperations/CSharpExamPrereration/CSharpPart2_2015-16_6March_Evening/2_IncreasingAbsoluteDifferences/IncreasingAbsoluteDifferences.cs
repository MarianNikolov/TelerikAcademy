using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IncreasingAbsoluteDifferences
{
    static int[] AbsoluteDifference(int[] array) 
    {
        int[] arrayForReturn = new int[array.Length - 1];

        for (int i = 0; i < array.Length - 1; i++)
        {
            arrayForReturn[i] = Math.Abs(array[i] - array[i + 1]);
        }

        return arrayForReturn;
    }


    static bool InIncreasingSequence(int[] array)
    {
        bool result = true;

        for (int i = 1; i < array.Length; i++)
        {
            if (!(array[i - 1] <= array[i]))
            {
                result = false;
                return result;
            }

            if ((array[i] - array[i - 1]) >= 2)
            {
                result = false;
                return result;
            }
        }
        return result;
    }

    static void Main()
    {

        int numberRows = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberRows; i++)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] absDiference = AbsoluteDifference(input);
            Console.WriteLine(InIncreasingSequence(absDiference));

        }


    }
}

