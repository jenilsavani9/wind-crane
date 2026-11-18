using ApplicationCore.Entities.UserAggregate;

namespace ApplicationCore.Interfaces;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, CancellationToken ct = default);
}
