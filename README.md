# Goalify

Goalify is a modern web application for managing table football tournaments, providing automatic rankings and detailed player statistics.

## Project Structure

```
goalify/
├── backend/
│   ├── Goalify.Api/              # API controllers and configuration
│   ├── Goalify.Application/      # Application services and DTOs
│   ├── Goalify.Core/             # Domain entities and repository interfaces
│   ├── Goalify.Infrastructure/   # Data access and repository implementations
│   └── docker-compose.yml        # Docker configuration for PostgreSQL
└── frontend/         # (Coming soon) Frontend application
```

## Backend Setup

### Prerequisites

- .NET 9 SDK
- Docker and Docker Compose
- PostgreSQL (via Docker)

### Getting Started

#### Back-end

1. Clone the repository
2. Navigate to the backend directory
3. Run the following commands:

```bash
# Start the PostgreSQL database using Docker Compose
docker-compose up -d

# Run the application
dotnet run --project Goalify.Api
```