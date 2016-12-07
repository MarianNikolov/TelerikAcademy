using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // 08. Modify the above program to check whether a path exists between two cells 
    // without finding all possible paths.
    // Test it over an empty 100 x 100 matrix.


    public class Startup
    {
        private static char[,] matrix;
        private static char passedCell = '∙';
        private static char emptyCell = ' ';

        private static char startCell = 'O';
        private static char exitCell = 'x';

        private static bool isFound;

        private static int startRow;
        private static int startCol;

        private static int exitRow;
        private static int exitCol;

        public static void Main()
        {
            // solution for previous task
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

            startRow = 0;
            startCol = 1;

            exitRow = 9;
            exitCol = 8;

            FindPath(startRow, startCol, exitRow, exitCol);

            // solution for empty 100x100 matrix
            matrix = new char[100, 100];

            isFound = false;

            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    matrix[row, col] = ' ';
                }
            }

            startRow = 0;
            startCol = 0;

            exitRow = 99;
            exitCol = 99;

            FindPath(startRow, startCol, exitRow, exitCol, printInTextFile: true);

            Console.WriteLine("\n" + "See results with notepad++ (small font or zoom out)");
            Console.WriteLine("in folder \"ConsoleApplication1\" - file Path100x100.txt" + "\n");
        }

        private static void FindPath(int startRow, int startCol, int exitRow, int exitCol, bool printInTextFile = false)
        {
            if (startRow == exitRow && startCol == exitCol)
            {
                isFound = true;
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                PrintMatrixPath(matrix, printInTextFile);
                matrix[startRow, startCol] = oldValue;
                return;
            }

            // up
            if (startRow - 1 >= 0 && matrix[startRow - 1, startCol] == emptyCell && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPath(startRow - 1, startCol, exitRow, exitCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            // right
            if (startCol + 1 < matrix.GetLength(1) && matrix[startRow, startCol + 1] == emptyCell && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPath(startRow, startCol + 1, exitRow, exitCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            // down
            if (startRow + 1 < matrix.GetLength(0) && matrix[startRow + 1, startCol] == emptyCell && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPath(startRow + 1, startCol, exitRow, exitCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }

            // left
            if (startCol - 1 >= 0 && matrix[startRow, startCol - 1] == emptyCell && !isFound)
            {
                char oldValue = matrix[startRow, startCol];
                matrix[startRow, startCol] = passedCell;
                FindPath(startRow, startCol - 1, exitRow, exitCol, printInTextFile);
                matrix[startRow, startCol] = oldValue;
            }
        }

        private static void PrintMatrixPath(char[,] matrix, bool useStreaWriter)
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

            if (useStreaWriter)
            {
                using (StreamWriter writer = new StreamWriter("..\\..\\Path100x100.txt"))
                {
                    writer.Write(result.ToString());
                }
            }
            else
            {
                Console.Write(result.ToString() + "\n");
            }
        }
    }
}
