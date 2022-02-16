using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTasckMVC.Models
{
    [Table("employees")]
    public class Employee
    {
        [Required]
        [Column("id")]
        [Key]
        public int Id { get; private set; }

        [Column("name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Column("surname")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string SurName { get; set; }

        [ForeignKey("position_id")]
        [Column("position_id")]
        public int PositionId { get; set; }

        [Column(TypeName = "position_id")]
        public Position Position { get; set; }
    }
}
