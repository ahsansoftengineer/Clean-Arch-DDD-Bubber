using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class SUConfigurations : IEntityTypeConfiguration<SU>
  {
    public void Configure(EntityTypeBuilder<SU> builder)
    {
      ConfigureSUTable(builder);
    }
    private void ConfigureSUTable(EntityTypeBuilder<SU> builder)
    {
      builder.ToTable("SUs");
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

      builder.Property(m => m.OUId)
        .HasConversion(
          id => id.Value,
          value => SimpleValueObject.Create(value)
        );
    }
  }
}
