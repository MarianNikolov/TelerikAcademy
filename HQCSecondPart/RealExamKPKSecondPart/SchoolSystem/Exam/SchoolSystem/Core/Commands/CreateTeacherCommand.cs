using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> commandParameters)
        {
            Engine.Teachers.Add(
                id,
                new Teacher(commandParameters[0], commandParameters[1], (Subjct)int.Parse(commandParameters[2])));

            return $"A new teacher with name {commandParameters[0]} {commandParameters[1]}, subject {(Subjct)int.Parse(commandParameters[2])} and ID {id++} was created.";
    }
    }
}
