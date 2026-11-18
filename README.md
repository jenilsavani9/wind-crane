# Wind Crane

Port transport crane installation logistics platform. Modular monolith on .NET, PostgreSQL, Dapper, Clean Architecture.

- `WindCrane.Api/`          host: startup, auth setup, SignalR, Hangfire
- `WindCrane.Shared/` base classes and shared types (no business logic)
- `WindCrane.Database/`     DbUp runner project; versioned SQL scripts per module in `Scripts/<Module>/`
- `Identity/`               first module: Domain, Application, Infrastructure, Presentation
- `docs/`                   architecture decisions

Each new module is a folder at the root with the same four projects as `Identity/`.
Database changes are SQL scripts only (no migrations). Testing is manual.
