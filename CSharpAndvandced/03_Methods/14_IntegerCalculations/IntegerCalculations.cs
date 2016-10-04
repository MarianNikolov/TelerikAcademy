using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IntegerCalculations
{
    static int[] ReadAndFillArray()
    {
        // { ",", " ", ", " }
        // int lenghtOfArray = int.Parse(Console.ReadLine());
        int[] array = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions
            .RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();
        return array;
    }

    static long FindMinimum(params int[] array)
    {
        long min = array[0];
        foreach (var item in array)
        {
            if (min > item)
            {
                min = item;
            }
        }
        return min;
    }

    static long FindMaximum(params int[] array)
    {
        long max = array[0];
        foreach (var item in array)
        {
            if (max < item)
            {
                max = item;
            }
        }
        return max;
    }

    static decimal FindAverage(params int[] array)
    {
        //List<int> list = array.ToList();
        //return list.Average();

        decimal average = (decimal)FindSum(array) / array.Length;
        return average;
    }

    static long FindSum(params int[] array)
    {
        long sum = 0;
        foreach (var item in array)
        {
            sum += item;
        }
        return sum;
    }

    static long FindProduct(params int[] array)
    {
        long product = 1;

        foreach (var item in array)
        {
            product *= item;
        }
        return product;
    }

    static void Main()
    {
        int[] array = ReadAndFillArray();

        Console.WriteLine(FindMinimum(array));
        Console.WriteLine(FindMaximum(array));
        Console.WriteLine("{0:F2}", FindAverage(array));
        Console.WriteLine(FindSum(array));
        Console.WriteLine(FindProduct(array));
    }
}

