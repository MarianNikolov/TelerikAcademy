using System;
using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            Engine.Students.Remove(int.Parse(commandParameters[0]));
            return $"Student with ID {int.Parse(commandParameters[0])} was sucessfully removed.";
        }
    }
}
