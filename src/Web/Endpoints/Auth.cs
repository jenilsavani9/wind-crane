using WindCrane.Application.Authentication.Commands.Login;
using WindCrane.Web.Infrastructure;

namespace WindCrane.Web.Endpoints;

public class Auth : IEndpointGroup
{
    public static string RoutePrefix => "/api/auth";

    public static void Map(RouteGroupBuilder group)
    {
        group.MapPost("/login", Login);
    }

    private static async Task<IResult> Login(LoginRequest request, LoginHandler handler, CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(request, cancellationToken);

        return result.Succeeded ? Results.Ok(result.Value) : Results.Unauthorized();
    }
}
