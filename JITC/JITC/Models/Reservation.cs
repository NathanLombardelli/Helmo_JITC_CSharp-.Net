using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class Reservation
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Vol Vol { get; set; }

        [Required]
        public string ClientId { get; set; }

        public DateTime Date { get; set; }

        public int NbrPlaces { get; set; }


        public Boolean IsCancellable ()
        { // si moins de 24H avant le départ => pas possible d'annuler.

            TimeSpan tempMin = new TimeSpan(24, 0, 0);

            return Vol.DepartPrevu - DateTime.Now > tempMin;

        }

    }
}
