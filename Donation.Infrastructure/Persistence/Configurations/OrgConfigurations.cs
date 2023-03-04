using Donation.Domain.Common.Models;
using Donation.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class OrgConfigurations : IEntityTypeConfiguration<Org>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<Org> builder)
    {
      toTable(builder);
      ConfigureSystemzIdsTable(builder);
    }
    private void ConfigureSystemzIdsTable(EntityTypeBuilder<Org> builder)
    {
      builder.OwnsMany(m => m.SystemzIds, dib =>
      {
        dib.ToTable("OrgSystemzIds");
        dib.WithOwner().HasForeignKey("OrgId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("SystemzIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(Org.SystemzIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void toTable(EntityTypeBuilder<Org> builder)
    {
      builder.ToTable("Org");
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
    }
  }
}