using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common;
using Dealership.Engine;

namespace Dealership.Commands.CommandsHandler
{
    public class RemoveCommentCommandHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        private const string CommentRemovedSuccessfully = "{0} removed comment successfully!";
        private const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";


        private IValidateRangeProvider validateRangeProvider;

        public RemoveCommentCommandHandler(IValidateRangeProvider validateRangeProvider)
        {
            this.validateRangeProvider = validateRangeProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            bool result = command.Name == "RemoveComment";

            return result;
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            var user = engine.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            this.validateRangeProvider.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, RemovedVehicleDoesNotExist);
            this.validateRangeProvider.ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            engine.LoggedUser.RemoveComment(comment, vehicle);

            return string.Format(CommentRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
