using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberAsArray
{
    static void Main()
    {
        Console.ReadLine();
        byte[] firstArray = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();
        byte[] secondArray = Console.ReadLine().Split(' ').Select(byte.Parse).ToArray();
        string sum = SumArrays(firstArray, secondArray);
        Console.WriteLine(sum);
    }
    
    static string SumArrays(byte[] firstArray, byte[] secondArray)
    {
        List<byte> listMax = new List<byte>();
        List<byte> listMin = new List<byte>();
        if (firstArray.Length > secondArray.Length)
        {
            listMax.AddRange(firstArray);
            listMin.AddRange(secondArray);
        }
        else
        {
            listMax.AddRange(secondArray);
            listMin.AddRange(firstArray);
        }
        int minLength = listMin.Count;
        int maxLength = listMax.Count;
        int addition = 0;
        int sum = 0;
        var result = new StringBuilder();

        for (int i = 0; i < minLength; i++)
        {
            sum = listMin[i] + listMax[i] + addition;
            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                result.Append(sum);
                addition = 0;
            }
        }

        for (int j = minLength; j < maxLength; j++)
        {
            sum = listMax[j] + addition;
            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                result.Append(sum);
                addition = 0;
            }
        }

        if (addition == 1)
        {
            result.Append(1);
        }
        char[] reversed = (result.ToString()).ToCharArray();
        result.Clear();
        for (int i = 0; i < reversed.Length; i++)
        {
            result.Append(reversed[i]);
            result.Append(" ");
        }
        return result.ToString();
    }
}

