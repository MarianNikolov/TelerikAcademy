using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private ISchoolRegister schoolRegister;
        public RemoveTeacherCommand(ISchoolRegister schoolRegister)
        {
            this.schoolRegister = schoolRegister;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            if (!this.schoolRegister.Teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.schoolRegister.Teachers.Remove(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
