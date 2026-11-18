using ApplicationCore.Interfaces;
using ApplicationCore.Services.Authentication;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

// Registers repositories, technical services and the use-case services.
public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<ITokenService, DummyTokenService>();
        services.AddScoped<LoginService>();
        return services;
    }
}
