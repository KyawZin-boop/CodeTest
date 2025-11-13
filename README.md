# CodeTest

This is a .NET 8 Razor Pages application for managing products and files.

## Prerequisites

- .NET 8 SDK
- SQL Server (Local or Remote)

## Database Configuration

Before running the application, you need to configure the database connection string in the `AppDbContext.cs` file.

### Steps to Configure:

1. Open `AppSettings/AppDbContext.cs`

2. Locate the connection string configuration and update the following values:

```csharp
DataSource = ".",          // Your SQL Server instance (e.g., "localhost", "server-name", or ".")
InitialCatalog = "",       // Your database name (e.g., "CodeTestDb")
UserID = "",               // Your SQL Server username (e.g., "sa")
Password = "",             // Your SQL Server password
```

### Configuration Guide:

- **DataSource**: The name or IP address of the SQL Server instance
  - Use `"."` or `"localhost"` for local SQL Server
  - Use the server name for remote SQL Server (e.g., `"SERVER-NAME"`)

- **InitialCatalog**: The name of your database
  - Create a database first or the application will attempt to create it
  - Example: `"CodeTest"`

- **UserID**: SQL Server login username
  - Example: `"sa"` (default SQL Server admin)

- **Password**: SQL Server login password
  - Ensure the password is secure
 
## Database Script

A SQL script is included for database creation:  
**`CodeTestScript.sql`**

- Run this script in SQL Server Management Studio or your preferred SQL tool to create the required tables and schema before running the application.

## Running the Application

1. Update the connection string as described above
2. Run the application:
   ```bash
   dotnet run
   ```
3. Navigate to `https://localhost:7092` (or the configured port)

## Features

- Product Management (Add, Edit, Delete, View Products)
- File Management
- Shared layouts and styling

## Project Structure

- **Controllers**: Application logic for handling requests
- **Services**: Business logic for products and files
- **Views**: Razor Pages and HTML templates
- **Models**: Data models (Product, Common)
- **AppSettings**: Database configuration (AppDbContext)

