# Hotel Reservation Importer API

A simple **.NET 9 Web API** that imports hotel reservation data from an XML file and stores it in an in-memory database.

---

## Features

- Import hotel reservations from an embedded XML file in the project.
- Store reservation data using Entity Framework Core InMemory database provider.
- Retrieve all stored reservations through a REST API endpoint.
- Clean and modular architecture separating models, data access, services, and controllers.
- Swagger/OpenAPI integration for easy API exploration and testing.

---

## Technologies Used

- .NET 9 / ASP.NET Core Web API
- Entity Framework Core (InMemory database provider)
- XML parsing with `System.Xml.Linq`
- Dependency Injection
- Swagger / OpenAPI

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- IDE (Visual Studio 2022+, VS Code, Rider)

### Running the Project

1. Clone the repository.
2. Build and run the project:
   ```bash
   dotnet run
   
3. Open a browser and go to:
   ```bash
   https://localhost:{PORT}/swagger
   
Replace {PORT} with the port displayed in your console output.

### API Endpoints
`POST /api/reservations/import-from-file`
Imports reservations from the embedded XML file reservation_sample.xml.

### How It Works
The import endpoint reads the XML file bundled in the project.
Parses each reservation element into C# models.
Saves the reservations in the in-memory database.


### Notes
Uses EF Core InMemory database for demo and testing purposes.
For production, replace with a persistent database (e.g., SQL Server).
Import endpoint reads from a fixed XML file but can be extended to support uploads.

### License
Provided as-is for learning and demonstration.