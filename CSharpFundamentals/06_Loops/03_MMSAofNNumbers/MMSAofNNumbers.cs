using System;

class MMSAofNNumbers
{
    static void Main()
    {
        int row = int.Parse(Console.ReadLine());
        double min = 10000;
        double max = -10000;
        double sum = 0;
        double avg = 0;
        int count = 0;

        double ReadingNumber = 0;


        for (int i = 0; i < row; i++)
        {
            ReadingNumber = double.Parse(Console.ReadLine());
            
            sum += ReadingNumber;
            
            if (min > ReadingNumber)
            {
                min = ReadingNumber;
            }

            if (max < ReadingNumber)
            {
                max = ReadingNumber;
            }
            count++;
        }
        avg = sum / count;
 
        Console.WriteLine("min={0:F2}", min);
        Console.WriteLine("max={0:F2}", max);
        Console.WriteLine("sum={0:F2}", sum);
        Console.WriteLine("avg={0:F2}", avg);


    }
}

