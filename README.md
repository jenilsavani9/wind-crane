# Wind Crane

Port transport crane installation logistics platform.
Modular monolith on .NET 10, PostgreSQL and Angular, Clean Architecture.

Only the **folder structure** of the Clean Architecture Solution Template is used
(`dotnet new ca-sln -cf angular -db postgresql`). The template's code is not included; it is rewritten as we build.

```
src/
  Domain/           no dependencies
    Common/  Constants/  Entities/  Enums/  Events/  Exceptions/  ValueObjects/
  Application/      references Domain
    Common/{Behaviours, Exceptions, Interfaces, Models, Security}
  Infrastructure/   references Application
    Data/  Identity/
  Web/              references Application and Infrastructure
    Endpoints/  Infrastructure/  Services/  wwwroot/
    ClientApp/      Angular app (standard Angular CLI project)
  Database/         DbUp runner; versioned SQL scripts in Scripts/<Module>/
docs/adr/           architecture decisions
Directory.Build.props      shared build settings
Directory.Packages.props   one place for NuGet package versions (add packages when code needs them)
global.json                pins the .NET SDK
```

Dependencies point inward: Web and Infrastructure -> Application -> Domain.

## Run

```bash
dotnet build WindCrane.slnx
dotnet run --project src/Web
```

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
