using System;

class NthBit
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n > 24)
        {
            Console.WriteLine(0);
            return;
        }
        p >>= n;
        Console.WriteLine(p & 1);
    }
}

