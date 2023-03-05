using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class SystemzConfigurations : IEntityTypeConfiguration<Systemz>
  {
    public void Configure(EntityTypeBuilder<Systemz> builder)
    {
      ConfigureSystemzTable(builder);
    }
    private void ConfigureSystemzTable(EntityTypeBuilder<Systemz> builder)
    {
      builder.ToTable("Systemzs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => SystemzId.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);

      builder.Property(m => m.OrgId)
        .HasConversion(
          id => id.Value,
          value => OrgId.Create(value)
        );
    }
  }
}
