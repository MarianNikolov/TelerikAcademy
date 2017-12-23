using System;

class EmployeeData
{

    //Problem 10. Employee Data
    //A marketing company wants to keep record of its employees. Each record would have the following characteristics:

    //First name
    //Last name
    //Age (0...100)
    //Gender (m or f)
    //Personal ID number (e.g. 8306112507)
    //Unique employee number (27560000…27569999)

    //Declare the variables needed to keep the information for a single employee using appropriate primitive data types. 
    //Use descriptive names. Print the data at the console.

    static void Main()
    {
        Console.WriteLine("RECORD FOR NEW EMPLOYEE");
        Console.WriteLine();
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        string LastName = Console.ReadLine();
        Console.Write("Enter your age: ");
        int ege = int.Parse(Console.ReadLine());
        Console.Write("Enter your gender('m' or 'f'): ");
        string gender = (Console.ReadLine());
        Console.Write("Enter your personal ID number (ten numbers): ");
        long personalNumber = long.Parse(Console.ReadLine());
        Console.Write("Enter your unique employee number (from 27560000 to 27569999): ");
        long uniqueEmployeeNumber = long.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Employee: " + firstName + " " + LastName);
        Console.WriteLine("Ege: {0}", ege);
        if (gender == "m")
	        {
		        Console.WriteLine("Gender: Male");
	        }
        else if (gender == "f")
            {
                Console.WriteLine("Gender: Female");
            }
        else
	        {
                Console.WriteLine("The gender is not input!!!");
	        }
        Console.WriteLine("Personal ID number: " + personalNumber);
        Console.WriteLine("Unique number: " + uniqueEmployeeNumber);
        Console.WriteLine();
    }
}

