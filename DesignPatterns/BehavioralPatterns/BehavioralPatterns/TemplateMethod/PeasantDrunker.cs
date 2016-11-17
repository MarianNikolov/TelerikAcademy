using System;

namespace TemplateMethod
{
    internal class PeasantDrunker : Drinker
    {
        public PeasantDrunker(string name) : base(name)
        {
        }

        protected override string TakeBooze()
        {
            return "RAKIA";
        }

        protected override string Аppetizer()
        {
            return "SHOPSKA SALAD";
        }
    }
}
