using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple.Treavor.Domain.Configurations;
using Simple.Treavor.Infrastructure.Context;
using Simple.Treavor.Infrastructure.IRepo;
using Simple.Treavor.Infrastructure.Repo;

namespace Simple.Treavor
{
    public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
      //services.AddTransient<SignInManager<ApiUser>, SignInManager<ApiUser>>();

      // API Caching 6: Adding Services Extensions
      services.ConfigureHttpCacheHeaders();

      services.AddAuthentication();
      services.ConfigureIdentity();

      services.ConfigureCors();

      services.AddAutoMapper(typeof(MapperInitializer));
      // Transient Means Fresh Copy
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.ConfigureSwagger();
      services
         // API Caching 3. Defining Cache Profile
        .AddControllers(config =>
        {
          config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
          {
            Duration = 120
            //,Location = ResponseCacheLocation.Client
            //,NoStore = true
            //,VaryByHeader = "I don't know which string"
            //,VaryByQueryKeys = "Any Keys"
          });
        })
        .AddNewtonsoftJson(opt =>
        {
          opt.SerializerSettings.ReferenceLoopHandling = 
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

      services.ConfigureVersioning(); 
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.ConfigureDevEnv(env);
      app.ConfigureExceptionHandler();
      app.UseHttpsRedirection();

      app.UseCors("CorsPolicyAllowAll");

      // API Caching 2. Setting up Caching
      app.UseResponseCaching();
      // API Caching 7. Setting up Caching Profile at Globally
      app.UseHttpCacheHeaders();

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(ep =>
      {
        // This Routing is useful for MVC type application
        // Convention Based Routing Schema
        //ep.MapControllerRoute(
        //  name: "default",
        //  pattern: "{controller=Home}/{action=Index}/{id?}"
        //  );
        ep.MapControllers();
      });
    }


  }
}
