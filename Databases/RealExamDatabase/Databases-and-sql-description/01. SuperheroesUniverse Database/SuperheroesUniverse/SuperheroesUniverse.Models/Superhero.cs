using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        private ICollection<Fraction> superheroFractions;
        private ICollection<Power> superheroPowers;

        public Superhero()
        {
            this.superheroFractions = new HashSet<Fraction>();
            this.superheroPowers = new HashSet<Power>();
        }

        public virtual ICollection<Fraction> SuperheroFractions
        {
            get { return this.superheroFractions; }
            set { this.superheroFractions = value; }
        }

        public virtual ICollection<Power> SuperheroPowers
        {
            get { return this.superheroPowers; }
            set { this.superheroPowers = value; }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string SecretIdentity { get; set; }

        [Required]
        public AlignmentType Alignment { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Story { get; set; }

        [Required]
        public int CityThatProtectId { get; set; }

        public virtual City CityThatProtect { get; set; }

        
    }
}
