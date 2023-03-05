using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class OUConfigurations : IEntityTypeConfiguration<OU>
  {
    public void Configure(EntityTypeBuilder<OU> builder)
    {
      ConfigureOUTable(builder);
      ConfigureOUSUIdsTable(builder);
    }
    private void ConfigureOUSUIdsTable(EntityTypeBuilder<OU> builder)
    {
      builder.OwnsMany(m => m.SUIds, dib =>
      {
        dib.ToTable("OUSUIds");
        dib.WithOwner().HasForeignKey("OUId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("SUIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(OU.SUIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureOUTable(EntityTypeBuilder<OU> builder)
    {
      builder.ToTable("OUs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => OUId.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);

      builder.Property(m => m.LEId)
        .HasConversion(
          id => id.Value,
          value => LEId.Create(value)
        );
    }
  }
}
