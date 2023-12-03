namespace JITC.Models.ViewModel
{
    public class MesVolsViewModel
    {

        public IList<Vol> VolsFini { get; set; }

        public IList<Vol> VolsFutur { get; set; }

        public IList<Aeroport> Aeroports { get; set; }

        public string Error { get; set; }


    }
}
