using System.Collections.Generic;

namespace Dealership.Commands
{
    public interface ICommandTranslater
    {
        ICommand TranslateInput(string input);
    }
}