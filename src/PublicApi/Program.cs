using Infrastructure;
using PublicApi.AuthEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Wind Crane API");
app.MapAuthEndpoints();

app.Run();
