# Wind Crane

Port transport crane installation logistics platform. Modular monolith on .NET, PostgreSQL, Dapper, Clean Architecture.

- `WindCrane.Api/`          host: startup, auth setup, SignalR, Hangfire
- `WindCrane.Shared/` base classes and shared types (no business logic)
- `WindCrane.Database/`     DbUp runner project; versioned SQL scripts per module in `Scripts/<Module>/`
- `Identity/`               first module: Domain, Application, Infrastructure, Presentation
- `docs/`                   architecture decisions

Each new module is a folder at the root with the same four projects as `Identity/`.
Database changes are SQL scripts only (no migrations). Testing is manual.

## Run (dummy authentication)

```bash
dotnet build WindCrane.slnx
dotnet run --project WindCrane.Api
# POST /api/auth/login  {"username":"admin","password":"admin123"}
```

Run database scripts:

```bash
dotnet run --project WindCrane.Database -- "Host=localhost;Database=windcrane;Username=postgres;Password=..."
```

Authentication is a placeholder: in-memory users and a fake token. Real login (Dapper stores, password hashing, authenticator code, JWT) comes next.

## Folder rule inside every project

Group files by object or feature (`Users/`, `Authentication/Login/`, `Roles/`), never by technical type in one flat folder.
`Extensions/` holds the module's wiring code (dependency injection, endpoint registration).
Each feature in Presentation has its own endpoint class, and `IdentityEndpoints` only registers them.
