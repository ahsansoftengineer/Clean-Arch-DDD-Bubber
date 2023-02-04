using Donation.Api.Errors;
using Donation.Application;
using Donation.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
      .AddApplication()
      .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    //builder.Services.AddSingleton<ProblemDetailsFactory, DonationOverrideDefaultProblemDetailsFactory>();
    //builder.Services.AddSwaggerGen();

    builder.Services.AddControllers(options =>
    {
        // 1. Exception Filter Attribute
        //options.Filters.Add<ErrorHandlingFilterAttribute>();
    });
}

var app = builder.Build();

{

    // 2. Exception Middleware
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // 3. Exception Route
    app.UseExceptionHandler("/error");

    // 4.Minimal Api Approach this is not usefull
    //app.Map("/error", (HttpContext context) =>
    //{
    //  var code = HttpStatusCode.InternalServerError; // 500 if unexpected
    //  var result = JsonSerializer.Serialize(new
    //  {

    //    error = "Minimal API Processing Exception : " + "Any Message of my Choice",
    //    //error = ex.Message
    //  });

    //  context.Response.ContentType = "application/json";
    //  context.Response.StatusCode = (int)code;
    //  return context.Response.WriteAsync(result);
    //});

    app.UseHttpsRedirection();
    app.MapControllers();

    if (app.Environment.IsDevelopment())
    {
        // Developer Exception Page
        // and Swagger not Work with Exception Filters
        //app.UseDeveloperExceptionPage();
        //app.UseSwagger();
        //app.UseSwaggerUI();
    }

    app.Run();
}

