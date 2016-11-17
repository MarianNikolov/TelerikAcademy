using System.Collections.Generic;
using Dealership.Contracts;
using Dealership.Factories;

namespace Dealership.Engine
{
    public interface IDealershipEngine 
    {
        ICollection<IUser> Users { get; set; }

        IUser LoggedUser { get; set; }
        
        IDealershipFactory Factory { get; }

        void Start();
    }
}
