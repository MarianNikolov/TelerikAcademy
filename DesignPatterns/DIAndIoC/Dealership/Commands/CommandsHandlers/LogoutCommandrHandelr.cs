using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Engine;

namespace Dealership.Commands.CommandsHandler
{
    public class LogoutCommandrHandelr : CommandHandler
    {
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandle(ICommand command)
        {
            bool result = command.Name == "command";

            return result;
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            engine.LoggedUser = null;

            return UserLoggedOut;
        }
    }
}
