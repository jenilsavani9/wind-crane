using Microsoft.Extensions.DependencyInjection;

namespace WindCrane.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
        => services.AddScoped<LoginHandler>();
}
