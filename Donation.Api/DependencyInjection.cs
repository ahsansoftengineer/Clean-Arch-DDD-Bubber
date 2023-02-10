
using Donation.Api.Common.Errors;
using Donation.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Donation.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPresentation(this IServiceCollection Services)
    {
      Services.AddControllers();
      Services.AddSwaggerGen();
      Services.AddSingleton<ProblemDetailsFactory, DonationOverrideDefaultProblemDetailsFactory>();

      Services.AddMapping();


      return Services;
    }
  }
}
