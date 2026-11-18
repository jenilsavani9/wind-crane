using ApplicationCore.Constants;
using ApplicationCore.Entities.UserAggregate;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;

// DUMMY: in-memory users. Will be replaced by a Dapper + PostgreSQL repository.
internal sealed class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> Users =
    [
        new() { Username = "admin",  PasswordHash = "admin123",  Role = RoleNames.SuperAdmin },
        new() { Username = "driver", PasswordHash = "driver123", Role = RoleNames.Driver }
    ];

    public Task<User?> FindByUsernameAsync(string username, CancellationToken ct = default)
        => Task.FromResult(Users.FirstOrDefault(u => u.Username == username));
}
