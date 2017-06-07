using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseDbContext : DbContext
    {
        public SuperheroesUniverseDbContext() : base("SuperheroesUniverse")
        {

        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Power> Powers { get; set; }

        public IDbSet<Fraction> Fractions { get; set; }

        public IDbSet<Superhero> Superheros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
