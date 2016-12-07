using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_AllPathsBetweenTwoCellsInМatrix
{
    // 07. We are given a matrix of passable and non-passable cells.
    // Write a recursive program for finding all paths between two cells in the matrix.

    public class Startup
    {
        private static char[,] matrix;
        private static char passedCell = '∙';
        private static char startCell = 'O';
        private static char emptyCell = ' ';
        private static char exitCell = 'x';

        private static int startRow;
        private static int startCol;

        private static int exitRow;
        private static int exitCol;

        private static bool isValidStartIndexIsPassed = false;

        public static void Main()
        {
            matrix = new char[10, 10]
           {
                { '■', 'O', '■', '■', '■', '■', '■', '■', '■', '■' },
                { '■', ' ', '■', '■', ' ', '■', '■', ' ', ' ', '■' },
                { '■', ' ', '■', '■', ' ', '■', '■', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', '■', ' ', '■', '■' },
                { '■', ' ', '■', '■', '■', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', '■', '■', '■', '■', '■', ' ', '■', '■' },
                { '■', ' ', '■', ' ', ' ', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', '■', '■', '■', ' ', '■', '■', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■' },
                { '■', '■', '■', '■', '■', '■', '■', '■', ' ', '■' }
           };

            exitRow = 9;
            exitCol = 8;

            FindStartAndEndCells(matrix);

            if (!isValidStartIndexIsPassed)
            {
                Console.WriteLine("Invalid starting cell!");
            }
            else
            {
                FindPaths(startRow, startCol, exitRow, exitCol);
            }

        }

        private static void FindPaths(int startRow, int startCol, int exitRow, int exitCol)
        {
            if (startRow == exitRow && startCol == exitCol)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = exitCell;
                PrintMatrixPath(matrix);
                matrix[startRow, startCol] = passedCell;
                matrix[startRow, startCol] = oldValue;

                return;
            }

            // up
            if (startRow - 1 >= 0 && matrix[startRow - 1, startCol] == emptyCell)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPaths(startRow - 1, startCol, exitRow, exitCol);
                matrix[startRow, startCol] = oldValue;
            }

            // right
            if (startCol + 1 < matrix.GetLength(1) && matrix[startRow, startCol + 1] == emptyCell)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPaths(startRow, startCol + 1, exitRow, exitCol);
                matrix[startRow, startCol] = oldValue;
            }

            // down
            if (startRow + 1 < matrix.GetLength(0) && matrix[startRow + 1, startCol] == emptyCell)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPaths(startRow + 1, startCol, exitRow, exitCol);
                matrix[startRow, startCol] = oldValue;
            }

            // left
            if (startCol - 1 >= 0 && matrix[startRow, startCol - 1] == emptyCell)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPaths(startRow, startCol - 1, exitRow, exitCol);
                matrix[startRow, startCol] = oldValue;
            }
        }

        private static void PrintMatrixPath(char[,] matrix)
        {
            {
                StringBuilder result = new StringBuilder();
                List<char> chars;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    chars = new List<char>();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        chars.Add(matrix[row, col]);
                    }

                    string rowChars = string.Format("│{0}│", string.Join("│", chars));
                    result.AppendLine(rowChars);
                }

                Console.Write(result.ToString() + "\n");
            }
        }

        private static void FindStartAndEndCells(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isStartPosition = matrix[row, col] == startCell;

                    if (isStartPosition)
                    {
                        startRow = row;
                        startCol = col;

                        isValidStartIndexIsPassed = true;
                    }
                }
            }

        }
    }
}
