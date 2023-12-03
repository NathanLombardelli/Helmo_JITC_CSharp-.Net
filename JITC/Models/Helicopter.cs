using System.ComponentModel.DataAnnotations;

namespace JITC.Models
{
    public class Helicopter
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public int Speed { get; set; }

        [Required]
        [MaxLength(100)]
        public string Motor { get; set; }

        private int _nbrVol;
        public int NbrVol
        {
            get { return _nbrVol; }
            set { 
                _nbrVol = value;
                if(_nbrVol >= 5)
                {
                    Statut = "A Réviser";
                    _nbrVol = 0;
                }
            }
        }

        public string Statut { get; set; }

    }
}
