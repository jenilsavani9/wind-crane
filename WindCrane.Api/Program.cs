using WindCrane.Identity.Application;
using WindCrane.Identity.Infrastructure;
using WindCrane.Identity.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Identity module
builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Wind Crane API");
app.MapIdentityEndpoints();

app.Run();
