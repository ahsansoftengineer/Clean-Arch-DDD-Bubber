
### Commands to work with EF Migration & Docker
#### .NET CLI Tools
- This Tool is useful for Migrations
```csharp
dotnet tool list --global
dotnet tool install --global dotnet-ef
Install-Package Microsoft.EntityFrameworkCore.Tools // Power Shell
dotnet ef migrations add InitialCreate -p Donation.Infrastructure -s Donation.Api
```

#### Docker 
```csharp
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=asdf1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps
dotnet ef database update -p Donation.Infrastructure -s Donation.Api --connection "Server=localhost;Database=Donation;User Id=sa;Password=asdf1234;Encrypt=false"

dotnet clean
dotnet restore
dotnet build
dotnet run --project Donation.Api

````