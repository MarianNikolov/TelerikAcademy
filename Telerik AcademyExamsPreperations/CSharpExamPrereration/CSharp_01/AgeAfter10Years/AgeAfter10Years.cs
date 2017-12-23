using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeAfter10Years
{
    class AgeAfter10Years
    {

        //Age after 10 Years

    //Write a program to read your birthday from the console and print how old you are now and how old you will be after 10 years.

        static void Main(string[] args)
        {
            

            Console.WriteLine("Enter your birthdate in the format yyyy/mm/dd");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            DateTime dateToday = DateTime.Now;
            int age = dateToday.Year - dateOfBirth.Year;

            if (dateToday.Month < dateOfBirth.Month || (dateToday.Month == dateOfBirth.Month && dateToday.Day < dateOfBirth.Day))
            {
                age--;
            }

            Console.WriteLine("You are " + age + " years old.");
            Console.WriteLine("In 10 years you will be " + (age + 10) + " years old.");

            /*

           Console.Write("Enter your age:");
            byte age = byte.Parse(Console.ReadLine());
            age += 10;
            Console.Write("Your age will be:");
            Console.WriteLine(age); 
             */
        }
    }
}
