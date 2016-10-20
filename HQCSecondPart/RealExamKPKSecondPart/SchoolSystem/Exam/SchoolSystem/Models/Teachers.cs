namespace SchoolSystem.Models
{
    public class Teacher : Human
    {
        private Subjct subject;

        public Teacher(string firstName, string lastName, Subjct subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subjct Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }

        public void AddMark(Student teacher, float value)
        {
            var mark = new Mark(this.Subject, value);
            teacher.Mark.Add(mark);
        }
    }
}
