using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int currentTeacherId = 0;
        private ISchoolSystemFactory schoolFactory;
        private ISchoolRegister schoolRegister;

        public CreateTeacherCommand(ISchoolSystemFactory schoolFactory, ISchoolRegister schoolRegister)
        {
            this.schoolFactory = schoolFactory;
            this.schoolRegister = schoolRegister;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.schoolFactory.CreateTeacher(firstName, lastName, subject);
            this.schoolRegister.Teachers.Add(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId++} was created.";
        }
    }
}
