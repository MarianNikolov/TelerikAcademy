using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int currentStudentId = 0;
        private ISchoolSystemFactory schoolFactory;
        private ISchoolRegister schoolRegister;
        public CreateStudentCommand(ISchoolSystemFactory schoolFactory, ISchoolRegister schoolRegister)
        {
            this.schoolFactory = schoolFactory;
            this.schoolRegister = schoolRegister;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.schoolFactory.CreateStudent(firstName, lastName, grade);
            this.schoolRegister.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
}
