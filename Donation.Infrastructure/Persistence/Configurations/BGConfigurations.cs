using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class BGConfigurations : IEntityTypeConfiguration<BG>
  {
    public void Configure(EntityTypeBuilder<BG> builder)
    {
      ConfigureBGTable(builder);
      ConfigureBGLEIdsTable(builder);
    }

    private void ConfigureBGLEIdsTable(EntityTypeBuilder<BG> builder)
    {
      builder.OwnsMany(m => m.LEIds, dib =>
      {
        dib.ToTable("BGLEIds");
        dib.WithOwner().HasForeignKey("BGId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("LEIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(BG.LEIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureBGTable(EntityTypeBuilder<BG> builder)
    {
      builder.ToTable("BGs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => BGId.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);
    }
  }
}
