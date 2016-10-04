using System.Collections.Generic;

namespace ClassChefInCSharp
{
    public class Bowl
    {
        private IEnumerable<Vegetable> vegetablesInBowl;

        public Bowl()
        {
            this.vegetablesInBowl = new List<Vegetable>();
        }

        public IEnumerable<Vegetable> VegetablesInBowl
        {
            get
            {
                return this.vegetablesInBowl;
            }
            private set
            {
                this.vegetablesInBowl = value;
            }
        }
    
        public void Add(Vegetable vegetable)
        {

        }
    }
}