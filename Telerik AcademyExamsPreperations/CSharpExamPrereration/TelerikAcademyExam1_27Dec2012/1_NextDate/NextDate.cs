using System;
using System.Globalization;
using System.Threading;

class NextDate
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

        string day = Console.ReadLine();
        string month = Console.ReadLine();
        string year = Console.ReadLine();
        
        string date = day + "." + month + "." + year;
        DateTime dateForPrint = DateTime.Parse(date);

        Console.WriteLine(dateForPrint.AddDays(1));


    }
}

