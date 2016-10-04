using System;

class BitExchange
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        uint maskFirstThreeNumbers = 7;
        uint maskSecondThreeNumbers = 7;
        uint finalNumber;
        uint firstThreeNumbers;
        uint secondThreeNumbers;
        uint zeroMask1 = 7;
        uint zeroMask2 = 7;

        maskFirstThreeNumbers <<= 3;
        maskSecondThreeNumbers <<= 24;
        firstThreeNumbers = number & maskFirstThreeNumbers;
        secondThreeNumbers = number & maskSecondThreeNumbers;
        zeroMask1 <<= 3;
        zeroMask2 <<= 24;
        zeroMask1 = ~zeroMask1;
        zeroMask2 = ~zeroMask2;
        number = number & zeroMask1;
        number = number & zeroMask2;
        firstThreeNumbers <<= 21;
        secondThreeNumbers >>= 21;
        finalNumber = number | firstThreeNumbers;
        finalNumber = finalNumber | secondThreeNumbers;
        Console.WriteLine(finalNumber);

    }
}

