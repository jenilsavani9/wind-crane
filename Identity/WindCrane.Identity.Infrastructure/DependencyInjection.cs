using Microsoft.Extensions.DependencyInjection;
using WindCrane.Identity.Application;

namespace WindCrane.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<ITokenService, DummyTokenService>();
        return services;
    }
}
