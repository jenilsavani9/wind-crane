using ApplicationCore.Entities.UserAggregate;

namespace ApplicationCore.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
