using System;

class PrimeCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n > 0)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine("false");
                    return;
                }
            }
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}
