using System;

class BitSwap
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int pFirstIndex = int.Parse(Console.ReadLine());
        int qSecondIndex = int.Parse(Console.ReadLine());
        int kLengthIndex = int.Parse(Console.ReadLine());

        int maskFirstThreeNumbers = (int)(Math.Pow(2, kLengthIndex) - 1);
        int maskSecondThreeNumbers = (int)(Math.Pow(2, kLengthIndex) - 1);
        int finalNumber;
        int firstThreeNumbers;
        int secondThreeNumbers;
        int zeroMask1 = (int)(Math.Pow(2, kLengthIndex) - 1);
        int zeroMask2 = (int)(Math.Pow(2, kLengthIndex) - 1);
        maskFirstThreeNumbers <<= pFirstIndex;
        maskSecondThreeNumbers <<= qSecondIndex;
        firstThreeNumbers = number & maskFirstThreeNumbers;
        secondThreeNumbers = number & maskSecondThreeNumbers;
        zeroMask1 <<= pFirstIndex;
        zeroMask2 <<= qSecondIndex;
        zeroMask1 = ~zeroMask1;
        zeroMask2 = ~zeroMask2;
        number = number & zeroMask1;
        number = number & zeroMask2;
        firstThreeNumbers <<= Math.Abs(pFirstIndex - qSecondIndex);
        secondThreeNumbers >>= Math.Abs(pFirstIndex - qSecondIndex);
        finalNumber = number | firstThreeNumbers;
        finalNumber = finalNumber | secondThreeNumbers;
        Console.WriteLine(finalNumber);
    }
}

