using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Engine;

namespace Dealership.Commands.CommandsHandler
{
    public class ShowVehiclesCommandHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";

        protected override bool CanHandle(ICommand command)
        {
            bool result = command.Name == "ShowVehicles";

            return result;
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];

            var user = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
