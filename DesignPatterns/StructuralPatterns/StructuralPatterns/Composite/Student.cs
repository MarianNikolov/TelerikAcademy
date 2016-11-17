using System;
namespace Composite
{
    public class Student : Person, IStudent
    {
        public Student(string name) : base(name)
        {
        }

        public override void PrintOnConsole(int depth)
        {
            Console.WriteLine(new string('-', depth) + $" {this.Name}");
        }
    }
}
