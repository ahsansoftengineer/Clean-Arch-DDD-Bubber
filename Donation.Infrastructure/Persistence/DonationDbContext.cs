using Donation.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Donation.Infrastructure.Persistence
{
  public class DonationDbContext : DbContext
  {
    public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
    {

    }
    public DbSet<Menu> Menus { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(DonationDbContext).Assembly
      );

      //modelBuilder.Model.GetEntityTypes()
      //  .SelectMany(e => e.GetProperties())
      //  .Where(p => p.IsPrimaryKey())
      //  .ToList()
      //  .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

      base.OnModelCreating(modelBuilder);
    }
  }
}
// dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
