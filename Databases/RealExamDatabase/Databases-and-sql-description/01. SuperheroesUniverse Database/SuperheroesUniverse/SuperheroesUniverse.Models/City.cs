using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}