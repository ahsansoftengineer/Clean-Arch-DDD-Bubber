// See https://aka.ms/new-console-template for more information
using Donation.PlayGround;
using Mapster;

Console.WriteLine("Hello, World!");
// - There are three types of Mapping
// 1. Default Mapping (Map the Matching Properties)
// 2. Global Mapping (Apply to all Mapping with specific rule all other place)
// 3. Destination Mapping (

// What is the Mapping Behavior
// Generally its looks for Definition for the type how to map it
// Then its fall back to default
// Then it fall back to Destination Type


var user = new User(101, "Ahsan", "Saifi");
Console.WriteLine(user);

// Example 1 
//var userResponse = user.Adapt<UserResponse>();


// Example 2 (Other & Include Same) Property Mapping 
// Other Matched Property will Mapped Automatically
//var config = new TypeAdapterConfig();
//config.NewConfig<User, UserResponse>()
//  .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
//var userResponse = user.Adapt<UserResponse>(config);

// Example 3 (Other & Exclude Same) Property Mapping 
// Other Matched Property will not Mapped Automatically
//var config = new TypeAdapterConfig();
//config.NewConfig<User, UserResponse>()
//  .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
//  .IgnoreNonMapped(true);
//var userResponse = user.Adapt<UserResponse>(config);

// Example 4 Global Mapping Settings
//var config = TypeAdapterConfig.GlobalSettings;
//config.NewConfig<User, UserResponse>()
//  .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
//var userResponse = user.Adapt<UserResponse>(); // no config pass

// Example 5 Conditional Global Mapping
//var config = TypeAdapterConfig.GlobalSettings;
//config.NewConfig<User, UserResponse>()
//  .Map(
//    dest => dest.FullName, 
//      src => $"{src.FirstName} {src.LastName}",
//      src => src.FirstName.StartsWith("a", StringComparison.OrdinalIgnoreCase)
//   );
//var userResponse = user.Adapt<UserResponse>(); // no config pass

// Example 6 Mapping Two Objects to Single Object
//var config = TypeAdapterConfig.GlobalSettings;
//var TraceId = Guid.NewGuid();
//TypeAdapterConfig<(User User, Guid TraceId), UserResponse>.NewConfig()
//  .Map(dest => dest, src => src.User)
//  .Map(
//    dest => dest.FullName,
//      src => $"{src.User.FirstName} {src.User.LastName}"
//   )
//  .Map(
//   dest => dest.TraceId,
//      src => src.TraceId
//  )
//  .AfterMapping(dest => Console.WriteLine(dest));
//var userResponse = (user, TraceId).Adapt<UserResponse>(); // no config pass

// Example 7 Mapping & Validation
var config = TypeAdapterConfig.GlobalSettings;
TypeAdapterConfig<User, UserResponse>.NewConfig()
  .Map(
    dest => dest.FullName,
      src => $"{src.FirstName} {src.LastName}"
   )
  .Map(dest => dest.TraceId, src => Guid.NewGuid())
  .MapToConstructor(true);

config.ForDestinationType<IValidatable>()
  .AfterMapping(dest => dest.Validate());


var userResponse = user.Adapt<UserResponse>();

Console.WriteLine(userResponse);

