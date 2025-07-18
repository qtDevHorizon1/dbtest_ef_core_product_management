# Entity Framework Core Product Management Application

This is a .NET 6 console application using Entity Framework Core for data access, demonstrating integration with SQL Server 2019 and following best practices for application architecture.

## Technology Stack

- .NET 6
- Entity Framework Core 6
- SQL Server 2019
- Visual Studio 2022 or later

## Prerequisites

- Visual Studio 2022 or later
- .NET 6 SDK
- SQL Server 2019 (Developer Edition is free and recommended for development)
- SQL Server Management Studio (SSMS) or Azure Data Studio

## Project Structure

- `DataAccess/`: Contains Entity Framework Core DbContext
- `Models/`: Contains entity classes with EF attributes
- `Business/`: Contains business logic
- `CLI/`: Contains command-line interface implementation
- `Database/Scripts/`: Contains database setup and stored procedure scripts

## Setup Instructions

1. **Install SQL Server 2019**:
   - Download and install SQL Server 2019 Developer Edition
   - During installation, note down your instance name (default is usually `.` or `localhost`)
   - Make sure SQL Server Browser service is running

2. **Set Up Database**:
   - Open SQL Server Management Studio (SSMS)
   - Connect to your SQL Server instance
   - Run the script `Database/Scripts/01_InitialSetup.sql`
   - This will create the database, tables, stored procedures, and sample data

3. **Configure Connection String**:
   - Open `appsettings.json`
   - The connection string is already configured for SQL Server 2019:
   ```json
   "ConnectionStrings": {
     "DevConnection": "Data Source=.;Initial Catalog=ProductManagement;Integrated Security=True;MultipleActiveResultSets=True"
   }
   ```
   - If your SQL Server instance has a different name, update the `Data Source` value

4. **Restore NuGet Packages**:
   - Run the following command to restore packages:
   ```bash
   dotnet restore
   ```
   - This will install Entity Framework Core and its dependencies

5. **Apply Database Migrations**:
   - Run the following commands to create the database schema:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Running the Application

The application can be run in two modes: Interactive (menu-driven) and Command-Line Interface (CLI).

### Interactive Mode

1. Run the application without any arguments:
   ```
   dotnet run
   ```
2. You'll see the main menu with these options:
   ```
   Product Management System
   ------------------------
   1. List all products
   2. Get product by ID
   3. Create new product
   4. Update product
   5. Delete product
   6. Update product stock
   Q. Quit
   ```

### Command-Line Interface (CLI)

The application supports the following commands:

```bash
# Show help
dotnet run -- --help

# List all products
dotnet run -- list

# Get product by ID
dotnet run -- get 1

# Add new product
dotnet run -- add "Gaming Mouse" 49.99 10 "High-performance gaming mouse"

# Update product
dotnet run -- update 1 "Gaming Mouse Pro" 59.99 15 "Updated gaming mouse"

# Delete product
dotnet run -- delete 1

# Update stock quantity
dotnet run -- stock 1 20
```

## Database Structure

The application uses the following database objects:

1. **Products Table**:
   - ProductId (INT, Primary Key)
   - Name (NVARCHAR(100))
   - Description (NVARCHAR(500))
   - Price (DECIMAL(18,2))
   - StockQuantity (INT)
   - CreatedDate (DATETIME)
   - ModifiedDate (DATETIME)

2. **Stored Procedures** (if you wish to use them for advanced scenarios):
   - sp_GetAllProducts
   - sp_GetProductById
   - sp_InsertProduct
   - sp_UpdateProduct
   - sp_DeleteProduct

## Troubleshooting

If you encounter errors:
1. Verify SQL Server 2019 is running (check Services)
2. Confirm your connection string matches your SQL Server instance name
3. Ensure the database exists and is accessible
4. Check you have appropriate permissions to access the database
5. Make sure Entity Framework Core NuGet packages are installed correctly
6. Check the Output window in Visual Studio or terminal for detailed error messages

## Entity Framework Core Features Used

- Entity Framework Core 6 with .NET 6
- Code-First approach with data annotations
- Automatic change tracking
- Built-in transaction management
- LINQ queries for data access
- Proper resource disposal with DbContext
- Fluent API for entity configuration

## Best Practices Implemented

- Separation of concerns (layered architecture)
- Dependency injection
- Proper resource disposal
- Transaction management
- Error handling and logging
- Configuration management
- Security best practices 