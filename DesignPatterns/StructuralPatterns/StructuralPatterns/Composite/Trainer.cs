using System;
using System.Collections.Generic;

namespace Composite
{
    internal class Trainer : Person, ITrainer
    {
        private IList<IPerson> dependentPersons;

        public Trainer(string name) : base(name)
        {
            this.DependentPersons = new List<IPerson>();
        }

        public IList<IPerson> DependentPersons
        {
            get
            {
                return this.dependentPersons;
            }

            set
            {
                this.dependentPersons = value;
            }
        }

        public void AddPerson(IPerson person)
        {
            this.DependentPersons.Add(person);
        }

        public void SetMark(IStudent student)
        {
            //...
        }

        public override void PrintOnConsole(int depth)
        {
            Console.WriteLine(new string('-', depth) + $" {this.Name}");

            foreach (var person  in DependentPersons)
            {
                person.PrintOnConsole(depth + 4);
            }
        }
    }
}