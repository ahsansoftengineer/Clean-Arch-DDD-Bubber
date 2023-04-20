### How to Learn DDD
Learning Domain-Driven Design (DDD) can be a challenging task, but there are a few steps you can take to make the process easier:
1. Start with the basics: Begin by learning the key concepts of DDD, such as domain, bounded context, aggregates, and entities. You can start with reading books such as "Domain-Driven Design: Tackling Complexity in the Heart of Software" by Eric Evans or "Implementing Domain-Driven Design" by Vaughn Vernon.
2. Practice with examples: After you understand the key concepts, it's essential to practice them with real-world examples. You can look for sample projects or build one of your own.
3. Attend conferences and meetups: Attending conferences and meetups can help you learn from experts and network with other DDD enthusiasts.
4. Collaborate with others: Collaborating with other developers who are also learning DDD can be beneficial. You can share your knowledge, ask questions, and get feedback.
5. Use DDD tools: There are several tools available that can help you implement DDD, such as CQRS, Event Sourcing, and Repository Pattern. Use these tools to learn how DDD can be applied to real-world projects.
6. Keep learning: DDD is an ongoing process, and there is always something new to learn. Stay updated with the latest trends and advancements in DDD by reading blogs, attending webinars, and listening to podcasts.

## Clean Architecture, DDD, Onion Archetecture
<table>
  <thead>
    <tr>
      <th>Layer</th>
      <th>Internal Libraries</th>
      <th>External Libraries</th>
      <th>Purpose</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Domain</td>
      <td>-</td>
      <td>ErrorOr</td>
      <td>Entities, Models, ValueObjects, Aggregate, AggregateRoot</td>
    </tr>
    <tr>
      <td>Contract</td>
      <td>-</td>
      <td>-</td>
      <td>Request, Response, Query, Commands, CommandHandlers</td>
    </tr>
     <tr>
      <td>Application</td>
      <td>Domain</td>
      <td>
        FluentValidation, FluentValidation.AspNetCore, MediatR, MediatR.Extensions.Microsoft.DependencyInjection, Microsoft.Extensions.DependencyInjection.Abstractions
      </td>
      <td>CommandHandler, QueryHandler, CommandValidator, ValidationBehavior</td>
    </tr>
     <tr>
      <td>Infrastructure</td>
      <td>Application</td>
      <td>
        Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.Extensions.Configuration, Microsoft.Extensions.Options.ConfigurationExtensions, Microsoft.AspNetCore.Authentication.JwtBearer, System.IdentityModel.Tokens.Jwt
      </td>
      <td>DbContext, Repository, Migration, Configuration, JWT</td>
    </tr>
     <tr>
      <td>Presentation / API</td>
      <td>Contract, Application, Infrastructure</td>
      <td>
        Mapster, Mapster.DependencyInjection, Microsoft.AspNetCore.OpenApi, Microsoft.EntityFrameworkCore.Design, Swashbuckle.AspNetCore
      </td>
      <td> Controller, MappingConfiguration CQRS</td>
    </tr>
     <tr>
      <td>Trevior</td>
      <td>-</td>
      <td>ErrorOr</td>
      <td></td>
    </tr>
     <tr>
      <td>Domain</td>
      <td>-</td>
      <td colspan="2">
        AspNetCoreRateLimit, AutoMapper, AutoMapper.Extensions.Microsoft.DependencyInjection, Marvin.Cache.Headers, Microsoft.AspNetCore.Authentication.JwtBearer, Microsoft.AspNetCore.Authentication.OpenIdConnect, Microsoft.AspNetCore.Identity.EntityFrameworkCore, Microsoft.AspNetCore.Mvc.NewtonsoftJson, Microsoft.AspNetCore.Mvc.Versioning, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools, Serilog.AspNetCore, Swashbuckle.AspNetCore, "X.PagedList.Mvc.Core
      </td>
    </tr>
    <tr>
    <td>Core</td>
    <td colspan="3"> This is the innermost layer that contains the application's business logic, domain models, and interfaces for accessing external resources.</td>
    </tr>
  </tbody>
</table>

## SOLID 
| Heading | Defination |
|:-------:|:---------- | 
| Single Responsibility (SRP)  | Class, Function has the Only 1 Reason to Change |
| Open-Closed Principle (OCP)  | Make your function as flexible that it can used over and over again |
| Liskov Substitution (LSP)    | Needs short defination |
| Interface Segregation (ISP)  | Don't Make Huge Interface, Split the Big Interface into multiple small Interfaces |
| Dependency Inversion (DIP)   |  |
| Keep it Simple Stupid (KISS) |  |
| IOC Container | |



## OOP 
| Heading | Defination |
|:-------:|:---------- | 
| Inheritance  | |
| Abstraction | |
| Polymorphism | |
| Encapsulation | |

### Programing Paradiagm 
| Heading | Defination |
|:-------:|:---------- | 
| Procedural Programing | | 
| Object Oriented Programing | |
| Functional Programing | |

| Heading | Defination |
|:-------:|:---------- | 
| CQRS Common Query Segregation | |
| Model-View-Controller (MVC) | |
| Model-View-View-Model (MVVM) | |
| ASP .NET Core Web Form () | |
| Templating Engine | |


### Concepts
| Heading | Defination |
|:-------:|:---------- | 
| API Versioning | |
| API Caching, | |
| JWT | |
| Single Sign ON ||

| Async Programming in DotNet | |

### Design Patterns
| Heading | Defination |
|:-------:|:---------- | 
| Singleton, Doubleton, Tripleton | |
| Domain Driven Design | |
| Repository | |
| ||
| Pub Sub | |
| Factory | |
| Observer | |
| Decorator | |
| Command | |
| Adapter | |
| Facade | |
| Template Method | |

### Programming Terms
| Heading | Defination |
|:-------:|:---------- | 
| POCO, POJO | |
| Database Migrations | |
| | |


