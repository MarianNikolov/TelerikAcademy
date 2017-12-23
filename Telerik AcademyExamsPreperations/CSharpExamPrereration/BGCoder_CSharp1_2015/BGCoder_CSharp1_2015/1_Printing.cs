using System;

namespace BGCoder_CSharp1_2015
{
    class Printing
    {
        static void Main()
        {
            decimal numberOfStudents = decimal.Parse(Console.ReadLine());
            decimal numberOfSheetsForStudent = decimal.Parse(Console.ReadLine());
            decimal priceOfOneBox = decimal.Parse(Console.ReadLine());

            decimal sheets = numberOfStudents * numberOfSheetsForStudent;
            decimal box = sheets / 500;
            decimal priceOfSheetForStudent = box * priceOfOneBox;
            Console.WriteLine("{0:F2}", priceOfSheetForStudent);
        }
    }
}
