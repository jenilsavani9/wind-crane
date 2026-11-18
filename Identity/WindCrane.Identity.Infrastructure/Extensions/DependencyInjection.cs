using Microsoft.Extensions.DependencyInjection;
using WindCrane.Identity.Application.Authentication;
using WindCrane.Identity.Application.Users;
using WindCrane.Identity.Infrastructure.Authentication;
using WindCrane.Identity.Infrastructure.Users;

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
