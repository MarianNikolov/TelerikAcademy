using System;

class PrintADeck
{
    static void Main()
    {
        string card = Console.ReadLine();
        int index = -1;

        string[] cardFromDeck = new string[]
            {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A",  
            };

        for (int i = 0; i < cardFromDeck.Length; i++)
        {
            if (cardFromDeck[i] == card)
            {
                index = i;
            }
        }

        for (int i = 0; i <= index; i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", cardFromDeck[i]);
        }
    }
}
