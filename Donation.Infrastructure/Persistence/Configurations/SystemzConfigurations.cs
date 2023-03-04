using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class SystemzConfigurations : IEntityTypeConfiguration<Systemz>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<Systemz> builder)
    {
      ConfigureSystemzTable(builder);
    }
    private void ConfigureSystemzTable(EntityTypeBuilder<Systemz> builder)
    {
      builder.ToTable("Systemz");
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

      builder.Property(m => m.OrgId)
        .HasConversion(
          id => id.Value,
          value => GenericValueObjectId.Create(value)
        );
    }
  }
}
