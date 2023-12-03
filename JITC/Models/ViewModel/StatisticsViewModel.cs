namespace JITC.Models.ViewModel
{
    public class StatisticsViewModel
    {

        public IList<Helicopter> Helicopters { get; set; }

        public double[] TauxRemplissageData { get; set; }

        public string[] HelicoptersNameData { get; set; }

        public string[] RaisonRetard { get; set; }

        public int[] NbrRaison { get; set; }

        public int NbrRetard { get; set; }

    }
}
