using System;

namespace Strategy
{
    internal class Student
    {
        private string name;

        public Student(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public void ExamPreparation(IPractice examPreparation)
        {
            Console.WriteLine($"{this.Name} {examPreparation.Practis()}" );
        }
    }
}
