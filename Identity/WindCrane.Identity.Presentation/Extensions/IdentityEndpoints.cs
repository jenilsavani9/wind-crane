using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using WindCrane.Identity.Presentation.Authentication;

namespace WindCrane.Identity.Presentation;

// Single entry point for the module. Each feature has its own endpoint class.
public static class IdentityEndpoints
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/api/auth");
        LoginEndpoint.Map(auth);

        return app;
    }
}
