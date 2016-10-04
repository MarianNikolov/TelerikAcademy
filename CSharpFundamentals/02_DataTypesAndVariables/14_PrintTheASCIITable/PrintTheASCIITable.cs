using System;

class PrintTheASCIITable
{
    static void Main()
    {
        for (int i = '!'; i < 127; i++)
        {
            char print = (char)i;
            Console.Write(print);
        }
    }
}

