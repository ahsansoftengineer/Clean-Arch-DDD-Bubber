using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class LEConfigurations : IEntityTypeConfiguration<LE>
  {
    public void Configure(EntityTypeBuilder<LE> builder)
    {
      ConfigureLETable(builder);
      ConfigureLEOUIdsTable(builder);
    }
    private void ConfigureLEOUIdsTable(EntityTypeBuilder<LE> builder)
    {
      builder.OwnsMany(m => m.OUIds, dib =>
      {
        dib.ToTable("LEOUIds");
        dib.WithOwner().HasForeignKey("LEId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("OUIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(LE.OUIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureLETable(EntityTypeBuilder<LE> builder)
    {
      builder.ToTable("LEs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => LEId.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);

      builder.Property(m => m.BGId)
        .HasConversion(
          id => id.Value,
          value => BGId.Create(value)
        );
    }
  }
}
