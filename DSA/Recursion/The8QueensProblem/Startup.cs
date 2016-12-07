using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The8QueensProblem
{
    public class Startup
    {
        static long Queens(int n, bool[,] table)
        {
            if (n == 0)
            {
                return 1;
            }

            long total = 0;

            int row = n - 1;

            for (int col = 0; col < table.GetLength(1); col++)
            {
                bool canPlaceQueen = true;

                /*
                int[] deltaX = { 1, -1, 0,  0,  1, 1, -1, -1 }; // X = horizontal
                int[] deltaY = { 0,  0, 1, -1, -1, 1, -1,  1 }; // Y = vertical
                //               r   l  d   u  ru  rd  lu  ld   
                // r = right
                // l = left
                // d = down
                // u = up
                */

                // optimize above 
                // search only in next without behind
                int[] deltaX = { 1,  1, 1 }; 
                int[] deltaY = { 0, -1, 1 };

                for (int deltaIndex = 0; canPlaceQueen && deltaIndex < deltaX.Length; deltaIndex++)
                {
                    int x = row;
                    int y = col;

                    while (x >= 0 && x < table.GetLength(0)
                        && y >= 0 && y < table.GetLength(1))
                    {
                        if (table[x, y])
                        {
                            canPlaceQueen = false;
                            break;
                        }

                        x += deltaX[deltaIndex];
                        y += deltaY[deltaIndex];
                    }
                }

                if (canPlaceQueen)
                {
                    table[row, col] = true;
                    total += Queens(n - 1, table);
                    table[row, col] = false;
                }
            }


            return total;
        }

        static void Main()
        {
            var n = 8;

            bool[,] table = new bool[n, n];

            var result = Queens(n, table);

            Console.WriteLine(result);
        }
    }
}
