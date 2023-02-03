using System.Net;
using System.Text.Json;

namespace Donation.Api.Middleware
{
  public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      var code = HttpStatusCode.InternalServerError; // 500 if unexpected
      var result = JsonSerializer.Serialize(new
      {
        error = "Middleware Processing Exception : " + ex.Message,
        //error = ex.Message
      });

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      return context.Response.WriteAsync(result);
    }
  }
}
