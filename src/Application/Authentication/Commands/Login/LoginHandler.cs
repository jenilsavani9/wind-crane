using WindCrane.Application.Common.Interfaces;
using WindCrane.Application.Common.Models;

namespace WindCrane.Application.Authentication.Commands.Login;

// Use case: log a user in. Knows nothing about HTTP or the database.
public sealed class LoginHandler(IUserRepository users, ITokenService tokens)
{
    public async Task<Result<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await users.FindByUsernameAsync(request.Username, cancellationToken);

        // DUMMY password check. Real version: hashed password + authenticator code.
        if (user is null || !user.IsActive || user.PasswordHash != request.Password)
        {
            return Result<LoginResponse>.Failure("Invalid username or password.");
        }

        return Result<LoginResponse>.Success(new LoginResponse(tokens.CreateToken(user), user.Username, user.Role));
    }
}
