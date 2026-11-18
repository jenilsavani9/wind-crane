using WindCrane.Domain.Entities;

namespace WindCrane.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default);
}
