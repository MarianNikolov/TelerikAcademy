using MvcTemplate.Data.Migrations;
using MvcTemplate.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTemplate.App_Start
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}