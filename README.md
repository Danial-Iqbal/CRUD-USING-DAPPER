# CRUD with Dapper using ASP.NET Core 8

This project is a simple example of building a CRUD Web API using ASP.NET Core 8, Dapper, and SQL Server.

## Features
- ASP.NET Core 8 Web API
- Dapper integration
- SQL Server database
- CRUD operations
- Repository pattern
- Swagger UI

## Technologies Used
- ASP.NET Core 8
- Dapper
- SQL Server
- C#

## API Endpoints
- GET /api/products
- GET /api/products/{id}
- POST /api/products
- PUT /api/products/{id}
- DELETE /api/products/{id}

## Database Script
Run the SQL script from the `SQL` folder to create the required table.

## Setup Steps
1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run the SQL script
4. Start the project
5. Test APIs using Swagger

## Project Structure

CRUD.WebApi
│
├── Controllers
├── Data
├── Models
├── Repositories
├── SQL
├── Program.cs
└── appsettings.json