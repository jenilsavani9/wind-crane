using WindCrane.Identity.Domain.Users;

namespace WindCrane.Identity.Application.Users;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, CancellationToken ct = default);
}
