using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Contracts;

namespace SchoolSystem
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
