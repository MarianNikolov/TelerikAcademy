using System.Reflection;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Factories
{
    public interface ICommandFactory
    {
        ICommand CretaCurrenCommand(TypeInfo typeInfo);
    }
}