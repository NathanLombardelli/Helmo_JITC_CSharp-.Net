using System.ComponentModel.DataAnnotations;

namespace JITC.Models.ViewModel
{
    public class ProfilVerifViewModel
    {

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
