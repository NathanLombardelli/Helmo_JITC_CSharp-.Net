using GeoCoordinatePortable;
using System.ComponentModel.DataAnnotations;


namespace JITC.Models
{
    public class Aeroport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        internal double CalulerDistance(Aeroport Aarriver)
        {
            GeoCoordinate depart = new GeoCoordinate()
            {
                Longitude = double.Parse(Longitude, System.Globalization.CultureInfo.InvariantCulture),
                Latitude = double.Parse(Latitude, System.Globalization.CultureInfo.InvariantCulture)
            };
            GeoCoordinate arriver = new GeoCoordinate()
            {
                Longitude = double.Parse(Aarriver.Longitude, System.Globalization.CultureInfo.InvariantCulture),
                Latitude = double.Parse(Aarriver.Latitude, System.Globalization.CultureInfo.InvariantCulture)
            };

            return Math.Round(depart.GetDistanceTo(arriver)/1000,2);
        }
    }
}
