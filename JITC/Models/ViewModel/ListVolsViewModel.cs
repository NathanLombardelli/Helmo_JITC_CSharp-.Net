namespace JITC.Models.ViewModel
{
    public class ListVolsViewModel
    {

        public IList<Vol> VolsFutur { get; set; }

        public IList<Vol> VolsPasser { get; set; }
        public IList<Aeroport> Aeroports { get; set; }

        public IDictionary<int, IList<Helicopter>> HelicoptereVols { get; set; } // idVol / liste des helico disponible pour se vol.

        public IList<Helicopter> Helicopteres { get; set; }

        public IList<Pilote> Pilotes { get; set; }

        public string Error { get; set; }

    }
}
