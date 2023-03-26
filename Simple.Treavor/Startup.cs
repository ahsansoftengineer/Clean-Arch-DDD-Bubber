using Microsoft.EntityFrameworkCore;
using Simple.Treavor.Domain.Configurations;
using Simple.Treavor.Infrastructure.Data;
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
     
      services.AddCors(option =>
      {
        option
          .AddPolicy("CorsPolicyAllowAll", builder =>
            builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
        );
      });

      services.AddAutoMapper(typeof(MapperInitializer));
      // Transient Means Fresh Copy
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
          Title = "Trevor Simple",
          Version = "v1"
        });
      });
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
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trevor v1"));
      }

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
