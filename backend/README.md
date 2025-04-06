# Development

## Database Migrations

To create a new migration:
```bash
dotnet ef migrations add MigrationName --project Goalify.Infrastructure --startup-project Goalify.Api
```

To apply migrations:
```bash
dotnet ef database update --project Goalify.Infrastructure --startup-project Goalify.Api
``` 