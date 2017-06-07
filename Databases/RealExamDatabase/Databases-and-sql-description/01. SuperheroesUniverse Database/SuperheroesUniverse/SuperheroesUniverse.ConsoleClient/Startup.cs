using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using SuperheroesUniverse.ConsoleClient.JsonImporters;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Migrations;

namespace SuperheroesUniverse.ConsoleClient
{
    public class Startup
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesUniverseDbContext, Configuration>());
            new SuperheroesUniverseDbContext().Database.Initialize(true);

            IKernel kernel = new StandardKernel();

            kernel.Bind<DbContext>().To<SuperheroesUniverseDbContext>();
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IJsonImporter>().To<JsonImporter>();

            IJsonImporter jsonImporter = kernel.Get<IJsonImporter>();
            jsonImporter.Import();
        }
    }
}
