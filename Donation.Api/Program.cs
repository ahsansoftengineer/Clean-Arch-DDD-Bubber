using Donation.Api.Common.Errors;
using Donation.Application;
using Donation.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

  builder.Services.AddControllers();
  builder.Services.AddSwaggerGen();
  builder.Services.AddSingleton<ProblemDetailsFactory, DonationOverrideDefaultProblemDetailsFactory>();

  builder.Services.AddControllers();
}

var app = builder.Build();

{
  app.UseHttpsRedirection();
  app.MapControllers();

  if (app.Environment.IsDevelopment())
  {
    // Developer Exception Page
    // and Swagger not Work with Exception Filters
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
  }
  app.UseExceptionHandler("/error");


  app.Run();
}

