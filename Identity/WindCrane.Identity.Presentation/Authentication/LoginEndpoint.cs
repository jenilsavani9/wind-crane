using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using WindCrane.Identity.Application.Authentication.Login;

namespace WindCrane.Identity.Presentation.Authentication;

internal static class LoginEndpoint
{
    public static void Map(RouteGroupBuilder group) =>
        group.MapPost("/login", async (LoginRequest request, LoginHandler handler, CancellationToken ct) =>
        {
            var result = await handler.HandleAsync(request, ct);
            return result.IsSuccess ? Results.Ok(result.Value) : Results.Unauthorized();
        });
}
