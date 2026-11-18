using WindCrane.Domain.Entities;

namespace WindCrane.Application.Common.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
