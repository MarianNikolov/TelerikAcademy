using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsFromBgCoder
{
    class Program
    {
        static long guardValue = 1000000000;

        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var rows = input[0];
            var cols = input[1];
            var matrix = new long[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 1;
                }
            }

            SetGuards(rows, cols, matrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] >= guardValue)
                    {
                        continue;
                    }
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
                        var up = matrix[row - 1, col];
                        var left = matrix[row, col - 1];
                        var currentMin = up;

                        if (up > left)
                        {
                            currentMin = left;
                        }

                        matrix[row, col] += currentMin;
                    }
                }
            }

            var result = matrix[rows - 1, cols - 1];
            if (result >= guardValue)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        private static void SetGuards(int rows, int cols, long[,] matrix)
        {
            var numberOfGuards = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfGuards; i++)
            {
                var currentGuardCoord = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var guardRow = int.Parse(currentGuardCoord[0]);
                var guardCol = int.Parse(currentGuardCoord[1]);
                var direction = currentGuardCoord[2];

                matrix[guardRow, guardCol] = guardValue;
                switch (direction)
                {
                    case "U":
                        guardRow--;
                        break;
                    case "D":
                        guardRow++;
                        break;
                    case "R":
                        guardCol++;
                        break;
                    case "L":
                        guardCol--;
                        break;
                }

                if (guardRow >= 0 && guardRow < rows
                    && guardCol >= 0 && guardCol < cols)
                {
                    if (matrix[guardRow, guardCol] != guardValue)
                    {
                        //if (matrix[guardRow, guardCol] > 2 && matrix[guardRow, guardCol] < guardValue)
                        //{
                        //    matrix[guardRow, guardCol] += 3;
                        //}
                        //else
                        //{
                            matrix[guardRow, guardCol] = 3;
                        //}
                    }
                }
            }
        }
    }
}