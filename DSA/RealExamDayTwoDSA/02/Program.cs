using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        //static int currentResult = 0;
        //static int result = 0;
        //static List<int> finalResult = new List<int>();

        public static void Main()
        {
            var startRow = 0;
            var startCol = 0;

            var matrixSize = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];

            int[,] matrix = new int[rowSize, colSize];
            int[,] dp = new int[rowSize + 1, colSize + 1];

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = 1;
                }
            }

            var numberOfGuards = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfGuards; i++)
            {
                var current = Console.ReadLine().Split(' ').ToArray();
                var currenrGuardRow = int.Parse(current[0]);
                var currenrGuardCol = int.Parse(current[1]);
                var currenrGuardDir = current[2];

                matrix[currenrGuardRow, currenrGuardCol] = int.MaxValue;

                if (currenrGuardDir == "L")
                {
                    if (currenrGuardCol - 1 >= 0)
                    {
                        matrix[currenrGuardRow, currenrGuardCol - 1] = 3;
                    }
                }

                else if (currenrGuardDir == "R")
                {
                    if (currenrGuardCol + 1 < matrix.GetLength(1) - 1)
                    {
                        matrix[currenrGuardRow, currenrGuardCol + 1] = 3;

                    }
                }

                else if (currenrGuardDir == "U")
                {
                    if (currenrGuardRow + 1 < matrix.GetLength(0) - 1)
                    {
                        matrix[currenrGuardRow + 1, currenrGuardCol] = 3;

                    }
                }

                else if (currenrGuardDir == "D")
                {
                    if (currenrGuardRow - 1 >= 0)
                    {
                        matrix[currenrGuardRow - 1, currenrGuardCol] = 3;
                    }
                }
            }


            for (int row = 0; row < dp.GetLength(0); row++)
            {
                for (int col = 0; col < dp.GetLength(1); col++)
                {
                    //if (matrix[row, col] == int.MaxValue)
                    //{
                    //    continue;
                    //}

                    if (row - 1 >= 0 && col - 1 < dp.GetLength(1))
                    {
                        if (col > 0)
                        {
                            // up
                            var upValue = dp[row - 1, col];
                            // left
                            var leftValue = dp[row, col - 1];
                            var currentMin = Math.Min(upValue, leftValue);

                            dp[row + 1, col + 1] = matrix[row, col] + currentMin;
                        }
                        else
                        {
                            var upValue = dp[row - 1, col];
                            dp[row + 1, col +1] = matrix[row, col] + upValue;

                        }
                    }
                    else if (row - 1 >= 0)
                    {
                        var upValue = dp[row - 1, col];

                        dp[row + 1, col + 1] = matrix[row, col]+ upValue;
                    }
                    else if (col > 0)
                    {
                        var leftValue = dp[row, col - 1];

                        dp[row + 1, col + 1] = matrix[row, col] + leftValue;
                    }
                }
            }


            //Solver(startRow, startCol, matrix, isVisited, dp);

            if (dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1] > 0)
            {
                Console.WriteLine(dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]);
            }
            else
            {
                Console.WriteLine("Meow");

            }
        }

        //private static void Solver(int currentRow, int currentCol, int[,] matrix, bool[,] isVisited, int[,] matrixResults)
        //{
        //    int currentValue = 0;

        //    if (currentCol < isVisited.GetLength(1) && currentRow < isVisited.GetLength(0))
        //    {
        //        currentValue = matrix[currentRow, currentCol];
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    var finalRow = isVisited.GetLength(0) - 1;
        //    var finalCol = isVisited.GetLength(1) - 1;

        //    if (finalRow == currentRow && finalCol == currentCol)
        //    {
        //        result += currentValue;
        //        finalResult.Add(result);
        //        result -= currentValue;
        //        return;
        //    }

        //    if (matrixResults[currentRow, currentCol] <= result)
        //    {
        //        return;
        //    }

        //    // need more optimization 
        //    if (result > (isVisited.GetLength(0) + isVisited.GetLength(1) - 1) + +isVisited.GetLength(1))
        //    {
        //        return;
        //    }

        //    // right
        //    if (currentCol < isVisited.GetLength(1) && currentRow < isVisited.GetLength(0))
        //    {
        //        if (isVisited[currentRow, currentCol] == false)
        //        {
        //            result += currentValue;

        //            matrixResults[currentRow, currentCol] = result;

        //            isVisited[currentRow, currentCol] = true;
        //            Solver(currentRow, currentCol + 1, matrix, isVisited, matrixResults);
        //            isVisited[currentRow, currentCol] = false;
        //            result -= currentValue;
        //        }
        //    }

        //    // down
        //    if (currentRow < isVisited.GetLength(0) && currentCol < isVisited.GetLength(1))
        //    {
        //        if (isVisited[currentRow, currentCol] == false)
        //        {
        //            result += currentValue;

        //            matrixResults[currentRow, currentCol] = result;

        //            isVisited[currentRow, currentCol] = true;
        //            Solver(currentRow + 1, currentCol, matrix, isVisited, matrixResults);
        //            isVisited[currentRow, currentCol] = false;
        //            result -= currentValue;
        //        }
        //    }
        //}
    }
}
