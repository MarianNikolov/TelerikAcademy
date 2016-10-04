using System;

namespace MethodPrintStatisticsInCSharpTask
{
    public class Print
    {
        public void PrintStatistics(double[] array, int count)
        {
            double maxElementInArray = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] > maxElementInArray)
                {
                    maxElementInArray = array[i];
                }
            }

            PrintMax(maxElementInArray);

            double mixElementInArray = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < mixElementInArray)
                {
                    mixElementInArray = array[i];
                }
            }

            PrintMin(mixElementInArray);

            double sumOfArrayElements = 0;
            for (int i = 0; i < count; i++)
            {
                sumOfArrayElements += array[i];
            }

            PrintAverage(sumOfArrayElements, count);
        }

        public static void PrintMax(double max)
        {
            Console.WriteLine(max);
        }

        public static void PrintMin(double min)
        {
            Console.WriteLine(min);
        }

        public static void PrintAverage(double sumOfarrayElements, int count)
        {
            var curentAverage = sumOfarrayElements / (double)count;
            Console.WriteLine(curentAverage);
        }
    }
}
