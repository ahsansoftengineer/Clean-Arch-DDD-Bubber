## EF Core DB Context

### NuGet Packages
```csharp
dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore 
dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore.Design
```
### Models
#### Base Entities
```csharp
namespace Donation.Domain.Common.Models
{
  public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
  public abstract class Entity<TId> : IEquatable<Entity<TId>>
}
```
#### Ids / Value Object
```csharp
namespace Donation.Domain.Menu.ValueObjects
{
  public sealed class MenuId : ValueObject
  public sealed class MenuSectionId : ValueObject
  public sealed class MenuItemId : ValueObject
}
```
#### Creating Models
```csharp

namespace Donation.Domain.Menu
{
  public sealed class Menu : AggregateRoot<MenuId>
}
namespace Donation.Domain.Menu.Entities
{
  public sealed class MenuSection : Entity<MenuSectionId>
}
namespace Donation.Domain.Menu.Entities
{
  public sealed class MenuItem : Entity<MenuItemId>
}
```
### Repository
#### DB Context
```csharp
namespace Donation.Infrastructure.Persistence
{
  public class DonationDbContext : DbContext
}
```
#### Repository
```csharp
namespace Donation.Infrastructure.Persistence.Repositories
{
  public class MenuRepository : IMenuRepository
}
```
#### Configure Models to Tables
```csharp
namespace Donation.Infrastructure.Persistence.Configurations
{
  public class MenuConfigurations : IEntityTypeConfiguration<Menu>
}
```
#### Adding Dependencies
```csharp
namespace Donation.Infrastructure
{
  public static class DependencyInjection
}
```
#### Migration Generated Files
```csharp
namespace Donation.Infrastructure.Migrations
{
    [DbContext(typeof(DonationDbContext))]
    partial class DonationDbContextModelSnapshot : ModelSnapshot
}
namespace Donation.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
}
```

### Images
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-DDD.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-DDD-I.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Full-Diagram.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-II.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-III.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-IV.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-V.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-VI.png)
![EF Core](https://github.com/ahsansoftengineer/donation-DDD/blob/A2-EF-Core-DDD-CleanArchetecture/Info/Images/StageA2-EF-Core-Z-DB-Diagram-VII.png)
