using System;

namespace TheMatrix
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number:");
            string input = Console.ReadLine();
            int size = 0;
            while (!int.TryParse(input, out size) || size < 0 || size > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[size, size];
            int currentNumber = 1;
            int row = 0;
            int col = 0;
            int currentRow = 1;
            int currentCol = 1;

            FullMatrix(matrix, row, col, currentRow, currentCol, size, currentNumber);

            FindCell(matrix, out row, out col);

            if (row != 0 && col != 0)
            {
                currentRow = 1;
                currentCol = 1;
                FullMatrix(matrix, row, col, currentRow, currentCol, size, currentNumber);
            }

            PrintMatrix(size, matrix);
        }

        private static void FullMatrix(int[,] matrix, int row, int col, int currentRow, int currentCol, int size, int currentNumber)
        {
            while (true)
            {
                matrix[row, col] = currentNumber;

                if (!Check(matrix, row, col))
                {
                    break;
                }

                if (IsInRange(row, col, currentRow, currentCol, size, matrix))
                {
                    while (IsInRange(row, col, currentRow, currentCol, size, matrix))
                    {
                        Change(ref currentRow, ref currentCol);
                    }
                }

                row += currentRow;
                col += currentCol;
                currentNumber++;
            }
        }

        private static bool IsInRange(int row, int col, int currentRow, int currentCol, int size, int[,] matrix)
        {
            var result = row + currentRow >= size || 
                row + currentRow < 0 || 
                col + currentCol >= size || 
                col + currentCol < 0 || 
                matrix[row + currentRow, col + currentCol] != 0;

            return result;
        }

        static void Change(ref int dx, ref int dy)
        {
            int[] row = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] col = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (row[count] == dx && col[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = row[0];
                dy = col[0];
                return;
            }

            dx = row[cd + 1];
            dy = col[cd + 1];
        }

        static bool Check(int[,] arr, int x, int y)
        {
            int[] row = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] col = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + row[i] >= arr.GetLength(0) || x + row[i] < 0)
                {
                    row[i] = 0;
                }

                if (y + col[i] >= arr.GetLength(0) || y + col[i] < 0)
                {
                    col[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + row[i], y + col[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}