using WindCrane.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.UseHttpsRedirection();

// Serves the built Angular app (ClientApp) from wwwroot.
app.UseFileServer();

app.MapEndpoints(typeof(Program).Assembly);

app.MapFallbackToFile("index.html");

app.Run();
