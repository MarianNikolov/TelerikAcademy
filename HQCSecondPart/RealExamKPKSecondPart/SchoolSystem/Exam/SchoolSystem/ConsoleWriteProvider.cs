using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;

namespace SchoolSystem
{
    public class ConsoleWriteProvider : IWriter
    {
        public void WriteMassege(string massege)
        {
            Console.WriteLine(massege);
        }
    }
}
