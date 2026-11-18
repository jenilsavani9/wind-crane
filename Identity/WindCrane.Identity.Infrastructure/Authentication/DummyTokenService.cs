using WindCrane.Identity.Application.Authentication;
using WindCrane.Identity.Domain.Users;

namespace WindCrane.Identity.Infrastructure.Authentication;

// DUMMY: not a real JWT. Will be replaced by JWT + refresh token.
internal sealed class DummyTokenService : ITokenService
{
    public string CreateToken(User user) => $"dummy-token-{user.Id}";
}
