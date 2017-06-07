using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Planet> protectsPlanets;
        private ICollection<Superhero> superheros;

        public Fraction()
        {
            this.protectsPlanets = new HashSet<Planet>();
            this.superheros = new HashSet<Superhero>();
        }

        public virtual ICollection<Planet> ProtectsPlanets
        {
            get { return this.protectsPlanets; }
            set { this.protectsPlanets = value; }
        }

        public virtual ICollection<Superhero> Superheros
        {
            get { return this.superheros; }
            set { this.superheros = value; }
        }


        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public AlignmentType Aligment { get; set; }


    }
}