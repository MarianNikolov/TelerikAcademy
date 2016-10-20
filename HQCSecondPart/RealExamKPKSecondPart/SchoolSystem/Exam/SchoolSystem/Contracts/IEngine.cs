using System.Collections.Generic;
using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents an action that start project.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Starts execution on the project.
        /// </summary>
        void Start();
    }
}