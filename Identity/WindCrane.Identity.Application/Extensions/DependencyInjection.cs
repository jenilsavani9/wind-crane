using Microsoft.Extensions.DependencyInjection;
using WindCrane.Identity.Application.Authentication.Login;

namespace WindCrane.Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
        => services.AddScoped<LoginHandler>();
}
