using JITC.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JITC.Models
{
    public class JITCDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Installation; Trusted_Connection=True;"); //BD Local.
                optionsBuilder.UseSqlServer(@"Server=192.168.128.18; Database=in19b1170; user id=in19b1170; password=9976;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PiloteConfiguration());
            modelBuilder.ApplyConfiguration(new AeroportConfiguration());
            modelBuilder.ApplyConfiguration(new HelicopterConfiguration());
            modelBuilder.ApplyConfiguration(new VolConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            // modelBuilder.ApplyConfiguration(new UserConfiguration());

            //soluce for "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined" error
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Aeroport> Aeroports { get; set; }

        public DbSet<Vol> Vols { get; set; }

        public DbSet<Pilote> Pilotes { get; set; }

        public DbSet<Helicopter> Helicopters { get; set; }

    }
}
