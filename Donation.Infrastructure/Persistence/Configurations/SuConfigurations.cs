using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  //public class SuConfigurations : IEntityTypeConfiguration<SU>
  //{
  //  // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
  //  public void Configure(EntityTypeBuilder<SU> builder)
  //  {
  //    toTable(builder);
  //  }
  //  private void toTable(EntityTypeBuilder<SU> builder)
  //  {
  //    builder.ToTable("SU");
  //    builder.HasKey(x => x.Id);
  //    builder.Property(x => x.Id)
  //      .ValueGeneratedNever()
  //      .HasConversion(
  //        id => id.Value,
  //        value => GenericValueObjectId.Create(value)
  //    );

  //    builder.Property(x => x.Title)
  //      .HasMaxLength(100);

  //    builder.Property(m => m.Description)
  //      .HasMaxLength(100);

  //    builder.Property(m => m.OuId)
  //      .HasConversion(
  //        id => id.Value,
  //        value => GenericValueObjectId.Create(value)
  //      );
  //  }
  //}
}
