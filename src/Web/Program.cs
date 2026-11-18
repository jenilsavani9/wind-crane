var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

// Serves the built Angular app (ClientApp) from wwwroot.
app.UseFileServer();
app.MapFallbackToFile("index.html");

app.Run();
