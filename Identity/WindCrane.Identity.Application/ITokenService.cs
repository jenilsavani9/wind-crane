using WindCrane.Identity.Domain;

namespace WindCrane.Identity.Application;

public interface ITokenService
{
    string CreateToken(User user);
}
