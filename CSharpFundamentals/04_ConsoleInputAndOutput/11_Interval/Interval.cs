using System;

class Interval
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int counter = 0;

        if (n == m)
        {
            Console.WriteLine(0);
            return;
        }

        for (int i = n + 1; i < m; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.Write(counter);

    }
}

