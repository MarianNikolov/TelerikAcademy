using System;

class NumbersFrom1toN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            if (i == n)
            {
                Console.Write(n); 
            }
            
            if (i < n)
            {
                Console.Write(i + " ");
            }
        }
    }
}

