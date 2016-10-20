using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Interface represents an command object which provides execution.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// From collections of command parameters, returns message.
        /// </summary>
        /// <param name="commandParameters">The parameters.</param>
        /// <returns>String message</returns>
        string Execute(IList<string> commandParameters);
    }
}
