using System;

namespace Decorator
{
    public class Startup
    {
        static void Main()
        {
            Course coursePatterns = new Course("Design patterns", "Enterprise", 172);
            coursePatterns.PrintOnConsole();

            Console.WriteLine(new string('-', 20));

            CourseWithTrainer coursePatternsWithTrainer = new CourseWithTrainer(coursePatterns, "Vikor");
            coursePatternsWithTrainer.PrintOnConsole();

            Console.WriteLine();
            Console.WriteLine(new string('=', 20));
            Console.WriteLine();

            Course courseDatabase = new Course("Database", "Ultimate", 184);
            courseDatabase.PrintOnConsole();

            Console.WriteLine(new string('-', 20));

            CourseWithRepositoryDirectory courseDatabaseWithRepository = new CourseWithRepositoryDirectory(courseDatabase);
            courseDatabaseWithRepository.DirectoryName = "https://github.com/TelerikAcademy/Databases";
            courseDatabaseWithRepository.PrintOnConsole();
        }
    }
}
