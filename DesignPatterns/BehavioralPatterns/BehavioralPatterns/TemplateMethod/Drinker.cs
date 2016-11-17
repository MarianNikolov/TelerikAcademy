using System;

namespace TemplateMethod
{
    internal abstract class Drinker
    {
        private string name;

        public Drinker(string name)
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

        public void Drink()
        {
            Аppetizer();

            TakeBooze();

            Report();
        }

        protected abstract string Аppetizer();

        protected abstract string TakeBooze();

        protected virtual void Report()
        {
            Console.WriteLine($"{this.Name} drink {this.TakeBooze()} with {this.Аppetizer()}!");
        }
    }
}
