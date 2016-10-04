using System;

class NotDivisibleNumbers
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0)
            {
                continue; 
            }
            if (i % 7 == 0)
            {
                continue;
            }
            
            if (i == n)
            {
                Console.Write(n);
            }
            else
            {
                Console.Write(i + " ");
            }
        }

    }
}

