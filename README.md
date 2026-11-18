# Wind Crane

Port transport crane installation logistics platform.
Modular monolith on .NET 10, PostgreSQL and Angular, Clean Architecture.

Dependencies point inward: Web and Infrastructure -> Application -> Domain. Domain depends on nothing.

## Folder guide

```
src/                              all application code
│
├─ Domain/                        the business core; no dependencies on anything else, so rules stay pure
│  ├─ Common/                     base classes shared by entities (BaseEntity, auditable entity, value object, base event)
│  ├─ Constants/                  fixed business values, e.g. the 7 role names (SuperAdmin, Driver, ...)
│  ├─ Entities/                   business objects with their rules, e.g. User, Project, SalesBudget
│  ├─ Enums/                      fixed lists of values, e.g. ProjectStatus, ProjectType
│  ├─ Events/                     domain events raised when something important happens, e.g. PoApproved
│  ├─ Exceptions/                 business rule errors, e.g. a budget cannot be edited after approval
│  └─ ValueObjects/               small immutable objects compared by value, e.g. Money (amount + currency)
│
├─ Application/                   use cases: what the system does; knows Domain, not the database or HTTP
│  │                              (add one folder per feature here, e.g. Users/Commands, Users/Queries)
│  └─ Common/                     code shared by all features
│     ├─ Behaviours/              steps that run around every request: validation, logging, authorization
│     ├─ Exceptions/              application errors, e.g. validation failed, access forbidden
│     ├─ Interfaces/              contracts that Infrastructure implements, e.g. IUserRepository, ITokenService
│     ├─ Models/                  shared result and paging types, e.g. Result, PaginatedList
│     └─ Security/                attributes and helpers for role checks, e.g. [Authorize(Roles = ...)]
│
├─ Infrastructure/                technical details; implements the Application interfaces
│  ├─ Data/                       PostgreSQL access with Dapper: repositories and SQL
│  └─ Identity/                   login technology: password hashing, authenticator code, JWT tokens, Entra ID
│
├─ Web/                           the HTTP entry point; the only project that runs
│  ├─ Endpoints/                  one class per feature that defines its routes, e.g. Users, Projects
│  ├─ Infrastructure/             web plumbing: exception handler, endpoint registration, OpenAPI setup
│  ├─ Services/                   web-specific services, e.g. the current logged-in user from the request
│  ├─ wwwroot/                    the built Angular app that the API serves in production
│  └─ ClientApp/                  the Angular web client (standard Angular CLI project)
│
└─ Database/                      separate console app that applies SQL scripts to PostgreSQL (DbUp)
   └─ Scripts/<Module>/           versioned SQL files per module, run in order, e.g. 0001_create_identity_schema.sql

docs/adr/                         architecture decision records: what we decided and why
Directory.Build.props             build settings shared by every project (.NET version, nullable, warnings as errors)
Directory.Packages.props          one place for NuGet package versions; add a package here when code needs it
global.json                       pins the .NET SDK version so everyone builds with the same one
WindCrane.slnx                    the solution file that lists all projects
```

## Run

```bash
dotnet build WindCrane.slnx
dotnet run --project src/Web
```

Dummy login (in-memory users `admin` / `admin123` and `driver` / `driver123`, fake token):

```bash
curl -X POST http://localhost:5289/api/auth/login -H "Content-Type: application/json" -d '{"username":"admin","password":"admin123"}'
```

To add a route: create a class in `src/Web/Endpoints/` that implements `IEndpointGroup` (see `Auth.cs`); it is found automatically.

Angular client (separate dev server, proxies `/api` to the API on http://localhost:5289):

```bash
cd src/Web/ClientApp
npm install
PORT=4200 npm start
```

`dotnet publish` builds the Angular app and copies it to `wwwroot`.
Set `API_URL` to point the Angular proxy at a different API address.
`npm run generate-api` generates the TypeScript API client from the OpenAPI document (`nswag.json`); run it once the API exposes OpenAPI.

Database scripts:

```bash
dotnet run --project src/Database -- "Host=localhost;Database=windcrane;Username=postgres;Password=..."
```

Testing is manual; database changes are SQL scripts only.
