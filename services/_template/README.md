# Service template

Every service lives in `services/<name>/` with:

- `service.yaml`  - name, gateway route, port, database, events published/consumed
- `src/`          - Api, Application, Domain, Infrastructure, Contracts (slim services may use fewer)
- `tests/`        - UnitTests, IntegrationTests
- `db/migrations` - the service's own migrations (one database per service)

Rules:
1. A service references only its own projects, `shared/`, and other services' `Contracts`.
2. `shared/` contains no business logic.
3. No cross-service database access; services communicate through events.
