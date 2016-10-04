using System;

namespace ClassChefInCSharp
{
    public class Vegetable
    {
        private bool thereVegetablePeel;
        private bool isCut;

        public Vegetable()
        {
            this.thereVegetablePeel = true;
            this.isCut = false;
        }

        public bool ThereVegetablePeel
        {
            get
            {
                return this.thereVegetablePeel;
            }
            set
            {
                if (!thereVegetablePeel)
                {
                    throw new ArgumentException("The vegetable peel is already removed!");
                }
                else
                {
                    this.thereVegetablePeel = false;
                }
            }
        }

        public bool IsCut
        {
            get
            {
                return this.isCut;
            }
            set
            {
                if (isCut)
                {
                    throw new ArgumentException("The vegetable vegetable already cut!");
                }
                else
                {
                    this.isCut = true;
                }
            }
        }
    }
}