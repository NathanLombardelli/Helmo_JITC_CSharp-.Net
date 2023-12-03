namespace JITC.Models.ViewModel
{
    public class ReservationViewModel
    {

        public Vol Vol { get; set; }

        public Aeroport Depart { get; set; }

        public Aeroport Arriver { get; set; }

        public int PlaceDisponible { get; set; }

        public string Error { get; set; }

        public string Success { get; set; }

        internal void RetirerPlaces(int nbrRes)
        {
             PlaceDisponible -= nbrRes;
        }
    }
}
