using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JITC.Models.Configuration
{
    public class HelicopterConfiguration : IEntityTypeConfiguration<Helicopter>
    {
        public void Configure(EntityTypeBuilder<Helicopter> builder)
        {

            builder.ToTable("Helicopter");

            builder.HasData(

                    new Helicopter() { Id = 1, Name = "Eurocopter AS 355 F1/F2 Ecureuil III", Capacity = 5, Speed = 220, Motor = "deux turbines du modèle de Rolls Royce 250-C20F", NbrVol=1, Statut = "ok" },
                    new Helicopter() { Id = 2, Name = "Bell 206 JetRanger", Capacity = 4, Speed = 190, Motor = "une turbine du type Rolls Royce 250-C20B", NbrVol = 1, Statut = "ok" },
                    new Helicopter() { Id = 3, Name = "Robinson R44 Raven II", Capacity = 3, Speed = 190, Motor = "un piston du type Lycoming modèle IO-540", NbrVol = 0, Statut = "ok" }
                );


        }


    }
}
