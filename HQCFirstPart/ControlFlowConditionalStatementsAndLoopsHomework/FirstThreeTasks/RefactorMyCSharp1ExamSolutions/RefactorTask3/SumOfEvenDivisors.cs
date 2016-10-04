using System;

class SumOfEvenDivisors
{
    // 100 points in BgCoder during exam

    static void Main()
    {
        // :)
        SolveTheProblem();
    }

    private static void SolveTheProblem()
    {
        int firstNumber = ReadInput();
        int secondNumber = ReadInput();
        int sumOfEvenDivisors = GetSumOfEvenDivisors(firstNumber, secondNumber);

        Console.WriteLine(sumOfEvenDivisors);
    }

    private static int GetSumOfEvenDivisors(int firstNumber, int secondNumber)
    {
        int sum = 0;
        for (int num = firstNumber; num <= secondNumber; num++)
        {
            for (int div = 1; div <= num; div++)
            {
                bool IsEven = num % div == 0;
                if (IsEven)
                {
                    bool IsEvenAgain = div % 2 == 0;
                    if (IsEvenAgain)
                    {
                        sum += div;
                    }
                }
            }
        }

        return sum;
    }

    private static int ReadInput()
    {
        int readedNumber = int.Parse(Console.ReadLine());

        return readedNumber;
    }
}


