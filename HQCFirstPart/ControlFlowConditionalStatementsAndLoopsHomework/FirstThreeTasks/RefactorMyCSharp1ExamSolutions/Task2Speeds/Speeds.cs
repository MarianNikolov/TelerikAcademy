using System;

class Speeds
{
    static void Main()
    {
        int carsNumbers = int.Parse(Console.ReadLine());
        int CarInGroup1 = 0;
        int bigestGroup = 0;
        int car = 0;
        int oldCar = 0;
        int speed = 0;
        int bigestGroupSpeed = 0;
        int oldBigestGroup = 0;
        int allcars = 0;
        int oldAllcars = 0;

        for (int i = 0; i < carsNumbers; i++)
        {
            car = int.Parse(Console.ReadLine());

            if (car < oldCar)
            {
                CarInGroup1 = 1;

                // new group
                if (bigestGroup < CarInGroup1)
                {
                    if (bigestGroup > oldBigestGroup)
                    {
                        oldBigestGroup = bigestGroup;
                        oldAllcars = allcars;
                        bigestGroup = CarInGroup1;
                        bigestGroupSpeed = speed;
                        allcars += car;
                    }

                    else
                    {
                        bigestGroup = CarInGroup1;
                        bigestGroupSpeed = speed;
                        allcars += car;
                    }

                }


                oldCar = car;
            }

            if (car >= oldCar)
            {
                CarInGroup1++;

                allcars += car;

                oldCar = car;
            }

            if (CarInGroup1 == 1)
            {
                speed = car;
            }
            if (bigestGroup == 0)
            {
                bigestGroup = CarInGroup1;
                bigestGroupSpeed = speed;
            }
        }
        
        if (bigestGroup == oldBigestGroup)
        {
            if (allcars >= oldAllcars)
            {
                Console.WriteLine(allcars);

            }
            else
            {
                bigestGroup = CarInGroup1;
                bigestGroupSpeed = speed;
                Console.WriteLine(allcars);
            }

        }
        else
        {
            Console.WriteLine(bigestGroupSpeed);
        }

    }
}

