using System.Collections.Generic;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> commandParameters)
        {
            var teacherId = int.Parse(commandParameters[0]);
            var studentId = int.Parse(commandParameters[1]);

            var student = Engine.Students[teacherId];
            var teacher = Engine.Teachers[studentId];

            teacher.AddMark(student, float.Parse(commandParameters[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(commandParameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
