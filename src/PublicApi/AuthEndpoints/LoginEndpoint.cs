using ApplicationCore.Services.Authentication;

namespace PublicApi.AuthEndpoints;

internal static class LoginEndpoint
{
    public static void Map(RouteGroupBuilder group) =>
        group.MapPost("/login", async (LoginRequest request, LoginService service, CancellationToken ct) =>
        {
            var result = await service.LoginAsync(request, ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.Unauthorized();
        });
}
