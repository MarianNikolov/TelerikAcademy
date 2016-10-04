using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    private const string InvalidArrayMassage = "Array can not be null!";
    private const string InvalidStartIndexMassage = "Index must be equal or greater than zero!";
    private const string InvalidRangeMassage = "Sum of index and count must be equal or lower than array length!";
    private const string InvalidCountMassage = "Invalid count!";
    private const string PrimeMassage = "{0} is prime!";
    private const string NotPrimeMassage = "{0} is not prime!";

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentException(InvalidArrayMassage);
        }

        if (startIndex < 0)
        {
            throw new IndexOutOfRangeException(InvalidStartIndexMassage);
        }

        if ((startIndex + count) >= arr.Length)
        {
            throw new IndexOutOfRangeException(InvalidRangeMassage);
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException(InvalidCountMassage);
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckIsPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void WriteOnConsoleNumberIsPrimeOrNot(int number)
    {
        if (CheckIsPrime(number))
        {
            Console.WriteLine(PrimeMassage, number);
        }
        else
        {
            Console.WriteLine(NotPrimeMassage, number);
        }
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        //var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        //Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        //Console.WriteLine(ExtractEnding("Hi", 100));

        WriteOnConsoleNumberIsPrimeOrNot(23);
        WriteOnConsoleNumberIsPrimeOrNot(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        try
        {
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}
