# SastoTech

SastoTech is an ASP.NET Core Razor Pages web application designed to list and showcase technical products, specifically laptops and mobile phones. Built with .NET 9, it uses Entity Framework Core with a PostgreSQL database and is optimized for deployment on cloud platforms like Render.

## Features

- **Product Listings:** View detailed listings of Laptops and Mobiles.
- **Price Tracking:** Tracks the "Lowest Price Ever" for products.
- **Razor Pages Architecture:** Uses a clean, page-based architecture for server-side UI rendering.
- **Entity Framework Core:** Uses EF Core for data access with automatic migrations on startup.
- **PostgreSQL Database:** Configured to use PostgreSQL for robust data storage.
- **Cloud-Ready:** Includes a `Dockerfile` and is pre-configured to bind to the dynamic `PORT` environment variable assigned by platforms like Render.

## Tech Stack

- **Framework:** .NET 9.0 (ASP.NET Core Razor Pages)
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core (`Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Frontend:** HTML, CSS, JavaScript (Bootstrap & jQuery included)
- **Containerization:** Docker

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- PostgreSQL Server
- Docker (optional, for containerized execution)

### Local Development Setup

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd SastoTech
   ```

2. **Configure the Database:**
   Update the `DefaultConnection` string in `SastoTech/appsettings.json` or `SastoTech/appsettings.Development.json` to point to your local PostgreSQL instance.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=sastotech_db;Username=your_username;Password=your_password"
   }
   ```

3. **Run the Application:**
   Navigate to the `SastoTech` project directory and run the app. The application will automatically apply any pending database migrations on startup.
   ```bash
   cd SastoTech
   dotnet run
   ```
   The application will be available at `http://localhost:5000` (or the port specified in your local environment).

### Running with Docker

You can also build and run the application using Docker:

```bash
docker build -t sastotech .
docker run -p 8080:8080 -e PORT=8080 -e ConnectionStrings__DefaultConnection="<your_postgres_connection_string>" sastotech
```

## Project Structure

- `SastoTech/`
  - `Pages/`: Contains the Razor Pages (UI and page models) for Laptops, Mobiles, About, FAQ, etc.
  - `Models/`: Contains the domain models (`Laptops.cs`, `Mobiles.cs`).
  - `Data/`: Contains the Entity Framework Core database context (`AppDbContext.cs`).
  - `Migrations/`: Contains the EF Core database migrations.
  - `wwwroot/`: Contains static assets like CSS, JavaScript, images, and library files.

## Deployment

SastoTech is structured for easy deployment to platforms like [Render](https://render.com/). It automatically binds to the `PORT` environment variable provided by the host and applies EF Core migrations during startup to ensure the database schema is up to date.

## License

This project is licensed under the MIT License - see the LICENSE file for details (if applicable).
