using WindCrane.Application.Common.Interfaces;
using WindCrane.Infrastructure.Data;
using WindCrane.Infrastructure.Identity;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<ITokenService, DummyTokenService>();

        return services;
    }
}
