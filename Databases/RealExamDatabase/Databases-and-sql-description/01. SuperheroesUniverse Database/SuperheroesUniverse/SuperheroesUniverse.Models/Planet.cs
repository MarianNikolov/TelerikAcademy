using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}