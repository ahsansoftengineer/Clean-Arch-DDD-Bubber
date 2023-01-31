using Donation.Api.Filter;
using Donation.Api.Middleware;
using Donation.Application;
using Donation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
  builder.Services.AddControllers();
  builder.Services.AddSwaggerGen();

  builder.Services.AddControllers(options =>
  {
    options.Filters.Add<ErrorHandlingFilterAttribute>();
  });
}

var app = builder.Build();

{
  // To Use this we have to Comment Developer Exception Page
  //app.UseMiddleware<ErrorHandlingMiddleware>();

  app.UseHttpsRedirection();
  app.MapControllers();

  if (app.Environment.IsDevelopment())
  {
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.Run();
}

