using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class OUConfigurations : IEntityTypeConfiguration<OU>
  {
    public void Configure(EntityTypeBuilder<OU> builder)
    {
      ConfigureOUTable(builder);
    }
    private void ConfigureOUTable(EntityTypeBuilder<OU> builder)
    {
      builder.ToTable("OUs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => SimpleValueObject.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);

      builder.Property(m => m.LEId)
        .HasConversion(
          id => id.Value,
          value => SimpleValueObject.Create(value)
        );
    }
  }
}
