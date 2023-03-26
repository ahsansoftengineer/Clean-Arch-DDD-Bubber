using Microsoft.EntityFrameworkCore;

namespace Simple.Treavor.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(SeedCountry.Data);
            modelBuilder.Entity<Hotel>().HasData(SeedHotel.Data);
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

