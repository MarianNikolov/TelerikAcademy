using System;

class BullsAndCows
{
    static void Main()
    {
        int inputSecretNumber = int.Parse(Console.ReadLine());
        int bullsNumber = int.Parse(Console.ReadLine());
        int cowsNumber = int.Parse(Console.ReadLine());
        int resultForPrint = 0;

        if (inputSecretNumber < 0)
        {
            inputSecretNumber *= -1;
        }
        if (bullsNumber < 0)
        {
            bullsNumber *= -1;
        }
        if (cowsNumber < 0)
        {
            cowsNumber *= -1;
        }

        int bulls = 0;
        int cows = 0;
        

        for (int genericGuessNumber = 1111; genericGuessNumber <= 9999; genericGuessNumber++)
        {
            int secretNumber = inputSecretNumber;
            int secretD = secretNumber % 10;
            secretNumber /= 10;
            int secretC = secretNumber % 10;
            secretNumber /= 10;
            int secretB = secretNumber % 10;
            secretNumber /= 10;
            int secretA = secretNumber % 10;
            secretNumber /= 10;
            
            int guessNumber = genericGuessNumber;

            int guessD = guessNumber % 10;
            guessNumber /= 10;
            if (guessD == 0)
            {
                continue;
            }
           
            int guessC = guessNumber % 10;
            guessNumber /= 10;
            if (guessC == 0)
            {
                continue;
            }
            
            int guessB = guessNumber % 10;
            guessNumber /= 10;
            if (guessB == 0)
            {
                continue;
            }
            
            int guessA = guessNumber % 10;
            guessNumber /= 10;
            if (guessA == 0)
            {
                continue;
            }

            // bulls
            if (guessA == secretA)
            {
                bulls++;
                guessA = -3;
                secretA = -4;
            }
            if (guessB == secretB)
            {
                bulls++;
                guessB = -3;
                secretB = -4;
            }
            if (guessC == secretC)
            {
                bulls++;
                guessC = -3;
                secretC = -4;
                
            }
            if (guessD == secretD)
            {
                bulls++;
                guessD = -3;
                secretD = -4;
            }

            // cows
            // guesA
            if (guessA == secretB)
            {
                cows++;
                guessA = -1;
                secretB = -2;
            }
            if (guessA == secretC)
            {
                cows++;
                guessA = -1;
                secretC = -2;
            }
            if (guessA == secretD)
            {
                cows++;
                guessA = -1;
                secretD = -2;
            }

            //guesB
            if (guessB == secretA)
            {
                cows++;
                guessB = -1;
                secretA = -2;
            }
            if (guessB == secretC)
            {
                cows++;
                guessB = -1;
                secretC = -2;
            }
            if (guessB == secretD)
            {
                cows++;
                guessB = -1;
                secretD = -2;
            }

            //guesC
            if (guessC == secretA)
            {
                cows++;
                guessC = -1;
                secretA = -2;
            }
            if (guessC == secretB)
            {
                cows++;
                guessC = -1;
                secretB = -2;
            }
            if (guessC == secretD)
            {
                cows++;
                guessC = -1;
                secretD = -2;
            }

            //guesD
            if (guessD == secretA)
            {
                cows++;
                guessD = -1;
                secretA = -2;
            }
            if (guessD == secretB)
            {
                cows++;
                guessD = -1;
                secretB = -2;
            }
            if (guessD == secretC)
            {
                cows++;
                guessD = -1;
                secretC = -2;
            }

            //print result
            if (bullsNumber == bulls && cowsNumber == cows)
            {
                resultForPrint = genericGuessNumber;
                Console.Write("{0} ", resultForPrint);
            }
            bulls = 0;
            cows = 0;
        }
        if (resultForPrint == 0)
        {
            Console.WriteLine("No");
        }
    }
}