namespace PublicApi.AuthEndpoints;

// Registers every /api/auth route. Each route is its own class.
public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth");
        LoginEndpoint.Map(group);
        return app;
    }
}
