using System;

namespace Decorator
{
    public class Course : AcademyComponent
    {
        public int NumberOfStudents { get; set; }

        public Course(string name, string auditoriumName, int numberOfStudents )
        {
            this.Name = name;
            this.AuditoriumName = auditoriumName;
            this.NumberOfStudents = numberOfStudents;
        }

        public override void PrintOnConsole()
        {
            Console.WriteLine($"Course: {this.Name}");
            Console.WriteLine($"Auditorium: {this.AuditoriumName}");
            Console.WriteLine($"Number of students: {this.NumberOfStudents}");
        }
    }
}
