using System;

class CoffeeMachine
{
    static void Main()
    {
        double n1 = double.Parse(Console.ReadLine());
        double n2 = double.Parse(Console.ReadLine());
        double n3 = double.Parse(Console.ReadLine());
        double n4 = double.Parse(Console.ReadLine());
        double n5 = double.Parse(Console.ReadLine());
        double moneyIn = double.Parse(Console.ReadLine());
        double priceOfDrink = double.Parse(Console.ReadLine());
        double displaySum = 0;
        double moneyInaMachine = 0;

        n1 = n1 * 0.05;
        n2 = n2 * 0.10;
        n3 = n3 * 0.20;
        n4 = n4 * 0.50;
        n5 = n5 * 1.00;
        moneyInaMachine = n1 + n2 + n3 + n4 + n5;

        if (moneyIn < priceOfDrink)
        {
            displaySum = priceOfDrink - moneyIn;
            Console.WriteLine("More " + "{0:F2}", displaySum);
        }

        if (moneyIn >= priceOfDrink)
        {
            if (moneyInaMachine == 0 && moneyIn == priceOfDrink)
            {
                displaySum = moneyIn - priceOfDrink;
                Console.WriteLine("Yes " + "{0:F2}", displaySum);
            }
            if ((moneyIn - priceOfDrink) > moneyInaMachine)
            {
                displaySum = (moneyIn - priceOfDrink) - moneyInaMachine;
                Console.WriteLine("No " + "{0:F2}", displaySum);
            }
            if ((moneyIn - priceOfDrink) < moneyInaMachine)
            {
                displaySum = moneyInaMachine - (moneyIn - priceOfDrink);
                Console.WriteLine("Yes " + "{0:F2}", displaySum);
            }
        }
    }
}

