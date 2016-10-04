using System;

class BinaryToDecimal
{
    static void Main()
    {
        string n = Console.ReadLine();
        long res = 0;

        for (int i = 0; i < n.Length; i++)
        {
            int num = n[i] - 48;


            if (num == 1)
            {

                res += (Power(2, n.Length - i - 1));
            }
        }

        Console.WriteLine(res);
    }


    public static long Power(int number, int power)
    {
        long result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= number;
        }


        return result;
    }
}

