using WindCrane.Application.Common.Interfaces;
using WindCrane.Domain.Entities;

namespace WindCrane.Infrastructure.Identity;

// DUMMY: not a real JWT. Will be replaced by JWT + refresh token.
internal sealed class DummyTokenService : ITokenService
{
    public string CreateToken(User user) => $"dummy-token-{user.Id}";
}
