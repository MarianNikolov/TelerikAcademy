using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> commandParameters)
        {
            Engine.Students.Add(
                id,
                new Student(commandParameters[0], commandParameters[1], (Grade)int.Parse(commandParameters[2])));

            return $"A new student with name {commandParameters[0]} {commandParameters[1]}, grade {(Grade)int.Parse(commandParameters[2])} and ID {id++} was created.";
        }
    }
}
