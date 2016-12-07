using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_LargestConnectedAreaOfAdjacentEmptyCells
{
    // Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.

    public class Startup
    {
        private static char[,] matrix;
        private static char[,] copyOfMatrix;
        private static char passedCell = '∙';
        private static char emptyCell = ' ';
        private static List<KeyValuePair<string, int>> resultsCells;
        private static int currentMax = 0;

        static void Main()
        {
            copyOfMatrix = Initialize();
            matrix = Initialize();

            resultsCells = new List<KeyValuePair<string, int>>();

            for (int row = 0; row < copyOfMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < copyOfMatrix.GetLength(1); col++)
                {
                    if (copyOfMatrix[row, col] == ' ')
                    {
                        matrix = Initialize();
                        int counter = 0;
                        FillCells(row, col, ref counter);
                        PrintPath(matrix, counter);
                        counter = 0;
                    }
                }
            }

            string result = resultsCells.Where(x => x.Value == currentMax).Select(x => x.Key).FirstOrDefault();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine( "LARGEST AREA IS:" );
            Console.WriteLine("Cells {0}", currentMax);
            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintPath(char[,] matrix, int countOfcells)
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

            Console.WriteLine("cells {0}", countOfcells);
            Console.Write(result.ToString() + "\n");

            if (currentMax < countOfcells)
            {
                currentMax = countOfcells;
                resultsCells.Add(new KeyValuePair<string, int>(result.ToString(), countOfcells));
            }
        }

        private static void FillCells(int startRow, int startCol, ref int counter)
        {
            matrix[startRow, startCol] = passedCell;
            copyOfMatrix[startRow, startCol] = passedCell;
            counter++;

            // up
            if (startRow - 1 >= 0 && matrix[startRow - 1, startCol] == emptyCell)
            {
                FillCells(startRow - 1, startCol, ref counter);
            }

            // right
            if (startCol + 1 < matrix.GetLength(1) && matrix[startRow, startCol + 1] == emptyCell)
            {
                FillCells(startRow, startCol + 1, ref counter);
            }

            // down
            if (startRow + 1 < matrix.GetLength(0) && matrix[startRow + 1, startCol] == emptyCell)
            {
                FillCells(startRow + 1, startCol, ref counter);
            }

            // left
            if (startCol - 1 >= 0 && matrix[startRow, startCol - 1] == emptyCell)
            {
                FillCells(startRow, startCol - 1, ref counter);
            }
        }

        private static char[,] Initialize()
        {
            return new char[10, 10]
           {
                { '■', '■', '■', '■', '■', '■', '■', '■', '■', '■' },
                { '■', ' ', '■', '■', ' ', '■', '■', ' ', ' ', '■' },
                { '■', ' ', '■', '■', ' ', '■', '■', ' ', ' ', '■' },
                { '■', ' ', ' ', '■', ' ', ' ', ' ', ' ', '■', '■' },
                { '■', '■', '■', '■', '■', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', '■', '■', '■', '■', '■', '■', '■', '■' },
                { '■', ' ', '■', ' ', '■', ' ', ' ', '■', ' ', '■' },
                { '■', ' ', '■', '■', '■', ' ', '■', '■', ' ', '■' },
                { '■', ' ', ' ', ' ', '■', ' ', ' ', '■', ' ', '■' },
                { '■', '■', '■', '■', '■', '■', '■', '■', '■', '■' }
           };
        }
    }
}
