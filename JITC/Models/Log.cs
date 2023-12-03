using System.ComponentModel.DataAnnotations;

namespace JITC.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public int VolId { get; set; }

        public string Modification { get; set; }

        public DateTime Date { get; set; }

    }
}
