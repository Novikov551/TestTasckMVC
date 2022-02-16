using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestTasckMVC.Models
{
    [Table("positions")]
    public class Position
    {
        [Required]
        [Column("id")]
        [Key]
        public int Id { get; private set; }

        [Column("name")]
        [Required(ErrorMessage = "Please add a position name.")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
