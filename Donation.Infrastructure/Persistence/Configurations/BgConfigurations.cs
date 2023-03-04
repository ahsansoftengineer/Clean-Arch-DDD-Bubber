using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class BGConfigurations : IEntityTypeConfiguration<BG>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<BG> builder)
    {
      ConfigureBGTable(builder);
      ConfigureSystemzIdsTable(builder);
    }
    private void ConfigureSystemzIdsTable(EntityTypeBuilder<BG> builder)
    {
      builder.OwnsMany(m => m.LeIds, dib =>
      {
        dib.ToTable("BgLeIds");
        dib.WithOwner().HasForeignKey("BgId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("LeIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(BG.LeIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureBGTable(EntityTypeBuilder<BG> builder)
    {
      builder.ToTable("BG");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => GenericValueObjectId.Create(value)
      );
      builder.Property(x => x.Title)
        .HasMaxLength(100);
      builder.Property(m => m.Description)
        .HasMaxLength(100);
    }
  }
}