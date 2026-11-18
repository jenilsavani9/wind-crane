# Wind Crane

Port transport crane installation logistics platform. Modular monolith on .NET 10, PostgreSQL, Dapper, Clean Architecture.
Folder layout follows the eShopOnWeb reference project.

```
src/
  ApplicationCore/   business core, no dependencies
    Constants/  Entities/<Name>Aggregate/  Exceptions/  Extensions/  Interfaces/  Services/<Feature>/  Results/
  Infrastructure/    technical details (references ApplicationCore)
    Data/  Identity/  Logging/  Services/  Dependencies.cs
  PublicApi/         HTTP endpoints, one folder per resource (references ApplicationCore, Infrastructure)
    AuthEndpoints/  Middleware/  Program.cs
  Database/          DbUp runner; versioned SQL scripts in Scripts/<Module>/
docs/                architecture decisions
Directory.Packages.props   one place for NuGet package versions
global.json                pins the .NET SDK
```

## Run

```bash
dotnet build WindCrane.slnx
dotnet run --project src/PublicApi
# POST /api/auth/login  {"username":"admin","password":"admin123"}
```

Database scripts:

```bash
dotnet run --project src/Database -- "Host=localhost;Database=windcrane;Username=postgres;Password=..."
```

Authentication is a placeholder (in-memory users, fake token). Testing is manual; database changes are SQL scripts only.

## Adding a new route

1. `ApplicationCore/Services/<Feature>/` : request, response and the service with the logic.
2. `PublicApi/<Resource>Endpoints/` : one endpoint class, plus one line in that folder's registration class.
3. If it needs data: add the method to an interface in `ApplicationCore/Interfaces/`, its SQL in `Infrastructure/Data/`, and a script in `src/Database/Scripts/`.
4. Register any new service in `Infrastructure/Dependencies.cs`.
