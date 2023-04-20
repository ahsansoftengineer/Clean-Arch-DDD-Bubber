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
| Dependency Inversion (DIP)   | Dependency Inversion (DI) is a principle that states that high-level modules should not depend on low-level modules, but both should depend on abstractions. This means that instead of directly depending on concrete implementations of classes or modules, we should depend on interfaces or abstract classes that define the behavior we need. |
| Dependency Injection | Dependency Injection (DI) is a technique used to implement Dependency Inversion. It involves passing dependencies into a class or module from an external source, rather than having the class or module create them internally. This allows us to change the behavior of a class or module by changing the dependencies passed to it, without having to modify its code. |
| Keep it Simple Stupid (KISS) | KISS is an acronym that stands for "Keep It Simple, Stupid." It is a principle of software design that suggests that the simplest solution is often the best one. The KISS principle encourages developers to avoid overcomplicating things and to favor simple, straightforward designs over complex ones.  |
| IOC Container | In software development, an IOC (Inversion of Control) container is a framework or tool that automates the process of dependency injection. An IOC container manages the dependencies of various objects or components in an application, and provides them with the required dependencies when they are needed.|



## OOP 
| Heading | Defination |
|:-------:|:---------- | 
| Inheritance  | Inheritance is typically used to create a hierarchy of classes, where each child class adds new or modified behavior to the parent class. This allows developers to reuse code and avoid duplicating functionality across multiple classes. |
| Abstraction | Abstraction is a fundamental concept in object-oriented programming (OOP) that allows developers to focus on the essential features of an object, while hiding its complex implementation details. Abstraction is the process of creating a simplified representation of something, with the aim of reducing complexity and making it easier to work with. |
| Polymorphism | There are two main types of polymorphism in OOP: compile-time (or static) polymorphism and runtime (or dynamic) polymorphism. |
| Pholymorphism Compile Time / Static | Compile-time polymorphism is achieved through method overloading, which allows multiple methods with the same name to exist in a class, but with different parameters or return types.   | 
| Pholymorphism Run Time / Dynamic | Runtime polymorphism is achieved through method overriding, which allows a child class to provide its own implementation of a method that is already defined in the parent class. | 
| Encapsulation | Encapsulation is a fundamental concept in object-oriented programming (OOP) that refers to the practice of hiding the implementation details of an object from the outside world, while exposing a public interface for interacting with the object |

### Programing Paradiagm 
| Heading | Defination |
|:-------:|:---------- | 
| Procedural Programing | Procedural programming is a programming paradigm that focuses on describing a series of procedures or functions that manipulate data. Procedural programming languages are typically used to write large, complex programs, where data is organized into variables, arrays, and structures, and operations are performed through a series of functions or subroutines. | 
| Object Oriented Programing | OOP languages provide support for encapsulation, inheritance, and polymorphism, which are key concepts that help to make OOP programs more flexible, reusable, and maintainable. |
| Functional Programing | Functional programming (FP) is a programming paradigm that focuses on the use of functions to solve problems, rather than using mutable data structures and objects. In FP, functions are treated as first-class citizens, which means that they can be passed around as arguments to other functions, and can be returned as values from functions. |

| Heading | Defination |
|:-------:|:---------- | 
| CQRS Common Query Segregation | CQRS (Command Query Responsibility Segregation) is an architectural pattern that separates the read and write operations of an application into two separate models, called the command model and the query model. |
| Model-View-Controller (MVC) | MVC is often used in web applications, where the model represents the database or other data source, the view represents the HTML pages and UI elements, and the controller represents the server-side logic that handles requests and updates the view and model accordingly. |
| Model-View-View-Model (MVVM) | One of the key differences between MVVM and MVC is that MVVM uses data binding to connect the view and the ViewModel, rather than having the controller update the view directly. This allows for more flexibility and modularity in the design of the user interface, and can make it easier to write and test code. |
| ASP .NET Core Web Form () | Web Forms relies heavily on postbacks and view state to maintain the state of the application, which can make it more difficult to build scalable and maintainable applications. |
| Templating Engine | The basic idea behind a templating engine is to separate the content and the structure of a document from the logic that generates it. This allows developers to create templates that can be used to generate many different documents, without having to rewrite the content or the structure each time. |


### Concepts
| Heading | Defination |
|:-------:|:---------- | 
| API Versioning | API versioning is an important consideration for any API that is intended to be used by multiple clients over a long period of time. By carefully managing changes to the API and providing backward compatibility, developers can ensure that their API remains usable and valuable for their clients. |
| API Caching | API caching is the process of storing the results of an API request so that they can be quickly retrieved for future requests, without the need to re-execute the original request. Caching can significantly improve the performance of an API by reducing the number of requests that need to be made to the server. |
| Client Side Caching | Caching Data from Database |
| Server Side Caching | Caching Data from Server and store in Browser Cache |
| JWT | A JWT consists of three parts: a header, a payload, and a signature. The header contains information about the type of token and the algorithm used to generate the signature. The payload contains the data being transmitted, such as the user's ID and permissions. The signature is used to verify that the token has not been tampered with and that it was generated by a trusted party. |
| Single Sign On | Single Sign-On (SSO) is a method of allowing users to authenticate with multiple applications or services using a single set of login credentials. With SSO, users only need to sign in once, and they can then access all of the authorized resources without having to provide login credentials again.|

#### SSO 
1. SSO can be implemented using various technologies and protocols, such as SAML, OAuth, and OpenID Connect. In a typical SSO implementation, a user logs in to an identity provider (IdP) using their username and password. The IdP then generates a token, such as a JWT, that can be used to authenticate the user to other applications or services.
2. When the user attempts to access a protected resource on an application or service, the application or service redirects the user to the IdP for authentication. The IdP then verifies the user's identity and generates a new token that is passed back to the application or service, which uses the token to authorize the user's access.

#### API Versioning 
- There are several approaches to API versioning, including:
1. URI Versioning: api/v1/users and api/v2/users.
2. Header Versioning: Accept-Version: v1 and Accept-Version: v2.
3. Query Parameter Versioning: api/users?version=1 and api/users?version=2. 
4. Media Type Versioning: application/vnd.company.user-v1+json and application/vnd.company.user-v2+json.

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


