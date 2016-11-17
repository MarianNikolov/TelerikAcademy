using System.Collections.Generic;

namespace Dealership.Commands
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string name, IList<string> parameters);
    }
}