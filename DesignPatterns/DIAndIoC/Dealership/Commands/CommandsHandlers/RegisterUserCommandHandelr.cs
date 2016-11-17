using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Engine;

namespace Dealership.Commands.CommandsHandler
{
    public class RegisterUserCommandHandelr : CommandHandler
    {
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        private const string UserRegisterеd = "User {0} registered successfully!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RegisterUser";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];
            var firstName = command.Parameters[1];
            var lastName = command.Parameters[2];
            var password = command.Parameters[3];
            var role = Role.Normal;

            if (command.Parameters.Count > 4)
            {
                role = (Role)Enum.Parse(typeof(Role), command.Parameters[4]);
            }

            if (engine.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, engine.LoggedUser.Username);
            }

            if (engine.Users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(UserAlreadyExist, username);
            }

            var user = engine.Factory.CreateUser(username, firstName, lastName, password, role.ToString());
            engine.LoggedUser = user;
            engine.Users.Add(user);

            return string.Format(UserRegisterеd, username); 
        }
            
    }
}
