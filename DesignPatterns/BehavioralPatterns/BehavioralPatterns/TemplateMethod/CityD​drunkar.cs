using System;

namespace TemplateMethod
{
    internal class CityD​drunkar : Drinker
    {
        public CityDdrunkar(string name) : base(name)
        {
        }

        protected override string TakeBooze()
        {
            return "WHISKEY";
        }

        protected override string Аppetizer()
        {
            return "FILLET ELENA";
        }
    }
}
