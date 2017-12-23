using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Task_01
    {
        static void Main()
        {
            var input = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            var rows = input[0];
            var cols = input[1];
            var numberOfBeers = input[2];
            var matrix = new long[rows, cols];

            for (int i = 0; i < numberOfBeers; i++)
            {
                var beerCoordinates = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

                matrix[beerCoordinates[0], beerCoordinates[1]] = -5;
            }

            //DP
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }
                    else if (row == 0)
                    {
                        matrix[row, col] += matrix[row, col - 1] + 1;
                    }
                    else if (col == 0)
                    {
                        matrix[row, col] += Math.Min(matrix[row - 1, col], matrix[row - 1, col + 1] + 1) + 1;
                    }
                    else
                    {
                        long left = Math.Min(matrix[row - 1, col - 1] + 1, matrix[row, col - 1]);
                        long up;
                        if (col + 1 < matrix.GetLength(1))
                        {
                            up = Math.Min(matrix[row - 1, col], matrix[row - 1, col + 1] + 1);
                        }
                        else
                        {
                            up = matrix[row - 1, col];

                        }
                        long CurrentMin = Math.Min(up, left);
                        matrix[row, col] += CurrentMin + 1;
                    }
                }
            }

            Console.WriteLine(matrix[rows - 1, cols - 1]);
        }
    }
}



