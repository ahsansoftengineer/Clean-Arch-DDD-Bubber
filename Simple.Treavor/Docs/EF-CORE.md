### Migrations
```csharp
dotnet tool list --global
dotnet tool install --global dotnet-ef
Install-Package Microsoft.EntityFrameworkCore.Tools // Power Shell
// PM Package Manager Console
Add-Migration NameOfMigration -Context DatabaseContextName
// When you have One DBContext and One Project
dotnet ef migrations add NameOfMigration 
// When you have two or more Projects
dotnet ef migrations add NameOfMigration -p Donation.Infrastructure -s Donation.Api
// When you have Two or More DB Context
dotnet ef migrations add NameOfMigration --context DatabaseContextName
// docker pull mcr.microsoft.com/mssql/server:2022-latest
// docker image ls
// docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=asdf1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
// docker ps
// PM Package Manager Console
UPDATE-DATABASE -Context DatabaseContext
dotnet ef database update -p Donation.Infrastructure -s Donation.Api --connection "SERVER=.;DATABASE=Donation;USER=sa;PASSWORD=asdf1234;Encrypt=false"
dotnet run --project Donation.Api
``` 

### Most Used EF-CORE COMMANDS
```csharp
// Multiple Projects
ADD-MIGRATION NameOfMigration -Context DatabaseContextName
UPDATE-DATABASE -Context DatabaseContext

// Single Projects
ADD-MIGRATION NameOfMigration
UPDATE-DATABASE
```

