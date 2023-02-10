using Donation.Api;
using Donation.Application;
using Donation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services
    .AddPresentation() // Api Layer
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

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

