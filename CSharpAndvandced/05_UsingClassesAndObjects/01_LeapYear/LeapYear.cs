using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class LeapYear
    {
        static string FindLeapYear(int year)
        {
            if (DateTime.IsLeapYear(year))
            {
                return "Leap";
            }
            else
            {
                return "Common";
            }
        }

        static void Main()
        {
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(FindLeapYear(year)); 
        }
    }

