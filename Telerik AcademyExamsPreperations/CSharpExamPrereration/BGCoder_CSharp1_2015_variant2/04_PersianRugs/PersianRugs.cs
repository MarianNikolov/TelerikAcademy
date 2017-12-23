using System;

class PersianRugs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int width = 2 * n + 1;
        // top
        for (int row = 1; row <= n; row++)
        {
            Console.Write(new string('#', row - 1));
            Console.Write(new string('\\', 1));

            int leftSpacing = (width - (row - 1) - (row - 1) - 2) - (d * 2) - 2;
            
            if (leftSpacing > 0)
            {
                Console.Write(new string(' ', d));
                Console.Write(new string('\\', 1));
                Console.Write(new string('.', leftSpacing));
                Console.Write(new string('/', 1));
                Console.Write(new string(' ', d));
            }
            else
            {
                Console.Write(new string(' ', width - (row - 1) - (row - 1) - 2));
            }

            Console.Write(new string('/', 1));
            Console.Write(new string('#', row - 1));
            Console.WriteLine();
        }

        // center
        Console.Write(new string('#', n));
        Console.Write(new string('X', 1));
        Console.Write(new string('#', n));
        Console.WriteLine();


        // bottom
        for (int row = n; row >= 1; row--)
        {
            Console.Write(new string('#', (n - n) + (row - 1)));
            Console.Write(new string('/', 1));

            int leftSpacing = (width - (row - 1) - (row - 1) - 2) - (d * 2) - 2;

            if (leftSpacing > 0)
            {
                Console.Write(new string(' ', d));
                Console.Write(new string('/', 1));
                Console.Write(new string('.', leftSpacing));
                Console.Write(new string('\\', 1));
                Console.Write(new string(' ', d));
            }
            else
            {
                Console.Write(new string(' ', width - (row - 1) - (row - 1) - 2));
            }

            Console.Write(new string('\\', 1));
            Console.Write(new string('#', (n - n) + (row - 1)));
            Console.WriteLine();
        }

    }
}

