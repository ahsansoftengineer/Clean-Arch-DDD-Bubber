using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class LEConfigurations : IEntityTypeConfiguration<LE>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<LE> builder)
    {
      toTable(builder);
      ConfigureLeOuIdsTable(builder);
    }
    private void ConfigureLeOuIdsTable(EntityTypeBuilder<LE> builder)
    {
      builder.OwnsMany(m => m.OuIds, dib =>
      {
        dib.ToTable("LeOuIds");
        dib.WithOwner().HasForeignKey("LeId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("OuIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(LE.OuIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void toTable(EntityTypeBuilder<LE> builder)
    {
      builder.ToTable("LE");
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

      builder.Property(m => m.BgId)
        .HasConversion(
          id => id.Value,
          value => GenericValueObjectId.Create(value)
        );
    }
  }
}
