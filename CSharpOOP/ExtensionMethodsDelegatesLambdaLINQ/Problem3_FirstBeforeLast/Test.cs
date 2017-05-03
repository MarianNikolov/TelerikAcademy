
// from problem 3 to 5

namespace Problem3_FirstBeforeLast
{
    using System;
    using System.Linq;
    class Test
    {
        static void Main()
        {
            /*
            Problem 3. First before last
            Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
            Use LINQ query operators.
            */
            var studentsArray = new Student[]
            {
            new Student("Atanas", "Bokov", 25),
            new Student("Pesho", "Georgiev", 33),
            new Student("Milen", "Atanasov", 18),
            new Student("Georgi", "Petrov", 38),
            new Student("Mitko", "Petkov", 55),
            new Student("Asen", "Simov", 23)
            };

            string line = new string('#', 20);
            Console.WriteLine("\n" + line + "    Problem 3   " + line + "\n\r");

            var sortedStudentByName = SortStudentByName(studentsArray);
            foreach (var s in sortedStudentByName)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName);
            }
            Console.WriteLine();

            /*
            Problem 4. Age range
            Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            */
            Console.WriteLine("\n" + line + "    Problem 4   " + line + "\n\r");
            var sortedStudentByAge = SortStudentByAge(studentsArray);
            foreach (var s in sortedStudentByAge)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName + " " + s.Age);
            }
            Console.WriteLine();

            /*
            Problem 5. Order students
            Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
            Rewrite the same with LINQ.
            */
            Console.WriteLine("\n" + line + "    Problem 5   " + line + "\n\r");
            var orderedStudentsByDescending = studentsArray
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
            foreach (var s in orderedStudentsByDescending)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName + " " + s.Age);
            }
        }

        public static Student[] SortStudentByName(Student[] students)
        {
            var filteredStudents =
                    from s in students
                    where (int)s.FirstName[0] <= (int)s.LastName[0]
                    select s;

            return filteredStudents.ToArray();
        }

        public static Student[] SortStudentByAge(Student[] students)
        {
            var filteredStudents =
                    from s in students
                    where s.Age >= 18 && s.Age <= 24
                    select s;

            return filteredStudents.ToArray();
        }

    }

}
