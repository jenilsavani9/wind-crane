using WindCrane.Identity.Domain;

namespace WindCrane.Identity.Application;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, CancellationToken ct = default);
}
