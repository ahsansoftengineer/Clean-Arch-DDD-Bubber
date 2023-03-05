using Donation.Domain.HierarchyAggregate;
using Donation.Domain.HierarchyAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class OrgConfigurations : IEntityTypeConfiguration<Org>
  {
    public void Configure(EntityTypeBuilder<Org> builder)
    {
      ConfigureOrgTable(builder);
      ConfigureOrgSystemzIdsTable(builder);
    }

    private void ConfigureOrgSystemzIdsTable(EntityTypeBuilder<Org> builder)
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
    private void ConfigureOrgTable(EntityTypeBuilder<Org> builder)
    {
      builder.ToTable("Orgs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => OrgId.Create(value)
      );

      builder.Property(x => x.Title)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);
    }
  }
}
