# Donation
## Most Used Principle
### Clean Architecture, DDD, Onion Archetecture
#### Solution Structure
| Layer | Internal Libraries | External Libraries | Purpose |
|:----------:|:----:|:------:|:----------:|
| Domain | - | ErrorOr | Entities, Models, ValueObjects, Aggregate, AggregateRoot | 
| Contract | - | - | Request, Response, Query, Commands, CommandHandlers
| Application | Domain | FluentValidation, FluentValidation.AspNetCore, MediatR | CommandHandler, QueryHandler, CommandValidator, ValidationBehavior |
| Infrastructure | Application | EntityFrameworkCore.SqlServer, Extensions.Configuration, Extensions.Options.ConfigurationExtensions, AspNetCore.Authentication.JwtBearer, System.IdentityModel.Tokens.Jwt | DbContext, Repository, Migration, Configuration, JWT |
| Presentation / API | Contract, Application, Infrastructure | Mapster, OpenApi, EntityFrameworkCore.Design | Controller, MappingConfiguration CQRS | 
|
  <td> Core</td>
  <td colspan="4">This is the innermost layer that contains the application's business logic, domain models, and interfaces for accessing external resources.</td>
|
 
## SOLID 
- Single Responsibility (SRP)
- Open-Closed Principle (OCP)
- Liskov Substitution (LSP)
- Interface Segregation (ISP)
- Dependency Inversion (DIP)

## OOP 
- Inheritance 
- Abstraction
- Polymorphism
- Encapsulation

### Libraries

 Marvin Caching
### CQRS Common Query Segregation
### Domain Driven Design
### Model-View-Controller (MVC)

## Concepts
### API Versioning
### API Caching,
### JWT
### Async Programming in DotNet

## Patterns

### Pub Sub
### Repository
### Factory
### Singleton
### Observer
### Decorator
### Command
### Adapter
### Facade
### Template Method
