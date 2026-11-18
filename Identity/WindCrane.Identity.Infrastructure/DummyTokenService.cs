using WindCrane.Identity.Application;
using WindCrane.Identity.Domain;

namespace WindCrane.Identity.Infrastructure;

// DUMMY: not a real JWT. Will be replaced by JWT + refresh token.
internal sealed class DummyTokenService : ITokenService
{
    public string CreateToken(User user) => $"dummy-token-{user.Id}";
}
