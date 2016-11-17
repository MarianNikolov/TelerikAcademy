using Dealership.Engine;

namespace Dealership.Commands
{
    public interface ICommandHandler
    {
        string HandleCommand(ICommand command, IDealershipEngine engine);

        void SetNext(ICommandHandler nextHandler);
    }
}