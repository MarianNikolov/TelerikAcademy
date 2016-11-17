using System;

namespace Strategy
{
    internal class Startup
    {
        static void Main()
        {
            ReadBookPractice examPreparation = new ReadBookPractice();
            WriteCodePractice secondExamPreparation = new WriteCodePractice();
            Student pesho = new Student("Pesho");

            Console.WriteLine("** First preparation **");
            pesho.ExamPreparation(examPreparation);

            Console.WriteLine("---------------------------");

            Console.WriteLine("** Second preparation **");
            pesho.ExamPreparation(secondExamPreparation);
        }
    }
}
