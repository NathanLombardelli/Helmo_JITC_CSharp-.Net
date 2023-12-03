using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JITC.Models.Configuration
{
    public class PiloteConfiguration : IEntityTypeConfiguration<Pilote>
    {
        public void Configure(EntityTypeBuilder<Pilote> builder)
        {

            builder.ToTable("Pilote");

            builder.HasData(

                    new Pilote() { Id = 1, Name = "Balav", Surname = "Danièle", Email = "D.Balav@jitc.com" },
                    new Pilote() { Id = 2, Name = "Sabine", Surname = "Thierry", Email = "T.Sabine@jitc.com" },
                    new Pilote() { Id = 3, Name = "Coptère", Surname = "Eli", Email = "E.Coptère@jitc.com" }

                );


        }


    }
}
