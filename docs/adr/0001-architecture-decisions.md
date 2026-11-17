# ADR 0001: Architecture decisions

**Project:** Wind Crane (port transport crane installation logistics)
**Status:** Proposed, for team review

## Context

A single-tenant system for one company, with about 165 features, 6 months and 4 releases. Financial data (budgets, forecasts, change orders and P&L) must stay consistent.

## Decisions

| # | Decision | Reasons |
|---|---|---|
| 1 | **Modular monolith** | Fastest to build. Sales budget, forecast, change orders and P&L change together, and one database transaction keeps the money consistent. The audit row commits in the same transaction as the change. Easier debugging and testing: one process, one log, one test database. Cross-module dashboards are a single query in one database. |
| 2 | **No independent scaling** | Single tenant, so no independent scaling is needed. The load is one company's users and field crew, not public traffic. |
| 3 | **PostgreSQL** | Exact `numeric` money type. Strong ACID transactions. JSONB suits audit change records. |
| 4 | **Not NoSQL** | The data is relational (project, windmill, cargo, stage, sub-activity). Financial data needs strong consistency and constraints. Reports need joins. |
| 5 | **Hangfire** (background jobs) | Automatic retries with backoff. A dashboard shows failed FX, delay-check and integration jobs. Jobs survive restarts, with storage in Postgres and no extra infrastructure. |
| 6 | **Blob storage for files** | Cheap. Large files stay out of the database, keeping backups small and fast. |
| 7 | **Postgres views for reports** | No extra system. Same data and same org-scope filter as the app. |
| 8 | **ASP.NET Core Identity + Microsoft Entra ID** | Password, authenticator code and QR setup are built in. Entra covers internal single sign-on without a second login system. |
| 9 | **SignalR** (real-time notifications) | Built into .NET and matches the real-time notification requirement. |

## Open items

- Number of users and projects, team size and hosting platform.
- Mobile app framework and web frontend framework.
- Confirmation that Entra ID is available for internal users.
