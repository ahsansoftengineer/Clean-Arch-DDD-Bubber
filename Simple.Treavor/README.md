### Programing Concept

#### Exchanging Data
1. DTOs Talk to DTOs 
2. Domain Object Talks to Domain Objects
3. Working Started on CRUD

#### Api Version
1. When you have Two Controller with the Same Route and Endpoints
2. Api Version is just like Marking Methods, Classes Deprecated and suggesting using new one.

#### Api Caching
1. ASP.NET Core APIs can benefit from caching and throttling to improve performance and manage resources.

2. Caching involves storing frequently accessed data in memory or a cache store, which reduces the need to repeatedly fetch data from the database or external services. ASP.NET Core provides built-in support for caching through the IMemoryCache interface, which can be used to cache data for a specified duration.

3. To use caching in your API, you can inject an instance of IMemoryCache into your controller or service and use its GetOrCreate method to retrieve the cached data or add it if it doesn't exist.

#### Marvin Cache
1. Marvin.Cache.Headers is a library for ASP.NET Core that provides additional caching features such as ETag and Last-Modified headers to improve performance and reduce unnecessary data transfers.

2. The library works by intercepting HTTP responses and adding cache-related headers to them. This allows clients to cache the response and avoid requesting the same data again if it hasn't changed.

3. To use Marvin.Cache.Headers, you need to install the Marvin.Cache.Headers package using NuGet:

