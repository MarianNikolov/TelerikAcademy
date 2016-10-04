using System;

class Speeds
{
    static void Main()
    {
        // 30 points in BgCoder during exam

        // TODO refacor
        // to much work on this :)
        int carsNumbers = int.Parse(Console.ReadLine());
        int CarInFirstGroup = 0;
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
                CarInFirstGroup = 1;

                // new group
                if (bigestGroup < CarInFirstGroup)
                {
                    if (bigestGroup > oldBigestGroup)
                    {
                        oldBigestGroup = bigestGroup;
                        oldAllcars = allcars;
                        bigestGroup = CarInFirstGroup;
                        bigestGroupSpeed = speed;
                        allcars += car;
                    }
                    else
                    {
                        bigestGroup = CarInFirstGroup;
                        bigestGroupSpeed = speed;
                        allcars += car;
                    }
                }

                oldCar = car;
            }

            if (car >= oldCar)
            {
                CarInFirstGroup++;
                allcars += car;
                oldCar = car;
            }

            if (CarInFirstGroup == 1)
            {
                speed = car;
            }

            if (bigestGroup == 0)
            {
                bigestGroup = CarInFirstGroup;
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
                bigestGroup = CarInFirstGroup;
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

