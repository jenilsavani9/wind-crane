using System.Reflection;
using DbUp;

// Runs the versioned SQL scripts (embedded in this project) against PostgreSQL.
// Usage: dotnet run --project WindCrane.Database -- "<connection string>"
var connectionString = args.FirstOrDefault()
    ?? Environment.GetEnvironmentVariable("WINDCRANE_DB")
    ?? throw new InvalidOperationException("Pass a connection string as argument or set WINDCRANE_DB.");

EnsureDatabase.For.PostgresqlDatabase(connectionString);

var upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

var result = upgrader.PerformUpgrade();
return result.Successful ? 0 : 1;
