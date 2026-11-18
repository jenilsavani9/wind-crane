using WindCrane.Identity.Domain.Users;

namespace WindCrane.Identity.Application.Authentication;

public interface ITokenService
{
    string CreateToken(User user);
}
