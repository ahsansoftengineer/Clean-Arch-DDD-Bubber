﻿using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Donation.Application.Common.Interfaces.Authentication;
using Donation.Application.Common.Services;
using Donation.Application.Common.Persistence;
using Donation.Infrastructure.Authentication;
using Donation.Infrastructure.Services;
using Donation.Infrastructure.Persistence;
using Donation.Infrastructure.Persistence.Repositories;
using Donation.Application.Common.Persistence.Hierarchy;
using Donation.Infrastructure.Persistence.Repositories.Hierarchy;

namespace Donation.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection Services, ConfigurationManager Configuration)
    {
      Services
        .AddAuth(Configuration)
        .AddPersistence();
      Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

      return Services;
    }
    public static IServiceCollection AddPersistence(this IServiceCollection Services)
    {
      Services.AddDbContext<DonationDbContext>(options =>
      {
        // TrustServerCertificate=true | Encrypt=false
        options.UseSqlServer("SERVER=localhost;DATABASE=Donation;USER=sa;PASSWORD=Asdf@1234;Encrypt=false");
      });
      Services.AddScoped<IUserRepository, UserRepository>();
      Services.AddScoped<IMenuRepository, MenuRepository>();

      Services.AddScoped<IOrgRepo, OrgRepo>();
      Services.AddScoped<ISystemzRepo, SystemzRepo>();
      Services.AddScoped<IBGRepo, BGRepo>();
      Services.AddScoped<ILERepo, LERepo>();
      Services.AddScoped<IOURepo, OURepo>();
      Services.AddScoped<ISURepo, SURepo>();

      return Services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection Services, ConfigurationManager Configuration)
    {
      var jwtSettings = new JwtSettings();
      Configuration.Bind(JwtSettings.SectionName, jwtSettings);

      //Services.Configure<JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
      //Configuration[JwtSettings.Issuer] to access with above code

      // shorthand syntax for accessing configuration
      Services.AddSingleton(Options.Create(jwtSettings));

      // 1. Interface are Coming From Application Layer
      // 2. Classes Coming From Infrastructure
      Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
      Services
        .AddAuthentication(options =>
        {
          //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          //options.SaveToken = true;
          //options.RequireHttpsMetadata = false;
          options.TokenValidationParameters = new TokenValidationParameters()
          {
            // Here we are saying what to Validate Issuer & Audience
            //ValidateIssuer = true,
            //ValidateAudience = true,
            //ValidateLifetime = true,

            // Here we are telling what is Issuer & Audience
            //ValidIssuer = jwtSettings.Issuer,
            //ValidAudience = jwtSettings.Audience,

            // To Help other component how to validate the signature of the Token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),

            // Swagger Causing Problem with it for time being we have to set Issuer & Audience like so
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = "https://localhost:7228",
            ValidIssuer = "https://localhost:7228",

          };
        });
      return Services;
    }


  }
}
