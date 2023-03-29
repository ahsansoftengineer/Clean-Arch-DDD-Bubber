using Microsoft.AspNetCore.Identity;
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
      services.AddAuthentication();
      services.ConfigureIdentity();

      services.ConfigureCors();

      services.AddAutoMapper(typeof(MapperInitializer));
      // Transient Means Fresh Copy
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.ConfigureSwagger();
      services
        .AddControllers()
          .AddNewtonsoftJson(opt =>
          {
            opt.SerializerSettings.ReferenceLoopHandling = 
              Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.ConfigureDevEnv(env);

      app.UseHttpsRedirection();

      app.UseCors("CorsPolicyAllowAll");

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
