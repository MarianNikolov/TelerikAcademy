using System;

class Program
{
    static void Main()
    {
        int carsNumbers = int.Parse(Console.ReadLine());
        int[] array = new int[carsNumbers];
        int bigestGroup = 0;
        int bigestGroupOld = 0;


        for (int i = 0; i < carsNumbers; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < array[i+1])
            {
                bigestGroup++;
            }


        }
    }
}

