using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_Gravitation_on_the_Moon
{
    class Program
    {
        /*
         Problem 2. Gravitation on the Moon

    The gravitational field of the Moon is approximately 17% of that on the Earth.
    Write a program that calculates the weight of a man on the moon by a given weight on the Earth.

    Examples:
    weight 	weight on the Moon
    86 	    14.62
    74.6 	12.682
    53.7 	9.129
         */
        static void Main()
        {
            Console.Write("Enter your weight: ");
            double weightOnEarth = double.Parse(Console.ReadLine());
            double weightOnMoon = (weightOnEarth * 0.17);
            Console.WriteLine("Your weight on tha Moon will be {0}", weightOnMoon);
        }
    }
}
