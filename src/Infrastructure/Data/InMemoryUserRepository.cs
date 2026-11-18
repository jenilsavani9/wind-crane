using WindCrane.Application.Common.Interfaces;
using WindCrane.Domain.Constants;
using WindCrane.Domain.Entities;

namespace WindCrane.Infrastructure.Data;

// DUMMY: in-memory users. Will be replaced by a Dapper + PostgreSQL repository.
internal sealed class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> Users =
    [
        new() { Username = "admin", PasswordHash = "admin123", Role = Roles.SuperAdmin },
        new() { Username = "driver", PasswordHash = "driver123", Role = Roles.Driver }
    ];

    public Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => Task.FromResult(Users.FirstOrDefault(u => u.Username == username));
}
