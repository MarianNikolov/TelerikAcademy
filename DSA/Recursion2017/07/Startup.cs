using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    public class Startup
    {
        // We are given a matrix of passable and non-passable cells.
        // Write a recursive program for finding all paths between two cells in the matrix.

        private static char[,] matrix;
        //private static char startCell = 'O';
        private static char exitCell = 'X';
        private static char emptyCell = ' ';
        //private static char notFreeCell = '■';
        private static char passedCell = '∙';

        private static int startRow = 0;
        private static int startCol = 1;

        private static int exitRow = 9;
        private static int exitCol = 8;

        static void Main()
        {

            matrix = new char[10, 10]
            {
                { '■', 'O', '■', '■', '■', '■', '■', '■', '■', '■' },
                { '■', ' ', '■', '■', ' ', '■', '■', ' ', ' ', '■' },
                { '■', ' ', '■', '■', '■', '■', '■', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', '■', '■', '■', '■' },
                { '■', '■', '■', '■', '■', ' ', ' ', ' ', '■', '■' },
                { '■', ' ', '■', '■', '■', ' ', '■', ' ', '■', '■' },
                { '■', ' ', '■', ' ', '■', ' ', '■', ' ', ' ', '■' },
                { '■', ' ', '■', '■', '■', ' ', '■', '■', ' ', '■' },
                { '■', ' ', ' ', ' ', '■', ' ', ' ', ' ', ' ', '■' },
                { '■', '■', '■', '■', '■', '■', '■', '■', ' ', '■' }
            };

            FindAllPaths(startRow, startCol);
        }

        private static void FindAllPaths(int currentRow, int currentCol)
        {
            if (currentRow == exitRow && currentCol == exitCol)
            {
                matrix[currentRow, currentCol] = exitCell;
                PrintMatrix();
                matrix[currentRow, currentCol] = emptyCell;
                return;
            }

            bool isRightCellFree = matrix.GetLength(1) > currentCol + 1
                                    && matrix[currentRow, currentCol + 1] == emptyCell;

            bool isDownCellFree = matrix.GetLength(0) > currentRow + 1
                                    && matrix[currentRow + 1, currentCol] == emptyCell;

            bool isLeftCellFree = currentCol - 1 >= 0
                                    && matrix[currentRow, currentCol - 1] == emptyCell;

            bool isUpCellFree = currentRow - 1 >= 0
                                    && matrix[currentRow - 1, currentCol] == emptyCell;


            // right
            if (isRightCellFree)
            {
                currentCol += 1;
                GoInDirection(currentRow, currentCol);
            }

            // down 
            if (isDownCellFree)
            {
                currentRow += 1;
                GoInDirection(currentRow, currentCol);
            }

            // left
            if (isLeftCellFree)
            {
                GoInDirection(currentRow, currentCol);
            }

            // up
            if (isUpCellFree)
            {
                currentCol -= 1;
                GoInDirection(currentRow, currentCol);
            }
        }

        private static void GoInDirection(int currentRow, int currentCol)
        {
            matrix[currentRow, currentCol] = passedCell;
            FindAllPaths(currentRow, currentCol);
            matrix[currentRow, currentCol] = emptyCell;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
