using System;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        private ISchoolSystemFactory schoolFactory;

        public Teacher(string firstName, string lastName, Subject subject, ISchoolSystemFactory schoolFactory)
            : base(firstName, lastName)
        {
            this.schoolFactory = schoolFactory;
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.schoolFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}
