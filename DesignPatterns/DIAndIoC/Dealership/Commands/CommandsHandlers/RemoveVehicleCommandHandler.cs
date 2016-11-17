using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common;
using Dealership.Engine;

namespace Dealership.Commands.CommandsHandler
{
    public class RemoveVehicleCommandHandler : CommandHandler
    {
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";

        

        protected override bool CanHandle(ICommand command)
        {
            bool result = command.Name == "RemoveVehicle";

            return result;
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            RangeValidator.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];

            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
