using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JITC.Models.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
        {


            IdentityUserRole<string> userRoleAdmin = new IdentityUserRole<string>() { UserId = "727df886-7a0c-4054-b16f-5ab4cb8ee996", RoleId = "23d6e9d7-8036-43f0-9cc6-19385cb02866" };
            IdentityUserRole<string> userRolePilote1 = new IdentityUserRole<string>() { UserId = "455d681b-784e-4f5f-9183-92cf2b177ba1", RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2" };
            IdentityUserRole<string> userRolePilote2 = new IdentityUserRole<string>() { UserId = "8b0fd074-380b-42ca-8d93-fe8667880e82", RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2" };
            IdentityUserRole<string> userRolePilote3 = new IdentityUserRole<string>() { UserId = "b2346ce4-0260-488e-87ab-80596abfcc53", RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2" };

            builder.ToTable("AspNetUserRoles");

            builder.HasData(userRoleAdmin);
            builder.HasData(userRolePilote1);
            builder.HasData(userRolePilote2);
            builder.HasData(userRolePilote3);
        }
    }
}
