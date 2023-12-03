using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JITC.Models.Configuration
{
    public class VolConfiguration : IEntityTypeConfiguration<Vol>
    {
        public void Configure(EntityTypeBuilder<Vol> builder)
        {
            builder.ToTable("Vols");

            builder.HasData(

                    new { Id = 1,AeroportArriverId = 1,AeroportDepartId = 2,DepartPrevu = new DateTime(2022, 05, 09,10,30,0) , ArriverPrevu = new DateTime(2022, 05, 09, 11, 30, 0), HelicopterId = 1, PiloteId = 1, DepartFinal= new DateTime(2022, 05, 09, 10, 30, 0), ArriverFinal = new DateTime(2022, 05, 09, 11, 30, 0),RaisonRetard="", Distance=0.0 },
                    new { Id = 2, AeroportArriverId = 3, AeroportDepartId = 4, DepartPrevu = new DateTime(2022, 08, 1, 14, 30, 0), ArriverPrevu = new DateTime(2022, 08, 1, 16, 30, 0), HelicopterId = 2, PiloteId = 2, DepartFinal = new DateTime(2022, 08, 1, 14, 30, 0), ArriverFinal = new DateTime(2022, 08, 1, 17, 0, 0), RaisonRetard = "détour car tempête", Distance = 0.0 },
                    
                    new { Id = 3, AeroportArriverId = 1, AeroportDepartId = 3, DepartPrevu = new DateTime(2022, 09, 7, 12, 0, 0), ArriverPrevu = new DateTime(2022, 09, 7, 14, 30, 0), HelicopterId = 3, PiloteId = 3, DepartFinal = new DateTime(), ArriverFinal = new DateTime(), RaisonRetard = "", Distance = 0.0 },
                    new { Id = 4, AeroportArriverId = 2, AeroportDepartId = 4, DepartPrevu = new DateTime(2022, 09, 21, 9, 30, 0), ArriverPrevu = new DateTime(2022, 09, 21, 13, 30, 0), HelicopterId = 1, PiloteId = 2, DepartFinal = new DateTime(), ArriverFinal = new DateTime(), RaisonRetard = "", Distance = 0.0 },
                    new { Id = 5, AeroportArriverId = 1, AeroportDepartId = 2, DepartPrevu = new DateTime(2022, 10, 5, 12, 30, 0), ArriverPrevu = new DateTime(2022, 10, 5, 16, 30, 0), HelicopterId = 2, PiloteId = 1, DepartFinal = new DateTime(), ArriverFinal = new DateTime(), RaisonRetard = "", Distance = 0.0}
                );
        }
    }
}
