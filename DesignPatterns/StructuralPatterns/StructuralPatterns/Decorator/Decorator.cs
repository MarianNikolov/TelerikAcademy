using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Decorator : AcademyComponent
    {
        public AcademyComponent AcademyComponent { get; set; }

        public Decorator(AcademyComponent academyComponent)
        {
            this.AcademyComponent = academyComponent;
        }

        public override void PrintOnConsole()
        {
            this.AcademyComponent.PrintOnConsole();
        }
    }
}
