using System;

namespace _15_Age
{
    class Age
    {
        static void Main()
        {
            DateTime date = DateTime.Parse(Console.ReadLine());
            int programDate = date.Year;
            int timeNow = 2015; 
            int yearsNow = timeNow - programDate;
            if (yearsNow == 0)
            {
                Console.WriteLine(0);
                Console.WriteLine(yearsNow + 10);
            }
            else if (yearsNow == -1)
            {
                Console.WriteLine(0);
                Console.WriteLine(yearsNow + 11);
            }
            else
            {
                Console.WriteLine(yearsNow);
                Console.WriteLine(yearsNow + 10);
            }
        }
    }
}
