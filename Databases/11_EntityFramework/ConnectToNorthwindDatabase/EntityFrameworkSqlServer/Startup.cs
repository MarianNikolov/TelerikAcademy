using System;
using EntityFrameworkSqlServer.Data;

namespace EntityFrameworkSqlServer
{
    public class Startup
    {
        static void Main()
        {
            var dbContext = new NorthwindEntities();

            var vat = dbContext.Categories;

            foreach (var v in vat)
            {
                Console.WriteLine(v.CategoryName);
                Console.WriteLine("-------------------");
            }


            dbContext.SaveChanges();
        }
    }
}
