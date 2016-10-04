using System;

class PlayCard
{
    static void Main()
    {
        string playCard = Console.ReadLine();

        switch (playCard)
        {
            case "2": 
                Console.WriteLine("yes {0}", playCard); break;
            case "3":
                Console.WriteLine("yes {0}", playCard); break;
            case "4":
                Console.WriteLine("yes {0}", playCard); break;
            case "5":
                Console.WriteLine("yes {0}", playCard); break;
            case "6":
                Console.WriteLine("yes {0}", playCard); break;
            case "7":
                Console.WriteLine("yes {0}", playCard); break;
            case "8":
                Console.WriteLine("yes {0}", playCard); break;
            case "9":
                Console.WriteLine("yes {0}", playCard); break;
            case "10":
                Console.WriteLine("yes {0}", playCard); break;
            case "J":
                Console.WriteLine("yes {0}", playCard); break;
            case "Q":
                Console.WriteLine("yes {0}", playCard); break;
            case "K":
                Console.WriteLine("yes {0}", playCard); break;
            case "A":
                Console.WriteLine("yes {0}", playCard); break;
            default:
                Console.WriteLine("no {0}", playCard);
                break;
        }

    }
}

