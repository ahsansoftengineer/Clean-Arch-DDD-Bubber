
using Donation.Api.Common.Errors;
using Donation.Api.Common.Mapping;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace Donation.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPresentation(this IServiceCollection Services)
    {
      Services.AddControllers();
      // Services.AddCors(option =>
      // {
      //   option.AddPolicy("AllowAll", builder =>
      //   {
      //     builder.AllowAnyOrigin()
      //     .AllowAnyMethod()
      //     .AllowAnyHeader();
      //   });
      // });

      Services.AddMySwagger();
      Services.AddSingleton<ProblemDetailsFactory, DonationOverrideDefaultProblemDetailsFactory>();

      Services.AddMapping();


      return Services;
    }

    public static IServiceCollection AddMySwagger(this IServiceCollection Services)
    {

      Services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo {
          Title = "Domain Driven Design", 
          Version = "v1.0.0" 
        });

        //c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.Http,
          //Type = SecuritySchemeType.ApiKey,
          Description = "Basic & JWT Auth",
          Scheme = "bearer", //"basic",
          BearerFormat = "JWT",
        });

        c.AddSecurityRequirement(
          new OpenApiSecurityRequirement { {
            new OpenApiSecurityScheme {
              Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer" // "basic"
              }
            },
            new string[] {"Bearer" }
          }
        });
      });

      //      services.AddAuthentication("BasicAuthentication")
      //.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
      return Services;

    }
  }
}