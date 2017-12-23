using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doge
{
    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var rows = input[0];
            var cols = input[1];
            var matrix = new long[rows, cols];

            // set coins on position
            var numberOfCoins = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCoins; i++)
            {
                var coinCoordinates = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

                matrix[coinCoordinates[0], coinCoordinates[1]]++;
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
                        matrix[row, col] += matrix[row, col - 1];
                    }
                    else if (col == 0)
                    {
                        matrix[row, col] += matrix[row - 1, col];
                    }
                    else
                    {
                        var currentMax = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                        matrix[row, col] += currentMax;
                    }
                }
            }

            Console.WriteLine(matrix[rows - 1, cols - 1]);
        }
    }
}
