using Dealership.Engine;
using System;
using System.IO;
using Ninject;
using Dealership.Factories;
using Dealership.Contracts.ReadersAndWriters;
using Dealership.ReadersAndWriters;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            StandardKernel normalKernel = new StandardKernel(new DealershipModule());

            IDealershipEngine dealershipEngine = normalKernel.Get<IDealershipEngine>();
            dealershipEngine.Start();
        }
    }
}
