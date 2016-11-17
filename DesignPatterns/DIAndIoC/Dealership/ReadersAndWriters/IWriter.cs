using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Contracts.ReadersAndWriters
{
    public interface IWriter
    {
        void WriteLine(string text = null);

        void Write(string text = null);
    }
}
