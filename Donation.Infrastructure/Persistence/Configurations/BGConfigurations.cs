using Donation.Domain.HierarchyAggregate;
using Donation.Domain.SimpleAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class BGConfigurations : IEntityTypeConfiguration<BG>
  {
    public void Configure(EntityTypeBuilder<BG> builder)
    {
      ConfigureBGTable(builder);
    }

    private void ConfigureBGTable(EntityTypeBuilder<BG> builder)
    {
      builder.ToTable("BGs");
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
    }
  }
}
