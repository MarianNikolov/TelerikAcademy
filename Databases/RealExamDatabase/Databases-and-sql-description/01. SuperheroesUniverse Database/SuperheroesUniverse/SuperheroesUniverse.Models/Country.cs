using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}