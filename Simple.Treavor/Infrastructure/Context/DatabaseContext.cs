using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple.Treavor.Infrastructure.Configuration;
using Simple.Treavor.Infrastructure.Data;

namespace Simple.Treavor.Infrastructure.Context
{
    // Step 1 Identity Extending
    // public class DatabaseContext : DbContext
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Step 2 Recalling Base OnModelCreating 
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Country>().HasData(SeedCountry.Data);
            modelBuilder.ApplyConfiguration(
              new CountryConfiguration());
            modelBuilder.ApplyConfiguration(
              new HotelConfiguration());
            modelBuilder.ApplyConfiguration(
              new RoleConfiguration());
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //  base.OnConfiguring(optionsBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //  modelBuilder.ApplyConfigurationsFromAssembly(
        //    typeof(DonationDbContext).Assembly
        //  );
        //  base.OnModelCreating(modelBuilder);
        //}
    }
}

