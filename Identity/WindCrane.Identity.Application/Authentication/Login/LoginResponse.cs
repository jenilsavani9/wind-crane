namespace WindCrane.Identity.Application.Authentication.Login;

public sealed record LoginResponse(string Token, string Username, string Role);
