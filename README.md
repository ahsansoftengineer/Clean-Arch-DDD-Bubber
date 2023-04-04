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


