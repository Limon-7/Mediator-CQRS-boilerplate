## Getting Started
The following prerequisites are required to build and run the solution:

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

Launch the app:
```bash
cd Web.API
dotnet run
```

## Database
### Migration
Running database migrations is easy. Ensure you add the following flags to your command (values assume you are executing from repository root)

* `--project Infrastructure` (optional if in this folder)
* `--startup-project Web.API`
* `--output-dir Persistance/Migrations`

For example, to add a new migration from the root folder:
```bash
dotnet ef migrations add "SampleMigration" --project Infrastructure --startup-project Web.API --output-dir Persistance\Migrations
```
### Remove Migration
```bash
dotnet ef migrations remove  --project Infrastructure --startup-project Web.API
```

### Update Database
```bash
dotnet ef database update --project .\Infrastructure\ --startup-project Web.API
```
## Overview

### Domain
This will contain all `entities, enums, exceptions, interfaces, types` and `logic specific` to the `domain layer`.

### Application
This layer contains all `application logic`. It is dependent on the `domain layer`, but has `no dependencies` on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a `notification service`, a new interface would be added to `application` and an implementation would be created within `infrastructure`.

### Infrastructure
This layer contains `classes` for accessing external resources such as `file systems`, `web services`, `smtp`, and so on. These classes should be based on interfaces defined within the `application layer`.

### Web.API
This layer depends on both the `Application` and `Infrastructure` layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.