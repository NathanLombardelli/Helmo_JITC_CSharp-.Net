using System.ComponentModel.DataAnnotations;

namespace JITC.Models.ViewModel.BindingModel
{
    public class RechercheVolVerifViewModel
    {


        public string aero_depart { get; set; }

        public string aero_arriver { get; set; }

        [Required(ErrorMessage = "Veuillez sélèctioner une date valide")]
        [DataType(DataType.Date)]

        public DateTime date { get; set; }

    }
}
