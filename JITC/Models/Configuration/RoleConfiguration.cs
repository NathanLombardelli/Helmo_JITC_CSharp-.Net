using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JITC.Models.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {

            IdentityRole admin = new IdentityRole() { Id = "23d6e9d7-8036-43f0-9cc6-19385cb02866", Name = "Admin", NormalizedName = "ADMIN" };
            IdentityRole pilote = new IdentityRole() { Id = "83ccc92a-72ba-45e8-af2f-03400704e6d2", Name = "Pilote", NormalizedName = "PILOTE" };

            builder.ToTable("AspNetRoles");

            builder.HasData(admin);
            builder.HasData(pilote);

        }
    }
}
