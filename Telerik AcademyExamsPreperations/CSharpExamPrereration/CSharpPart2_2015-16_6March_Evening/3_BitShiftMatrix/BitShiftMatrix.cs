using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class BitShiftMatrix
{
    static BigInteger[,] CreateAndFillMatrixDiagonally(int numberOFRows, int NumberOfCols)
    {
        BigInteger[,] array = new BigInteger[numberOFRows, NumberOfCols];

        for (int row = 0; row < array.GetLength(0); row++)
        {
            BigInteger power = (BigInteger)Math.Pow(2, (double)(array.GetLength(0) - row - 1));

            for (int col = 0; col < array.GetLength(1); col++)
            {
                array[row, col] = power;
                power *= 2;
            }
        }

        return array;
    }


    static void Main()
    {
        int numbersOfRows = int.Parse(Console.ReadLine());
        int numbersOfCols = int.Parse(Console.ReadLine());
        int numbersOfMoves = int.Parse(Console.ReadLine());
        int[] positionCODE = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        BigInteger[,] array = CreateAndFillMatrixDiagonally(numbersOfRows, numbersOfCols);

        List<int> positions = new List<int>();

        for (int i = 0; i < positionCODE.Length; i++)
        {
            int coef = Math.Max(numbersOfRows, numbersOfCols);
            int curentColPosition = positionCODE[i] % coef;
            positions.Add(curentColPosition);
            int curentRowPosition = positionCODE[i] / coef;
            positions.Add(curentRowPosition);
        }

        BigInteger sum = 1;

        int curentRow = numbersOfRows - 1;
        int curentCol = 0;

        // bool array for storage path
        bool[,] boolArray = new bool[numbersOfRows, numbersOfCols];
        boolArray[curentRow, curentCol] = true;

        for (int i = 0; i < positions.Count; i++)
        {
            int moveToPosition = positions[i];

            // move left and right         
            if (i % 2 == 0)
            {
                // left
                if (moveToPosition < curentCol)
                {
                    for (; curentCol > moveToPosition; )
                    {
                        curentCol--;
                        if (boolArray[curentRow, curentCol] == false)
                        {
                            sum += array[curentRow, curentCol];
                            boolArray[curentRow, curentCol] = true;
                        }
                    }
                    continue;
                }

                // right
                if (moveToPosition > curentCol)
                {
                    for (; curentCol < moveToPosition; )
                    {
                        curentCol++;
                        if (boolArray[curentRow, curentCol] == false)
                        {
                            sum += array[curentRow, curentCol];
                            boolArray[curentRow, curentCol] = true;
                        }
                    }
                    continue;
                }
            }

            // move up and down
            if (i % 2 == 1)
            {

                // up
                if (moveToPosition < curentRow)
                {
                    for (; curentRow > moveToPosition; )
                    {
                        curentRow--;
                        if (boolArray[curentRow, curentCol] == false)
                        {
                            sum += array[curentRow, curentCol];
                            boolArray[curentRow, curentCol] = true;
                        }
                    }
                    continue;
                }

                // down
                if (moveToPosition > curentRow)
                {
                    for (; curentRow < moveToPosition; )
                    {
                        curentRow++;
                        if (boolArray[curentRow, curentCol] == false)
                        {
                            sum += array[curentRow, curentCol];
                            boolArray[curentRow, curentCol] = true;
                        }
                    }
                    continue;
                }
            }
        }

        Console.WriteLine(sum);

    }
}

