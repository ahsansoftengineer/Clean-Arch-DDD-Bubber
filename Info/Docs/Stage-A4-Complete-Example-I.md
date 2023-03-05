### JSON
```json
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": { "value": "00000000-0000-0000-0000-000000000000" },
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ],
  "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
  "dinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "menuReviewIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
### DB Table
```sql
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Description]
      ,[AverageRating_Value]
      ,[AverageRating_NumRatings]
      ,[HostId]
      ,[CreatedDateTime]
      ,[UpdatedDateTime]
  FROM [Donation].[dbo].[Menus]
  
SELECT TOP (1000) [MenuSectionId]
      ,[MenuId]
      ,[Name]
      ,[Description]
  FROM [Donation].[dbo].[MenuSections]
  
SELECT TOP (1000) [MenuItemId]
      ,[MenuSectionId]
      ,[MenuId]
      ,[Name]
      ,[Description]
  FROM [Donation].[dbo].[MenuItems]
```

### ValueObjects
```csharp
namespace Donation.Domain.Common.Models
{
  public abstract class ValueObject
  {
    public abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
      if(obj is null || obj.GetType() != GetType()) return false;

      var valueObject = (ValueObject)obj;

      return GetEqualityComponents()
        .SequenceEqual(valueObject.GetEqualityComponents());
    }
    public static bool operator ==(ValueObject left, ValueObject right)
    {
      return Equals(left, right);
    }
    public static bool operator !=(ValueObject left, ValueObject right)
    {
      return !Equals(left, right);
    }
    public override int GetHashCode()
    {
      return GetEqualityComponents()
        .Select(x => x?.GetHashCode() ?? 0)
        .Aggregate((x, y) => x ^ y);
    }
    public bool Equals(ValueObject? other)
    {
      return Equals((object?)other);  
    }
  }
}
```
### Base ValueObject
```csharp
namespace Donation.Domain.Common.Models
{
  public class GenericValueObjectId : ValueObject
  {
    public Guid Value { get; }

