# Donation
## Most Used Principle
### Clean Architecture, DDD, Onion Archetecture
1. Domain: (-) : Entities, Models, ValueObjects, Aggregate, AggregateRoot
2. Contract: (-) : (Request, Response, Query, Commands, CommandHandlers) 
3. Application: (Domain) : This layer contains the application services that coordinate the interactions between the Core and Infrastructure layers.
4. Infrastructure: (Application) : This layer contains the implementation of the interfaces defined in the Core layer, such as data access and logging.
5. Presentation, API: (Contract, Application, Infrastructure) :This layer contains the UI and any other presentation-related logic, such as user input handling.
6. Core: This is the innermost layer that contains the application's business logic, domain models, and interfaces for accessing external resources.



## SOLID 
- Single Responsibility Principle (SRP)
- Open-Closed Principle (OCP)
- Liskov Substitution Principle (LSP)
- Interface Segregation Principle (ISP)
- Dependency Inversion Principle (DIP)

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

## Patterns
#### Repository
#### Factory
#### Singleton
#### Observer
#### Decorator
#### Command
#### Adapter
#### Facade
#### Template Method
