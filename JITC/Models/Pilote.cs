using System.ComponentModel.DataAnnotations;

namespace JITC.Models
{
    public class Pilote
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

    }
}
