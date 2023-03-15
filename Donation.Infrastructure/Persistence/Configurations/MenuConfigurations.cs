//using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu;
using Donation.Domain.Menu.Entities;
using Donation.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donation.Infrastructure.Persistence.Configurations
{
  public class MenuConfigurations : IEntityTypeConfiguration<Menu>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
      ConfigureMenuTable(builder);
      ConfigureMenuSectionTable(builder);
      //ConfigureMenuDinnerIdsTable(builder);
      //ConfigureMenuReviewIdsTable(builder);
    }

    //private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    //{
    //  builder.OwnsMany(m => m.MenuReviewIds, dib =>
    //  {
    //    dib.ToTable("MenuReviewIds");
    //    dib.WithOwner().HasForeignKey("MenuId");
    //    dib.HasKey("Id");
    //    dib.Property(d => d.Value)
    //      .HasColumnName("MenuReviewIds")
    //      .ValueGeneratedNever();
    //  }) ;
    //  builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
    //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    //}
    //private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    //{
    //  builder.OwnsMany(m => m.DinnerIds, dib =>
    //  {
    //    dib.ToTable("MenuDinnerIds");
    //    dib.WithOwner().HasForeignKey("MenuId");
    //    dib.HasKey("Id");
    //    dib.Property(d => d.Value)
    //      .HasColumnName("DinnerIds")
    //      .ValueGeneratedNever();
    //  });
    //  builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
    //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    //}
    private void ConfigureMenuSectionTable(EntityTypeBuilder<Menu> builder)
    {
      // m => Menu
      // sb => Navigation Builder Menu
      // ib => Item Builder
      builder.OwnsMany(
        m => m.Sections, 
        sb =>
        {
          sb.ToTable("MenuSections");
          sb.WithOwner().HasForeignKey("MenuId");
          sb.HasKey("Id", "MenuId");
          sb.Property(s => s.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(
              id => id.Value,
              value => MenuSectionId.Create(value));

          sb.Property(s => s.Name)
            .HasMaxLength(100);

          sb.Property(s => s.Description)
            .HasMaxLength(100);

          sb.OwnsMany(s => s.Items, ib =>
          {
            ib.ToTable("MenuItems");

            ib.WithOwner()
              .HasForeignKey("MenuSectionId", "MenuId");

            ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

            ib.Property(i => i.Id)
              .HasColumnName("MenuItemId")
              .ValueGeneratedNever()
              .HasConversion(
                id => id.Value,
                value => MenuItemId.Create(value));

            ib.Property(s => s.Name)
              .HasMaxLength(100);

            ib.Property(s => s.Description)
              .HasMaxLength(100);
          });
          sb.Navigation(s => s.Items).Metadata.SetField("_items");
          sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);

        });
      // ! for tell compiler that their will be no null
      builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
    {
      builder.ToTable("Menus");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => MenuId.Create(value)
      );

      builder.Property(x => x.Name)
        .HasMaxLength(100);

      builder.Property(m => m.Description)
        .HasMaxLength(100);

      builder.OwnsOne(m => m.AverageRating);
      //builder.Property(m => m.HostId)
      //  .HasConversion(
      //    id => id.Value,
      //    value => HostId.Create(value)
      //  );
    }
  }
}
