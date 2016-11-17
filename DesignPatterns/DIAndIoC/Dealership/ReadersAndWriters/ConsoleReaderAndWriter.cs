using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Contracts.ReadersAndWriters;

namespace Dealership.ReadersAndWriters
{
    public class ConsoleReaderAndWriter : IReaderAndWriter, IConsoleReaderAndWriter
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }

        public void Write(string text = null)
        {
            Console.Write(text);
        }

        public void WriteLine(string text = null)
        {
            Console.WriteLine(text);
        }
    }
}
