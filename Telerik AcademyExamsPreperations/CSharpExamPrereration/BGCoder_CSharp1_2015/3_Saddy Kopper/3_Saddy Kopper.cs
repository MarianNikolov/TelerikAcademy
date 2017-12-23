using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

/*
1.	Saddy gets number 12345 from the public
2.	Saddy removes the last digit – 1234 and calculates the sum of all digits at even positions – 1 + 3= 4
3.	Saddy removes the last digit – 123 and calculates the sum of all digits at even positions – 1 + 3 = 4
4.	Saddy removes the last digit – 12 and calculates the sum of all digits at even positions – 1
5.	Saddy removes the last digit – 1 and calculates the sum of all digits at even positions – 1
6.	Saddy removes the last digit – no digits left – get the product of all sums found – 4 * 4 * 1 * 1 = 16
7.	One transformation occurred and the number 16 has more than 1 digit – start again from step 2
8.	Saddy removes the last digit – 1 and calculates the sum of all digits at even positions – 1
9.	Saddy removes the last digit – no digits left – get the product of all sums found – 1
10.	Second transformation occurred and the number 1 has only one digit – the magic trick stops
11.	Final result – 2 transformations and the resulted number is 1
 */

class Saddy_Kopper
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        BigInteger evenNumber = 0;
        BigInteger result = 0;
        BigInteger momentResult = 0;
        BigInteger countOfListValue = 0;
        List<BigInteger> listOfNumbers = new List<BigInteger>();
        List<BigInteger> listAfterRemoveAllDigits = new List<BigInteger>();
        int counterForTransformation = 0;

        number = number / 10;
        string numberString = number.ToString();

        while (numberString.Length > 1)
        {
            while (numberString.Length > 0)
            {
                for (int i = 0; i < numberString.Length; i++)
                {
                    char curentNumber = numberString[i];
                    if (i % 2 == 0)
                    {
                        evenNumber = curentNumber - 48;
                        listOfNumbers.Add(evenNumber);
                    }
                }
                
                for (int i = 0; i < listOfNumbers.Count; i++) ///////////////////
                {
                    countOfListValue += listOfNumbers[i]; //////////////////////
                }
                
                listAfterRemoveAllDigits.Add(countOfListValue);
                countOfListValue = 0;
                listOfNumbers.Clear();
                BigInteger newNumber = BigInteger.Parse(numberString);
                newNumber = newNumber / 10;
                if (newNumber == 0)
                {
                    break;
                }
                numberString = newNumber.ToString();

            }

            BigInteger variableForMultiplication = 1;
            for (int i = 0; i < listAfterRemoveAllDigits.Count; i++)
            {
                variableForMultiplication *= listAfterRemoveAllDigits[i];
            }
            string stringVariableForMultiplication = variableForMultiplication.ToString();
            numberString = stringVariableForMultiplication;
            listAfterRemoveAllDigits.Clear();
            counterForTransformation++;
            if (counterForTransformation == 10)
            {
                Console.WriteLine(numberString);
            }
        }
        Console.WriteLine(counterForTransformation);
        Console.WriteLine(numberString);
    }
}
