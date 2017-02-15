using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProblem
{
    public class Startup
    {
        static void Main()
        {
            // Implemented whit backtracking 

            int[,] table =
            {
                { 5, 3, 0,   0, 7, 0,   0, 0, 0  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 6, 0, 0,   1, 9, 5,   0, 0, 0  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 0, 9, 8,   0, 0, 0,   0, 6, 0  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                                                                                             
                { 8, 0, 0,   0, 6, 0,   0, 0, 3  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 4, 0, 0,   8, 0, 3,   0, 0, 1  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 7, 0, 0,   0, 2, 0,   0, 0, 6  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                                                                                             
                { 0, 6, 0,   0, 0, 0,   2, 8, 0  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 0, 0, 0,   4, 1, 9,   0, 0, 5  },   //  0, 0, 0,   0, 0, 0,   0, 0, 0      
                { 0, 0, 0,   0, 8, 0,   0, 7, 9  }    //  0, 0, 0,   0, 0, 0,   0, 0, 0      
            };

            bool isCorrect = SolveSudocu(table);

            PrintSudocu(table, isCorrect);
        }

        static bool SolveSudocu(int[,] table, int row = 0, int col = 0)
        {
            if (col == table.GetLength(0))
            {
                row++;
                col = 0;

                if (row == table.GetLength(1))
                {
                    return true;
                }
            }

            if (table[row, col] > 0)
            {
                return SolveSudocu(table, row, col + 1);
            }

            for (int i = 1; i <= table.GetLength(0); i++)
            {
                bool isOk = true;

                for (int k = 0; k < table.GetLength(0); k++)
                {
                    if (table[row, k] == i || table[k, col] == i
                        || table[row / 3 * 3 + k / 3, col / 3 * 3 + k % 3] == i)
                    {
                        isOk = false;
                        break;
                    }
                }

                if (!isOk)
                {
                    continue;
                }

                table[row, col] = i;

                if (SolveSudocu(table, row, col + 1))
                {
                    return true;
                }

                table[row, col] = 0;
            }

            return false;
        }

        private static void PrintSudocu(int[,] table, bool isCorrect)
        {
            if (!isCorrect)
            {
                Console.WriteLine("No solution");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("  * * * * * * * *   S U D O K U   * * * * * * * *");
                Console.WriteLine("  *                                             *");
                Console.WriteLine("  *  -----------------------------------------  *");
                Console.WriteLine("  *               |             |               *");

                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            Console.Write("  * ");
                        }

                        if (j % 3 == 0 && j != 0)
                        {
                            Console.Write("  |  " + table[i, j]);
                        }

                        else
                        {
                            Console.Write("   " + table[i, j]);
                        }

                        if (j == table.GetLength(1) - 1)
                        {
                            Console.Write("    *");
                        }
                    }

                    Console.WriteLine();

                    if ((i + 1) % 3 == 0)
                    {
                        Console.WriteLine("  *               |             |               *");
                        Console.WriteLine("  *  -----------------------------------------  *");

                        if (i != table.GetLength(0) - 1)
                        {
                            Console.WriteLine("  *               |             |               *");
                        }
                    }
                }
                Console.WriteLine("  *                                             *");
                Console.WriteLine("  * * * * * * * * * * * * * * * * * * * * * * * *");
            }
        }
    }
}
