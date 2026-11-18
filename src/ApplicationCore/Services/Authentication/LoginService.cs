using ApplicationCore.Interfaces;
using ApplicationCore.Results;

namespace ApplicationCore.Services.Authentication;

// Use case: log a user in. Knows nothing about HTTP or the database.
public sealed class LoginService(IUserRepository users, ITokenService tokens)
{
    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var user = await users.FindByUsernameAsync(request.Username, ct);

        // DUMMY password check. Real version: hashed password + authenticator code.
        if (user is null || !user.IsActive || user.PasswordHash != request.Password)
            return Result<LoginResponse>.Failure("Invalid username or password.");

        return Result<LoginResponse>.Success(new LoginResponse(tokens.CreateToken(user), user.Username, user.Role));
    }
}
