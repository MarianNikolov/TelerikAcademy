namespace Problem17_LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Test
    {
        static void Main()
        {
            /*
            Problem 17. Longest string
            Write a program to return the string with maximum length from an array of strings.
            Use LINQ.
            */
            string line = new string('#', 20);
            Console.WriteLine("\n" + line + "    Problem 17   " + line + "\n\r");

            List<string> texts = new List<string>()
           {
               "Ivan",
               "Gosho",
               "Petio",
               "BasshMaistorska",
               "DqdoKoleda",
               "MerryChristmas",
               "HappyNewYear",

           };
            var longestString = texts
                .OrderByDescending(x => x.Length).ToList();

            Console.WriteLine(longestString[0]);

        }
    }
}
