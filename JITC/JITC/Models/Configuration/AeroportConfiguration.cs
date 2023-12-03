using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JITC.Models.Configuration
{

    public class AeroportConfiguration : IEntityTypeConfiguration<Aeroport>
    {
        public void Configure(EntityTypeBuilder<Aeroport> builder)
        {

            builder.ToTable("Aeroports");

            builder.HasData(

                    new Aeroport() { Id = 1, Name = "Liège", Latitude = "50.64318", Longitude = "5.46083" },
                    new Aeroport() { Id = 2, Name = "Charleroi", Latitude = "50.46434", Longitude = "4.45966" },
                    new Aeroport() { Id = 3, Name = "Bruxelles", Latitude = "50.90114", Longitude = "4.48539" },
                    new Aeroport() { Id = 4, Name = "Oostende", Latitude = "51.20467", Longitude = "2.86983" }

                );


        }


    }
}
