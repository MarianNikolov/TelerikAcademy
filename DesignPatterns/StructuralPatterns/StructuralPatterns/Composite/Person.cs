using System;

namespace Composite
{
    public abstract class Person : IPerson
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public abstract void PrintOnConsole(int depth);
    }
}