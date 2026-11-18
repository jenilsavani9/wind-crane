namespace ApplicationCore.Services.Authentication;

public sealed record LoginResponse(string Token, string Username, string Role);
