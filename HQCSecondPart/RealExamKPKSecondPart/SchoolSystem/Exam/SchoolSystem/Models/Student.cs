namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student : Human
    {
        private const int MaxNumberOfMarks = 20;
        private const string StudentMarksListEmptyMessage = "This student has no marks.";

        private Grade grads;
        private List<Mark> mark;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grads = grade;
            this.Mark = new List<Mark>();
        }

        public Grade Grads
        {
            get
            {
                return this.grads;
            }

            set
            {
                this.grads = value;
            }
        }

        public List<Mark> Mark
        {
            get
            {
                return this.mark;
            }

            set
            {
                this.mark = value;
            }
        }

        public string ListMarks()
        {
            if (this.Mark.Count == 0)
            {
                throw new ArgumentException(StudentMarksListEmptyMessage);
            }

            var marksCollection = this.Mark.Select(m => $"{m.Subject} => {m.Value}").ToList();
            var result = string.Join("\n", marksCollection);

            return result;
        }
    }
}
