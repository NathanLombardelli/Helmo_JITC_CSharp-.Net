using System.ComponentModel.DataAnnotations;

namespace JITC.Models.ViewModel.BindingModel
{
    public class ReservationVerifViewModel
    {

        [Range(1, 20)]
        public int nbrRes { get; set; }

    }
}
