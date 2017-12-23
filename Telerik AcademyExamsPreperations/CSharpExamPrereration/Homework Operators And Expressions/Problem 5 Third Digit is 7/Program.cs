using System;

class Program
{
    /*
     Problem 5. Third Digit is 7?

    Write an expression that checks for given integer if its third digit from right-to-left is 7.

    Examples:
    n 	        Third digit 7?
    5 	        false
    701 	    true
    9703 	    true
    877 	    false
    777877 	    false
    9999799 	true
     */
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter a integer number: ");
            int n = int.Parse(Console.ReadLine());
            if ((n / 100) % 10 == 7)
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

