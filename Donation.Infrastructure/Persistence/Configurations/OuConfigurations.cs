using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  //public class OUConfigurations : IEntityTypeConfiguration<OU>
  //{
  //  // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
  //  public void Configure(EntityTypeBuilder<OU> builder)
  //  {
  //    toTable(builder);
  //    ConfigureOuSuIdsTable(builder);
  //  }
  //  private void ConfigureOuSuIdsTable(EntityTypeBuilder<OU> builder)
  //  {
  //    builder.OwnsMany(m => m.SuIds, dib =>
  //    {
  //      dib.ToTable("OuSuIds");
  //      dib.WithOwner().HasForeignKey("OuId");
  //      dib.HasKey("Id");
  //      dib.Property(d => d.Value)
  //        .HasColumnName("SuIds")
  //        .ValueGeneratedNever();
  //    });
  //    builder.Metadata.FindNavigation(nameof(OU.SuIds))!
  //      .SetPropertyAccessMode(PropertyAccessMode.Field);
  //  }
  //  private void toTable(EntityTypeBuilder<OU> builder)
  //  {
  //    builder.ToTable("OU");
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

  //    builder.Property(m => m.LeId)
  //      .HasConversion(
  //        id => id.Value,
  //        value => GenericValueObjectId.Create(value)
  //      );
  //  }
  //}
}
