using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MaximalSum
{
    static void Main()
    {
        int[] NandM = Console.ReadLine()
            .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int[,] array = new int[NandM[0],NandM[1]];
        
        for (int row = 0; row < NandM[0]; row++)
        {
            int[] curenRowArray = Console.ReadLine()
                .Split(new[] {' '}, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            for (int col = 0; col < curenRowArray.Length; col++)
            {
                array[row, col] = curenRowArray[col];
            }
        }

        int maximalSum = int.MinValue;
        
        for (int row = 0; row < array.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < array.GetLength(1) - 2; col++)
            {
                int curentValue = array[row, col] + array[row, col+1] + array[row, col+2] + 
                    array[row+1, col] + array[row+1, col+1] + array[row+1, col+2] + 
                    array[row+2, col] + array[row+2, col+1] + array[row+2, col+2];
                if (curentValue > maximalSum)
                {
                    maximalSum = curentValue;
                }
            }
        }
        Console.WriteLine(maximalSum);

        // for (int row = 0; row < NandM[0]; row++)
        // {
        //     for (int col = 0; col < NandM[1]; col++)
        //     {
        //         Console.Write(array[row,col] + " ");
        //     }
        //     Console.WriteLine();
        // }
    }
}

