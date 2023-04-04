## API Caching

### What API Caching
1. ASP.NET Core APIs can benefit from caching and throttling to improve performance and manage resources.
2. Caching involves storing frequently accessed data in memory or a cache store, which reduces the need to repeatedly fetch data from the database or external services. ASP.NET Core provides built-in support for caching through the IMemoryCache interface, which can be used to cache data for a specified duration.
3. To use caching in your API, you can inject an instance of IMemoryCache into your controller or service and use its GetOrCreate method to retrieve the cached data or add it if it doesn't exist.

### What is API Throttling
1. How often a user can hit our API Within a specific time duration
2. It Help Preventing from API Bombarding and shutting down the server

### What is Marvin.Cache.Headers?
1. By using Marvin.Cache.Headers, you can add powerful caching features to your ASP.NET Core API with minimal effort, reducing server load and improving performance for your users.
2. Marvin Cache has following Attributes
```csharp
[HttpGet]
// attribute specifies that the response should be cached for 10 minutes (MaxAge = 600) and stored privately (CacheLocation = CacheLocation.Private).
[HttpCacheExpiration(CacheLocation = CacheLocation.Private, MaxAge = 600)]
// attribute specifies that ETag validation should use strong matching (ETagMatch = ETagMatch.Strong).
[HttpCacheValidation(ETagMatch = ETagMatch.Strong)]
// Purpose Don't know
[HttpCacheNoStore]
```

### What are the types of API Caching

#### How to Setup API Caching


#### Headers & Docs of API Caching
```json
 api-supported-versions: 1.0 
 cache-control: private,max-age=65,must-revalidate 
 content-length: 880 
 content-type: application/json; charset=utf-8 
 date: Sun,02 Apr 2023 11:17:40 GMT 
 etag: "6E53B5721F36A61166F881FB455D691F" 
 expires: Sun,02 Apr 2023 11:18:46 GMT 
 last-modified: Sun,02 Apr 2023 11:17:41 GMT 
 server: Kestrel 
 vary: Accept,Accept-Language,Accept-Encoding 
```
