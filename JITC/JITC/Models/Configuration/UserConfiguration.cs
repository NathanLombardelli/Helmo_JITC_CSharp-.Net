using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JITC.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.HasData(

                    //Admin , mdp: qwerty
                    new ApplicationUser { Id = "727df886-7a0c-4054-b16f-5ab4cb8ee996", UserName = "M.Ney@jitc.com", NormalizedUserName ="M.NEY@JITC.com", Email = "M.Ney@jitc.com", NormalizedEmail = "M.NEY@JITC.com", PasswordHash = "AQAAAAEAACcQAAAAELoSbWu11fxFTINfXsrWxl7Ul25w/FFPraTDbfCUu5VOe1zGVQxo3u8z6gwIpnGeAQ==", SecurityStamp = "EQHWSRQSOP2DCCCNEIRYW3O4K7366GQE", ConcurrencyStamp = "fd8f46c7-b0fb-4c4d-bd5f-8f03b0c5d6f8", TwoFactorEnabled = false, PhoneNumberConfirmed = false, LockoutEnabled = true, EmailConfirmed = false, AccessFailedCount = 0, Surname = "Mo", Name = "Ney" },
                    
                    //Pilote1 : mdp:qwerty
                    new ApplicationUser { Id = "455d681b-784e-4f5f-9183-92cf2b177ba1", UserName = "D.Balav@jitc.com", NormalizedUserName = "D.BALAV@JITC.COM", Email = "D.Balav@jitc.com", NormalizedEmail = "D.BALAV@JITC.COM", PasswordHash = "AQAAAAEAACcQAAAAEOLhzMeMFWHYNnt+3mUZMcHs9rHCD9ugEmETiWXqXmtloV43wsfOMn2msBlrQYG1/g==", SecurityStamp = "RHJKU6CSZV256QOS5AAAFXNJTYKBYO5Y", ConcurrencyStamp = "41add713-835a-4296-b719-1470e6910360", TwoFactorEnabled = false, PhoneNumberConfirmed = false, LockoutEnabled = true, EmailConfirmed = false, AccessFailedCount = 0, Surname = "Danièle", Name = "Balav" },
                    //Pilote2 : mdp:qwerty
                    new ApplicationUser { Id = "8b0fd074-380b-42ca-8d93-fe8667880e82", UserName = "T.Sabine@jitc.com", NormalizedUserName = "T.SABINE@JITC.COM", Email = "T.Sabine@jitc.com", NormalizedEmail = "T.SABINE@JITC.COM", PasswordHash = "AQAAAAEAACcQAAAAEHqWDAIxCfOkpvMduAy5G0/hgP9nJ91S325UswB2JYDjG3SvRxhIlRcS4JGRuhphcw==", SecurityStamp = "ZXQH66Z3VX2Z3W3BARTLSXZJ75XKOJYD", ConcurrencyStamp = "631d2ef9-1d8c-414f-afc1-84950ef4ffd5", TwoFactorEnabled = false, PhoneNumberConfirmed = false, LockoutEnabled = true, EmailConfirmed = false, AccessFailedCount = 0, Surname = "Thierry", Name = "Sabine" },
                    //Pilote3 : mdp:qwerty
                    new ApplicationUser { Id = "b2346ce4-0260-488e-87ab-80596abfcc53", UserName = "E.Coptere@jitc.com", NormalizedUserName = "E.COPTERE@JITC.COM", Email = "E.Coptere@jitc.com", NormalizedEmail = "E.COPTERE@JITC.COM", PasswordHash = "AQAAAAEAACcQAAAAEF4U3cE15v71F/ioIA0zUnnarYMTGpf8n9sosAK3DXlsY9VY6Fgo/gcDY4RYeryGpQ==", SecurityStamp = "37ZECPFEJXXTHQ7JFMH5SGW4ZYI4GDTY", ConcurrencyStamp = "01c28bf5-a10f-4465-9c5d-cb4356984312", TwoFactorEnabled = false, PhoneNumberConfirmed = false, LockoutEnabled = true, EmailConfirmed = false, AccessFailedCount = 0, Surname = "Eli", Name = "Coptère" }

                    );

        }
    }
}
