using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        char printMatrix = char.Parse(Console.ReadLine());
        int counter = 1;
        switch (printMatrix)
        {
            // 1	5	9	13
            // 2	6	10	14
            // 3	7	11	15
            // 4	8	12	16
            case 'a':
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        array[col, row] = counter++;
                    }
                }
                // print
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col == n - 1)
                        {
                            Console.Write("{0}", array[row, col]);
                        }
                        else
                        {
                            Console.Write("{0} ", array[row, col]);
                        }
                    }
                    Console.WriteLine();
                }
                break;

            ///////////////////////////// B
            // 1	8	9	16
            // 2	7	10	15
            // 3	6	11	14
            // 4	5	12	13
            case 'b':
                for (int col = 0; col < n; col++)
                {
                    if (col % 2 == 0)
                    {
                        for (int row = 0; row < n; row++)
                        {
                            array[row, col] = counter++;
                        }
                    }
                    else
                    {
                        for (int row = n - 1; row >= 0; row--)
                        {
                            array[row, col] = counter++;
                        }
                    }
                }
                //print
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col == n - 1)
                        {
                            Console.Write("{0}", array[row, col]);
                        }
                        else
                        {
                            Console.Write("{0} ", array[row, col]);
                        }
                    }
                    Console.WriteLine();
                }
                break;


            ///////////////////////////// C

            //  7	11	14	16
            //  4	8	12	15
            //  2	5	9	13
            //  1	3	6	10
            case 'c':
                int r = n - 1;
                    int c = 0;
                    int mod = 1;

                    for (int i = 0; i < n * n; i++)
                    {
                        if (r == n && c < n)
                        {
                            mod++;
                            r = n - mod;
                            c = 0;
                        }
                        else if (c == n && c <= n)
                        {
                            mod--;
                            r = 0;
                            c = n - mod;
                        }

                        array[r, c] = i + 1;
                        r++;
                        c++;
                    }

                //print
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col == n - 1)
                        {
                            Console.Write("{0}", array[row, col]);
                        }
                        else
                        {
                            Console.Write("{0} ", array[row, col]);
                        }
                    }
                    Console.WriteLine();
                }
                break;


            ///////////////////////////// D
            case 'd':
                //  1	12	11	10
                //  2	13	16	9
                //  3	14	15	8
                //  4	5	6	7


            string direction = "right";
            int currentRow = 0;
            int currentCol = 0;

            for (int i = 1; i <= n * n; i++)
            {
                if (direction == "right" && (currentCol >= n || array[currentRow, currentCol] != 0)) // Check if outside of array or already visited
                {
                    currentCol--;
                    currentRow++;
                    direction = "down";
                }
                else if (direction == "down" && (currentRow >= n || array[currentRow, currentCol] != 0)) // Check if outside of array or already visited
                {
                    direction = "left";
                    currentRow--;
                    currentCol--;
                }
                else if (direction == "left" && (currentCol < 0 || array[currentRow, currentCol] != 0)) // Check if outside of array or already visited
                {
                    direction = "up";
                    currentCol++;
                    currentRow--;
                }
                else if (direction == "up" && (currentRow < 0 || array[currentRow, currentCol] != 0)) // Check if outside of array or already visited
                {
                    direction = "right";
                    currentRow++;
                    currentCol++;
                }

                array[currentRow, currentCol] = i;

                if (direction == "right")
                {
                    currentCol++;
                }
                else if (direction == "down")
                {
                    currentRow++;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
            }

                //print
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col == n - 1)
                        {
                            Console.Write("{0}", array[row, col]);
                        }
                        else
                        {
                            Console.Write("{0} ", array[row, col]);
                        }
                    }
                    Console.WriteLine();
                }
                break;

            default:
                break;
        }




    }
}

