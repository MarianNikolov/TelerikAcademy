using System;

class SumOfEvenDivisors
{
    static void Main()
    {

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int sum = 0;

        for (int num = a; num <= b; num++)
        {
            for (int div = 1; div <= num; div++)
            {

                if (num % div == 0)
                {
                    if (div % 2 == 0)
                    {
                        sum += div;
                    }
                }

            }
        }
        Console.WriteLine(sum);

    }
}


