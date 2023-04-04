| Heading | Defination |
|:-------:|------------|
| Language Support | C++, C#, F#, Visual Basic
| Mono |  Mono is also an extension of the .NET framework, but this has been optimized by Xamarin, for Android, Windows, iOS, and macOS. The base library for .NET Core is CoreFX Class Library, and for Mono is Mono Class Library.
| CTS | All programming languages have their own data type, and these cannot be understood by other languages. But CTS enables the .NET framework to understand all data types.
| Kestrel | Kestrel is a cross-platform web server that is enabled by default in ASP.NET Core project templates. It supports- HTTPS, HTTP/2, opaque upgrade (to enable WebSockets), and Unix sockets. It is supported on all versions and platforms of .NET Core.
| CoreFX | CoreFx is the term used to refer to the foundational/ introductory class libraries for the .NET Core.CoreFX consists of collection types, class types, consoles, XML, and JSON for class library implementations. This results in platform-neutral code which can be used as a single portable assembly.
| Garbage Collection On Going Process | Low physical memory, Threshold, Rare Testing Situations
| MSIL | MSIL stands for Microsoft Intermediate Language. Whenever we compile .NET codes, it is first converted to MSIL code, which then CLR interprets. The MSIL code is hardware and operating system independent.
| SDK VS .Net Core | The major difference between .NET Core SDK and .NET Core Runtime is that the former is functional in the building/ development of applications, while the latter is a virtual machine responsible for the application execution and running.
| Core SDK | The set of tools and libraries used in the development process is referred to as SDK. They help developers in creating .NET Core libraries and applications.


19. What is the hosting environment?
- The hosting environment contains application-specific details such as application functions, where it is stored, services for app management, etc. A HostingEnvironment is created in the ApplicationDomain, before the ASP's creation. In other words, a hosting environment is responsible for application management and app-specific functions.
- This feature of .NET Core makes it possible for the developer to work with multiple environments, without creating any friction.

20. Give a brief about Garbage Collection
- Garbage collection is one of the most important features of high-level programming languages and frameworks. The feature is carried on by a garbage collector which automates the process of memory allocation and management.
- There are three generations in the memory heap- zero (for short-lived objects), one (for medium-lived objects), and two (long-lived objects). The collection of garbage then refers to the collection of all the objects in different generations, that are no longer in use. The collector frees memory space by collecting these objects thus functioning as an automatic memory manager.
- Garbage collection occurs in three situations- one when the physical memory is low, when the acceptable threshold is exceeded, or when the GC method is called on. The major benefits of this are that developers don't need to manually free up what memory space, or worry about efficient allocation of objects on the managed heap, and it ensures security/ safety by blocking one object from using the content of another object.

26. What is Explicit Compilation (Ahead of time)?
- Explicit compilation refers to the process of converting upper-level language into project code before interaction or project execution. This is why explicit compilation is also referred to as ahead-of-time (AOT) compilation, as in, before interaction between the CPU and program.

27. Mention a few benefits of AOT
Some benefits of AOT are:
- It leads to a smaller application size (exclusive of the angular compiler)
- Component rendering becomes quicker
- The template parse errors are detected early at the build time
- The program is more secure since there is no need to dynamically evaluate templates

28. Explain Docker in .NET Core
- Docker is a service container that is used to develop and publish applications. Application developers can package their applications in docker containers which can then easily be managed with git and can be synchronized across machines. These containers are lightweight and include everything needed to run the respective application without dependencies.

29. What is the IGCToCLR interface?
- The IGCToCLR interface is used to communicate with the runtime environment. It passes an argument to the InitializeGarbageCollector function.

21. Mention the main architectural components of .NET Core
- There are 3 main architectural components:
- .NET Core Runtime- The main purpose is to ensure the smooth functioning of the app/ program by providing type safety, native interop services, assemblies, garbage collection, etc.
- Framework Libraries- These include base libraries with components like app composition types and other fundamental utilities.
- SDK compilers (Roslyn) and command line tools- These facilitate quick development of programs/ applications on .NET Core

43. What is the purpose of the IDisposable interface?
IDisposable interface is defined in the System namespace and it contains a single method- Dispose(). The purpose of this method is to release unmanaged resources from the application or class library. Some of these unmanaged resources might include database connections, fonts, streams, files, etc.

44. What is the difference between 'managed' and 'unmanaged' code?
The primary difference between the 'managed' and 'unmanaged' code is that for the former, the CLR in the .NET framework manages the code, while in the latter the operating system directly executes the code. Also, the 'managed' code adds a layer of security to the application not present in the case of 'unmanaged' code.

45. Is the 'debug' class the same as the 'trace' class?
They aren't the same thing. Debugging refers to the process of finding errors in a code. While tracing refers to the process of charting out the execution pathway of a code, or getting other execution information. The trace class is broader in comparison as it can be used for both releasing builds as well as debugging the code.

46. What is MEF in .NET Core?
MEF stands for Managed Extensibility Framework and it is a library used for developing lightweight extensible applications. With the MEF, developers can discover extensions and use them without the need for configuration. Many believe that MEF is no longer available in .NET Core, however, it has been ported to the .NET Core as the System.Composition.

47. What are UWP Apps in .Net Core?
UWP stands for Universal Windows Platform and it is one of the numerous ways of client application creation for Windows. The WinRT APIs used in these apps result in powerful UIs and advanced asynchronous features. The common features of these apps are that they are secure, use a common API, and can install and uninstall the apps without risking 'machine rot'.

48. What is MSBuild?
Microsoft Build Engine (MSBuild) is a VS and Microsoft open-source platform for building applications. It helps in the automation of the software creation process including code compilation, testing, packaging, documentation, and deployment.

49. What is CoreRT?
The CoreRTis the .NET Core toolset that is responsible for compilation to translation processes. It uses the ahead-of-compiler RyuJIT to compile CIL byte core to machine code.

50. Explain response caching
Response caching is when the .NET Core MVC's HTTP responses are pre-specified in cache-related headers. These headers describe how intermediate or client machines should cache responses to requests. This hence reduces the volume of requests the client or proxy machine makes to the web server.

51. This brings us to the end of the list of top 50 dot NET core interview questions and answers that will help you ace your developer interview with ease. Check out the articles listed below to know more about some other interesting topics and some other QA banks.

35.  What's the difference between RyuJIT and Roslyn?
Roslyn is a .NET Core compiler that compiles VB or C# code to the intermediate language (IL). Whereas, RyuJIT as the name suggests is a Just-In-Time compiler that works the other way around i.e. compiles the IL to native code.

22. What is meant by Razor Pages?
- Razor Pages is a comparatively newer and more simplified web app development/ programming model. The Razor Pages follow a file-based routing approach thus simplifying the "Model-View-Controller" architectural model of ASP.NET. The code and the HTML are both in a single file which eliminates the need for separate view models, controllers, action methods, etc.
