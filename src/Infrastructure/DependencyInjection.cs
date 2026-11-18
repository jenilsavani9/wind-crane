using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        // Register Dapper repositories, authentication and other technical services here.
        builder.Services.AddSingleton(TimeProvider.System);
    }
}
