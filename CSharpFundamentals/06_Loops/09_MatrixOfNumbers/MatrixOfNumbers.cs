using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int number = 1;

        for (int row = 1; row <= n; row++)
        {
            number = row;
            for (int i = 1; i <= n; i++)
            {
                Console.Write(number + " ");
                number += 1;
            }

            Console.WriteLine();
        }

    }
}

