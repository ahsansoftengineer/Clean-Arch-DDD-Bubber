using Donation.Domain.Hierarchy;
using Donation.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace Donation.Infrastructure.Persistence
{
  public class DonationDbContext : DbContext
  {
    public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
    {

    }
    public DbSet<Menu> Menus { get; set; } = null!;
    public DbSet<Org> Orgs { get; set; } = null!;
    public DbSet<Systemz> Systemzs { get; set; } = null!;
    public DbSet<BG> BGs { get; set; } = null!;
    public DbSet<LE> LEs { get; set; } = null!;
    public DbSet<OU> OUs { get; set; } = null!;
    public DbSet<SU> SUs { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(DonationDbContext).Assembly
      );
      base.OnModelCreating(modelBuilder);
    }
  }
}