    protected GenericValueObjectId(Guid value)
    {
      Value = value;
    }
    public static GenericValueObjectId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static GenericValueObjectId Create(Guid value)
    {
      return new GenericValueObjectId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
```
### MenuId
```csharp
namespace Donation.Domain.Menu.ValueObjects
{
  public sealed class MenuId : ValueObject
  {
    public Guid Value { get; }
    private MenuId(Guid value) 
    {
      Value = value;
    }
    public static MenuId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static MenuId Create(Guid value)
    {
      return new MenuId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
```
### MenuSectionId
```csharp
 public sealed class MenuSectionId : ValueObject
  {
    public Guid Value { get; }
    private MenuSectionId(Guid value)
    {
      Value = value;
    }
    public static MenuSectionId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static MenuSectionId Create(Guid value)
    {
      return new MenuSectionId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
```
### MenuItemId
```csharp
namespace Donation.Domain.Menu.ValueObjects
{
  public sealed class MenuItemId : ValueObject
  {
    public Guid Value { get; }
    private MenuItemId(Guid value) 
    {
      Value = value;
    }
    public static MenuItemId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static MenuItemId Create(Guid value)
    {
      return new MenuItemId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
```
### DinnerIds Value Object
```csharp
namespace Donation.Domain.Dinner.ValueObjects
{
  public sealed class DinnerId : ValueObject
  {
    public Guid Value { get; }

    private DinnerId(Guid value)
    {
      Value = value;
    }
    public static DinnerId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static DinnerId Create(Guid value)
    {
      return new DinnerId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
```
### MenuReviewIds Value Object
```csharp
namespace Donation.Domain.MenuReview.ValueObjects
{
  public sealed class MenuReviewId: ValueObject
  {
    public Guid Value { get; }

    private MenuReviewId(Guid value)
    {
      Value = value;
    }
    public static MenuReviewId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static MenuReviewId Create(Guid value)
    {
      return new MenuReviewId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}

```
### Value Object Rating
```csharp
namespace Donation.Domain.Common.ValueObjects
{
  public sealed class AverageRating : ValueObject
  {
    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    private AverageRating(double value, int numRatings)
    {
      Value = value;
      NumRatings = numRatings;
    }
    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
      return new AverageRating(rating, numRatings); 
    }
    public void AddNewRating(Rating rating)
    {
      Value = ((Value * NumRatings) + rating.Value) / (++NumRatings);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}

```
### Entity
```csharp
namespace Donation.Domain.Common.Models
{
  public abstract class Entity<TId> : IEquatable<Entity<TId>>  where TId : notnull
  {
    public TId Id { get; protected set; }
    protected Entity(TId id)
    {
      Id = id;  
    }
    public override bool Equals(object? obj)
    {
      return obj is Entity<TId> entity && Equals((Entity<TId>)obj);
    }
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
      return Equals(left, right);
    }
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
      return !Equals(left, right);
    }
    public override int GetHashCode() 
    { 
      return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
      return Equals((object?)other);
    }
#pragma warning disable CS8618
    protected Entity() { }
#pragma warning restore CS8618

  }
```
### Aggregate Root
```csharp
namespace Donation.Domain.Common.Models
{
  public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
  {
    protected AggregateRoot(TId id) : base(id) { }
#pragma warning disable CS8618
    protected AggregateRoot() { }
#pragma warning restore CS8618

  }
}
```

### Aggregate Root Base
```csharp
namespace Donation.Domain.Hierarchy
{
  public class AggregateRootBase : AggregateRoot<GenericValueObjectId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UPdatedAt { get; private set; }

    protected AggregateRootBase(
        GenericValueObjectId valueObject,
        string title,
        string description)
        : base(valueObject)
    {
      Title = title;
      Description = description;
    }

    public static AggregateRootBase Create(
      string title,
      string description)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    protected AggregateRootBase() { }
#pragma warning restore CS8618
  }
}
```
### MenuItem
```csharp
public sealed class MenuItem : Entity<MenuItemId>
{
  private readonly List<MenuItem> items = new();
  public string Name { get; }
  public string Description { get; }
  private MenuItem(
    MenuItemId menuItemId, 
    string name, 
    string description): base(menuItemId)
  {
    Name = name;
    Description = description;
  }
  public static MenuItem Create(
    string name,
    string description)
  {
    return new(MenuItemId.CreateUnique(), name, description);
  }
}
```
### MenuSection
```csharp
public sealed class MenuSection : Entity<MenuSectionId>
{
  private readonly List<MenuItem> items = new();
  public string Name { get; }
  public string Description { get; }
  IReadOnlyList<MenuItem> Items => items.AsReadOnly(); // AS per need .ToList();
  private MenuSection(
    MenuSectionId menuSectionId,
    string name, 
    string description): base(menuSectionId)
  {
    Name = name;
    Description = description;
  }
  public static MenuSection Create(
    string name,
    string description)
  {
    return new(
      MenuSectionId.CreateUnique(),
      name,
      description);
  }
}
```
### Menu
```csharp
namespace Donation.Domain.Menu
{
  public sealed class Menu : AggregateRoot<MenuId>
  {
    private readonly List<MenuSection> sections = new();
    private readonly List<DinnerId> dinners = new();
    private readonly List<MenuReviewId> menuReview = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get;}
    public DateTime CreatedDateTime { get; }  
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnersIds => dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReview.AsReadOnly();

    // Constructor
    private Menu(
      MenuId menuId,
      string name,
      string description, 
      HostId hostId,
      DateTime createdDateTime, 
      DateTime updatedDateTime) : base(menuId)
    {
      Name = name;
      Description = description;
      HostId = hostId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static Menu Create(
      string name,
      string description,
      HostId hostId)
    {
      return new(
        MenuId.CreateUnique(),
        name,
        description,
        hostId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}
```
### Dinners (Only to See MenuId)
```csharp
namespace Donation.Domain.Dinner
{
  public sealed class Dinner : AggregateRoot<DinnerId>
  {
    private readonly List<Reservation> reservations = new();

    public string Name { get; }
    public string Description { get; }
    public DinnerStatus DinnerStatus { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; } 
    public string ImageUrl { get; }

    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId{ get; }
    public MenuId MenuId { get; }
    public Location Location { get; } // Name, Address, Latitude, Longitude
    public Price Price { get; } // Amount, Currency
    public IReadOnlyList<Reservation> Reservations => reservations.AsReadOnly();

    public Dinner(
      DinnerId dinnerId,
      string name,
      string description,
      DateTime startedDateTime,
      DateTime endedDateTime,
      HostId hostId,
      MenuId menuId,
      Location location,
      Price price,
      DateTime createdDateTime,
      DateTime updatedDateTime) : base(dinnerId)
    {
      Name = name;
      Description = description;
      StartedDateTime = startedDateTime;
      EndedDateTime= endedDateTime;
      HostId = hostId;
      MenuId = menuId;
      Location = location;
      Price = price;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    
    public static Dinner Create(
      string name,
      string description,
      DateTime startedDateTime,
      DateTime endedDateTime,
      HostId hostId,
      MenuId menuId,
      Location location,
      Price price)
    {
      return new(
        DinnerId.CreateUnique(),
        name,
        description,
        startedDateTime,
        endedDateTime,
        hostId,
        menuId,
        location,
        price,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}
```
### Table Mapping
```csharp
namespace Donation.Infrastructure.Persistence.Configurations
{
  public class MenuConfigurations : IEntityTypeConfiguration<Menu>
  {
    // This File Generated Based on the Image StageA2-EF-Core-Z-DB-Diagram-III.png
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
      ConfigureMenuTable(builder);
      ConfigureMenuSectionTable(builder);
      ConfigureMenuDinnerIdsTable(builder);
      ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
      builder.OwnsMany(m => m.MenuReviewIds, dib =>
      {
        dib.ToTable("MenuReviewIds");
        dib.WithOwner().HasForeignKey("MenuId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("MenuReviewIds")
          .ValueGeneratedNever();
      }) ;
      builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
      builder.OwnsMany(m => m.DinnerIds, dib =>
      {
        dib.ToTable("MenuDinnerIds");
        dib.WithOwner().HasForeignKey("MenuId");
        dib.HasKey("Id");
        dib.Property(d => d.Value)
          .HasColumnName("DinnerIds")
          .ValueGeneratedNever();
      });
      builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
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
      builder.Property(m => m.HostId)
        .HasConversion(
          id => id.Value,
          value => HostId.Create(value)
        );
    }
  }
}

```
