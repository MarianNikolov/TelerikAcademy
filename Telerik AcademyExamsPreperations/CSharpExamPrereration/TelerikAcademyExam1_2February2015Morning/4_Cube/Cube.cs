using System;

class Cube
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.Write(new string(' ', (n - 1)));
        Console.Write(new string(':', n));
        Console.WriteLine();
        for (int row = 2; row < n ; row++)
        {
            Console.Write(new string(' ', (n - row)));
            Console.Write(new string(':', 1));
            Console.Write(new string('/', n-2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', row-2));
            Console.Write(new string(':', 1));
            Console.WriteLine();
        }

        Console.Write(new string(':', n));
        Console.Write(new string('X', n-2));
        Console.Write(new string(':', 1));
        Console.WriteLine();

        for (int row = 1; row < n-1; row++)
        {
            Console.Write(new string(':', 1));
            Console.Write(new string(' ', n-2));
            Console.Write(new string(':', 1));
            Console.Write(new string('X', (n - row)- 2));
            Console.Write(new string(':', 1));

            Console.WriteLine();
        }
        Console.Write(new string(':', n));
            

    }
}

