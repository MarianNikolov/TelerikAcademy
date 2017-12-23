using System;

class BatGoikoTower
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int update = 2;
        int tiretaline = 2;

        for (int row = 1; row <= n; row++)
        {
            if (row == tiretaline)
            {
                for (int i = 0; i < n - row; i++)
                {
                    Console.Write('.');
                }
                    Console.Write('/');

                for (int i = 0; i < (row * 2) - 2; i++)
                {
                    Console.Write('-');
                }
                    Console.Write('\\');
                
                for (int i = 0; i < n - row; i++)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
                tiretaline += update;
                update++;

            }

            else
	        {
            for (int i = 0; i < n - row; i++)
                {
                    Console.Write('.');
                }
                    Console.Write('/');

            for (int i = 0; i < (row * 2) - 2; i++)
                {
                    Console.Write('.');
                }
                    Console.Write('\\');
                
            for (int i = 0; i < n - row; i++)
                {
                    Console.Write('.');
                }
            Console.WriteLine();
            }
        }

    }
}

