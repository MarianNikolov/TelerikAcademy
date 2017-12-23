using System;

class BitsToBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int maxZero = 0;
        int curentZero = 0;
        int maxOne = 0;
        int curentOne = 0;
        int lastBit = 5555;

        for (int i = 0; i < n; i++)
        {

            int num = int.Parse(Console.ReadLine());

            for (int pos = 29; pos >= 0; pos--)
            {
                int bit = (num & (1 << pos)) >> pos;

                if (bit == 1)
                {
                    if (lastBit == 1)
                    {
                        curentOne++;
                    }
                    else
                    {
                        maxZero = Math.Max(maxZero, curentZero);
                        curentZero = 0;
                        curentOne = 1;
                    }
                }
                else
                {
                    if (lastBit == 0)
                    {
                        curentZero++;
                    }
                    else
                    {
                        maxOne = Math.Max(maxOne, curentOne);
                        curentOne = 0;
                        curentZero = 1;
                    }
                }
                lastBit = bit;

            }
        }
        maxZero = Math.Max(maxZero, curentZero);
        maxOne = Math.Max(maxOne, curentOne);
        
        Console.WriteLine(maxZero);
        Console.WriteLine(maxOne);
    }
}

