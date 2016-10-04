using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceInMatrix
{
    static void Main()
    {
        /*
         input:
         6 6
         92 11 23 42 59 48
         09 92 23 72 56 14
         17 63 92 46 85 95
         34 12 52 69 23 95
         26 88 78 71 29 95
         26 34 16 63 39 95
          
         output: 4
         */
        int[] NandM = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

        int[,] array = new int[NandM[0], NandM[1]];

        for (int row = 0; row < NandM[0]; row++)
        {
            int[] curenRowArray = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            for (int col = 0; col < curenRowArray.Length; col++)
            {
                array[row, col] = curenRowArray[col];
            }
        }

        int counter = 1;
        int maxLength = 1;

        // horizontal 
        for (int row = 0; row < array.GetLength(0); row++)
        {
            for (int col = 0; col < array.GetLength(1) - 1; col++)
            {
                if (array[row, col] == array[row, col +1])
                {
                    counter++;
                    if (counter > maxLength)
	                {
	                	maxLength = counter;
	                }
                }
            }
            counter = 1;
        }

        // vertical
        for (int col = 0; col < array.GetLength(1); col++)
        {
            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                if (array[row, col] == array[row + 1, col])
                {
                    counter++;
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                    }
                }
            }
            counter = 1;
        }


        // diagonal ↓→
        for (int startRow = array.GetLength(0) - 1; startRow >= 0; startRow--)
        {
            for (int row = startRow, col = 0; row < array.GetLength(0); row++, col++)
            {
                if (row + 1 >= array.GetLength(0) || col + 1 >= array.GetLength(1))
                {
                    continue;
                }

                if (array[row, col] == array[row + 1, col + 1])
                {
                    counter++;
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                    }
                }
                // for debug
                // Console.Write(array[row, col] + " ");
            }

            counter = 1;
        }

        for (int startCol = 0; startCol < array.GetLength(1); startCol++)
        {
            for (int row = 0, col = startCol; col < array.GetLength(1); row++, col++)
            {
                if (row + 1 >= array.GetLength(0) || col + 1 >= array.GetLength(1))
                {
                    continue;
                }

                if (array[row, col] == array[row + 1, col + 1])
                {
                    counter++;
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                    }
                }
            }

            counter = 1;
        }


        // diagonal ↓←
        for (int startRow = array.GetLength(0) - 1; startRow >= 0; startRow--)
        {
            for (int row = startRow, col = array.GetLength(1) - 1; row < array.GetLength(0) && col >= 0; row++, col--)
            {
                if (row + 1 >= array.GetLength(0) || col - 1 <= 0)
                {
                    continue;
                }

                if (array[row, col] == array[row + 1, col - 1])
                {
                    counter++;
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                    }
                }
            }
            counter = 1;
        }

        for (int startCol = array.GetLength(1) - 1; startCol >= 0; startCol--)
        {
            for (int col = startCol, row = 0; col >= 0 && row < array.GetLength(0); row++, col--)
            {
                if (row + 1 >= array.GetLength(0) || col - 1 <= 0)
                {
                    continue;
                }

                if (array[row, col] == array[row + 1, col - 1])
                {
                    counter++;
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                    }
                }
            }
            counter = 1;
        }
        
        Console.WriteLine(maxLength);
    }
}

