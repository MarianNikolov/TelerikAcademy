using System;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //   ...##...
        //   ..#..#..
        //   .#....#.
        //   #......#
        for (int row = 0; row < n / 2; row++)
        {
            for (int dots1 = 0; dots1 < ((n / 2) - row) - 1; dots1++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int dots2 = 0; dots2 < row * 2; dots2++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int dots3 = 0; dots3 < ((n / 2) - row) - 1; dots3++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }


        //   #......#
        //   .#....#.
        for (int row = 0; row < n / 4; row++)
        {
            for (int dots = 0; dots < (n + row) - n; dots++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int dots2 = 0; dots2 < (n - (2 * row)) - 2; dots2++)
            {
                Console.Write('.');
            }
            Console.Write('#');
            for (int dots3 = 0; dots3 < (n + row) - n; dots3++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }


        //   --------
        for (int i = 0; i < n; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();


        //   \\\\////
        //   .\\\///.
        //   ..\\//..
        //   ...\/...
        for (int row = 0; row < n / 2; row++)
        {
            //left
            for (int dots = 0; dots < (n + row) - n; dots++)
            {
                Console.Write('.');
            }
            for (int dash = 0; dash < n / 2 - row; dash++)
            {
                Console.Write('\\');
            }
            //right
            for (int dash = 0; dash < n / 2 - row; dash++)
            {
                Console.Write('/');
            }
            for (int dots = 0; dots < (n + row) - n; dots++)
            {
                Console.Write('.');
            }

            Console.WriteLine();
        }
    }
}

