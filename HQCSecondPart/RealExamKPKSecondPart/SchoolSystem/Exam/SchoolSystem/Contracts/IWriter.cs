using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents an action that write input data.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Write message for users.
        /// </summary>
        /// <param name="massege">The massege.</param>
        void WriteMassege(string massege);
    }
}
