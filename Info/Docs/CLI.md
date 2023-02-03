## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash \ to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### Commands
1. Creating a Solution
- dotnet new sln -o SolutionName
2. Creating WEB API
- dotnet new webapi -o ProjectName.Api
3. Creating LIBRARY
- dotnet new classlib -o ProjectName.Contracts
- dotnet new classlib -o ProjectName.Infrastructure
- dotnet new classlib -o ProjectName.Application
- dotnet new classlib -o ProjectName.Domain
4. To See the Content within a file
- more.\SolutionName.sln
5. To add all the Projects within in the Solution Recursively
- dotnet sln add (ls -r **\*.csproj) // Powershell Command
- dotnet sln remove .\Donation.Contacts\Donation.Contacts.csproj
6. dotnet build
7. Adding Projects to Solution
- dotnet add .\Donation.Api\ reference .\Donation.Contracts\ .\Donation.Application\
- dotnet add .\Donation.Infrastructure\ reference .\Donation.Application\
- dotnet add .\Donation.Application\ reference .\Donation.Domain\
- dotnet add .\Donation.Api\ reference .\Donation.Infrastructure\
8. To Run a Specific Project
- dotnet run --project .\Donation.Api\
- dotnet watch run --project .\Donation.Api\
8. To Open a Folder in FileExplorer Windows
- start .
9. dotnet new gitignore
10. git init
11. Adding Packages to Specific Project
- dotnet add .\Donation.Infrastructure\ package Microsoft.Extensions.Configuration
- dotnet add .\Donation.Infrastructure\ package Microsoft.Extensions.Options.ConfigurationExtensions
12. To Initialize User-Secrets in a Specific Project
- dotnet user-secrets init --project .\Donation.Api\
- dotnet user-secrets set --project .\Donation.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
- dotnet user-secrets list --project .\Donation.Api\
