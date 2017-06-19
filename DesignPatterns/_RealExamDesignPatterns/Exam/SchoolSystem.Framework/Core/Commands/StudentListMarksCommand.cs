using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private ISchoolRegister schoolRegister;

        public StudentListMarksCommand(ISchoolRegister schoolRegister)
        {
            this.schoolRegister = schoolRegister;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.schoolRegister.Students[studentId];
            return student.ListMarks();
        }
    }
}
