using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    static BigInteger Patternn(BigInteger[,] array, int row, int col)
    {
        BigInteger sum = long.MinValue;
        if (array[row, col] - array[row, col + 1] == -1
            && array[row, col + 1] - array[row, col + 2] == -1
            && array[row, col + 2] - array[row + 1, col + 2] == -1
            && array[row + 1, col + 2] - array[row + 2, col + 2] == -1
            && array[row + 2, col + 2] - array[row + 2, col + 3] == -1
            && array[row + 2, col + 3] - array[row + 2, col + 4] == -1)
        {
            sum = array[row, col]
                + array[row, col + 1]
                + array[row, col + 2]
                + array[row + 1, col + 2]
                + array[row + 2, col + 2]
                + array[row + 2, col + 3]
                + array[row + 2, col + 4];
        }
        return sum;
    }

    static BigInteger FindDiagonal(BigInteger[,] array, int n)
    {
        BigInteger sum = array[0, 0];
        
        for (int i = 1; i < n; i++)
        {
            sum += array[i, i];
        }
        return sum;
    }

    static void Main() 
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger[,] array = new BigInteger[n, n];

        for (int i = 0; i < n; i++)
        {
            BigInteger[] curentArray = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            for (int j = 0; j < n; j++)
            {
                array[i, j] = curentArray[j];
            }
        }

        BigInteger curentSum = long.MinValue;
        BigInteger sumForPrint = long.MinValue;

        // print
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 4; j++)
            {
                curentSum = Patternn(array, i, j);
                if (curentSum > sumForPrint)
                {
                    sumForPrint = curentSum;
                }
            }
        }

        if (sumForPrint == long.MinValue)
        {
            Console.WriteLine("NO {0}", FindDiagonal(array, n));
        }
        else
        {
            Console.WriteLine("YES {0}", sumForPrint);
        }
    }
}

