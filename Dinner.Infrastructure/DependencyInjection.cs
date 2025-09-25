using Dinner.Application.Common.Interfaces.Services;

using Dinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Infrastructure.Services;//for datetime provide
namespace Dinner.Infrastructure.Authentication;
//extension method for IServiceCollection to make sepaartion of concerns in each layer
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;

    }


}
