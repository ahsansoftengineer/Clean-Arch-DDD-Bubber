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
