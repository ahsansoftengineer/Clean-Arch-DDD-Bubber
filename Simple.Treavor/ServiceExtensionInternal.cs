namespace Simple.Treavor
{
  public static partial class ServiceExtension
  {
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
          Title = "Trevor Simple",
          Version = "v1"
        });
      });
      return services;
    }
    public static IApplicationBuilder ConfigureDevEnv(this IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trevor v1"));
      }
      return app;
    }
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
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
      return services;
    }
  }
}
