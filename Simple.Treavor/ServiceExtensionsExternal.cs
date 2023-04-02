﻿using Simple.Treavor.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Simple.Treavor.Infrastructure.Context;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Simple.Treavor.Domain.Model;

namespace Simple.Treavor
{
    public  static partial class ServiceExtensions
  {
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
      var builder = services
        .AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);

      builder = new IdentityBuilder(
        builder.UserType, 
        typeof(IdentityRole), services);

      builder
        .AddEntityFrameworkStores<DatabaseContext>()
          .AddDefaultTokenProviders();
      return services;
    }
   
    public static IServiceCollection ConfigureVersioning(this IServiceCollection services)
    {
      services.AddApiVersioning(opt =>
      {
        opt.ReportApiVersions = true;
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
      });
      return services;
    }
    public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(error =>
      {
        error.Run(async context =>
        {
          context.Response.StatusCode = StatusCodes.Status500InternalServerError;
          context.Response.ContentType = "application/json";
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

          if (contextFeature != null)
          {

            Log.Error($"Something Went Wrong in the {contextFeature.Error}");

            await context.Response.WriteAsync(new Error
            {
              StatusCode = context.Response.StatusCode,
              Message = "Internal Server Error. Please Try Again Later."
            }.ToString());
          }
        });
      });


      return app;
    }

  }

}