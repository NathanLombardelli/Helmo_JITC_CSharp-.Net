using System.ComponentModel.DataAnnotations;

namespace JITC.Models
{
    public class Vol
    {

        [Key]
        public int Id { get; set; }

        public DateTime DepartPrevu { get; set; }

        public DateTime ArriverPrevu { get; set; }

        public int AeroportDepartId { get; set; }

        public int AeroportArriverId { get; set; }


        public Helicopter Helicopter { get; set; }

        public DateTime DepartFinal { get; set; }

        public DateTime ArriverFinal { get; set; }

        public string RaisonRetard { get; set; }

        public Pilote Pilote { get; set; }

        public double Distance { get; set; }

        internal int GetPlaceDispo(IList<Reservation> reservations)
        {
            int placeReserver = 0;

            foreach (Reservation reservation in reservations)
            {
                placeReserver += reservation.NbrPlaces;
            }

            return Helicopter.Capacity - placeReserver;
        }



    }
}
