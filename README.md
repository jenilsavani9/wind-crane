# Wind Crane

Port transport crane installation logistics platform.
Modular monolith on .NET 10 and PostgreSQL, Clean Architecture.
Folder layout comes from the Clean Architecture Solution Template (`dotnet new ca-sln -cf angular -db postgresql`, v10.9.0),
trimmed to boilerplate only.

```
src/
  Domain/           entities, value objects, domain events, constants (no dependencies)
    Common/  Constants/  Entities/  Enums/  Events/  Exceptions/  ValueObjects/
  Application/      use cases (MediatR commands/queries), pipeline behaviours, interfaces
    Common/Behaviours  Common/Exceptions  Common/Interfaces  Common/Models  Common/Security
  Infrastructure/   technical details: Dapper data access, identity, external services
    Data/  Identity/
  Web/              HTTP API (minimal API endpoint groups), OpenAPI/Scalar, health check
    Endpoints/  Infrastructure/  Services/
  Database/         DbUp runner; versioned SQL scripts in Scripts/<Module>/
docs/adr/           architecture decisions
Directory.Build.props      shared build settings
Directory.Packages.props   one place for NuGet package versions
global.json                pins the .NET SDK
```

Dependencies point inward: Web and Infrastructure -> Application -> Domain.

## Run

```bash
dotnet build WindCrane.slnx
dotnet run --project src/Web
# GET /health   /openapi/v1.json   /scalar/v1
```

Database scripts:

```bash
dotnet run --project src/Database -- "Host=localhost;Database=windcrane;Username=postgres;Password=..."
```

## What was removed from the template

Sample Todo and Weather features, EF Core and its migrations, ASP.NET Identity EF stores, .NET Aspire (AppHost, ServiceDefaults),
all test projects, the Angular client, Azure Key Vault and the template's own docs.
Testing is manual; database changes are SQL scripts only.

## Adding a feature

1. `Application/<Feature>/Commands|Queries/<Name>/` : request, handler, validator.
2. `Web/Endpoints/<Feature>.cs` : a class implementing `IEndpointGroup`; it is discovered automatically.
3. Data access: interface in `Application/Common/Interfaces`, Dapper implementation in `Infrastructure/Data`, register it in `Infrastructure/DependencyInjection.cs`.
4. Schema change: a new SQL script in `src/Database/Scripts/<Module>/`.
