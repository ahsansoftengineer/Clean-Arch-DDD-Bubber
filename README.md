# Donation
## Most Used Principle
### Clean Architecture, DDD, Onion Archetecture
#### Solution Structure
1. Domain: (-) :| Entities, Models, ValueObjects, Aggregate, AggregateRoot :|: ErrorOr
2. Contract: (-) :| Request, Response, Query, Commands, CommandHandlers :|:  (-)
3. Application: (Domain) :| CommandHandler, QueryHandler, CommandValidator, ValidationBehavior :|: FluentValidation, FluentValidation.AspNetCore, MediatR, |: 
4. Infrastructure: (Application) :| DbContext, Repository, Migration, Configuration, JWT :|: EntityFrameworkCore.SqlServer, Extensions.Configuration, Extensions.Options.ConfigurationExtensions, AspNetCore.Authentication.JwtBearer, System.IdentityModel.Tokens.Jwt |:
5. Presentation, API: (Contract, Application, Infrastructure) :| Controller, MappingConfiguration CQRS :|: Mapster, OpenApi, EntityFrameworkCore.Design |:
6. Core: This is the innermost layer that contains the application's business logic, domain models, and interfaces for accessing external resources.



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
