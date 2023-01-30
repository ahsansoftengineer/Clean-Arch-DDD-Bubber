using Donation.Application;
using Donation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
  builder.Services.AddControllers();
  builder.Services.AddSwaggerGen();
}

var app = builder.Build();

{

  app.UseHttpsRedirection();
  app.MapControllers();
  if (app.Environment.IsDevelopment())
  {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
  }
    

  app.Run();
}

