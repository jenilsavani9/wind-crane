using ApplicationCore.Entities.UserAggregate;
using ApplicationCore.Interfaces;

namespace Infrastructure.Identity;

// DUMMY: not a real JWT. Will be replaced by JWT + refresh token.
internal sealed class DummyTokenService : ITokenService
{
    public string CreateToken(User user) => $"dummy-token-{user.Id}";
}
