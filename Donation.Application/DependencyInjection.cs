using Donation.Application.Services.Authentication.Command;
using Donation.Application.Services.Authentication.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Donation.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection Services)
        {
            Services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            Services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return Services;
        }
    }
}
