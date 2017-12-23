using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3_Divide_by_7_and_5
{
    class Program
    {
        /*
         Problem 3. Divide by 7 and 5

    Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.

    Examples:
    n 	    Divided by 7 and 5?
    3 	    false
    0 	    true
    5 	    false
    7 	    false
    35 	    true
    140 	true
         */ 
        static void Main()
        {
            Console.Write("Enter a number: ");
            double number = double.Parse(Console.ReadLine());
            if ((number % 7 == 0) && (number % 5 == 0)) 
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
