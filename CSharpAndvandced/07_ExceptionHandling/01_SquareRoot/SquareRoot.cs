using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SquareRoot
{
    static void Main()
    {
        try
        {
            double input = double.Parse(Console.ReadLine());
            double output = Math.Sqrt(input);
            
            if (double.IsNaN(output))
            {
                Console.WriteLine("Invalid number");
            }

            else
            {
                Console.WriteLine("{0:F3}", output);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}

