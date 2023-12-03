using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace JITC.Models.ViewModel
{
    public class ProfilViewModel
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ErrorMessage { get; set; }

        public IList<Reservation> Reservations { get; set; }

        public IList<Aeroport> Aeroports { get; set; }


    }
}
