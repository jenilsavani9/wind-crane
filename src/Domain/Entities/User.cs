namespace WindCrane.Domain.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Username { get; init; }

    public required string PasswordHash { get; init; } // DUMMY: plain text for now

    public required string Role { get; init; }

    public bool IsActive { get; init; } = true;
}
