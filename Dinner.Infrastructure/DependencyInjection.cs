using Dinner.Application.Common.Interfaces.Services;
using Dinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Infrastructure.Services;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Infrastructure.Persistence;
namespace Dinner.Infrastructure.Authentication;
//extension method for IServiceCollection to make sepaartion of concerns in each layer that is ,,dependency injection is added in every layer
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;

    }


}
