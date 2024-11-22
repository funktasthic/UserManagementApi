# USER MANAGEMENT API

The User Management API is a RESTful service designed to provide a robust platform for managing user data. Built with modern development practices, it offers essential CRUD functionality while adhering to REST principles, ensuring a scalable and maintainable solution.

<p align="center">
  <img src="https://www.techmeet360.com/wp-content/uploads/2018/11/ASP.NET-Core-Logo.png" alt="Logo" height="300">

## Features

- Create Users: Add new users with validation for fields and hashed passwords for security.
- Read Users: Fetch user details or a paginated list of users.
- Update Users: Modify one or multiple user properties simultaneously.
- Delete Users: Soft delete users by marking them as inactive, preserving data integrity.

## Technologies

- ASP.NET Core 8.0
- Entity Framework Core
- SQLite
- JWT for token-based authentication

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

## Installation

1. Clone the repository from GitHub and navigate to its directory by running the following commands in your terminal:

   ```bash
   git clone https://github.com/funktasthic/UserManagementApi.git
   cd UserManagementApi
   ```

2. Configure the `appsettings.json` file with your SQLite database details.

3. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

4. Create and apply Entity Framework Core migrations to set up the database:

   ```bash
   dotnet ef migrations add UserMigration --output-dir Data/Migrations
   dotnet ef database update
   ```

5. Run the application locally:

   ```bash
   dotnet run
   ```

6. (Optional step) If you have problems running the project you just have to use

   ```bash
   dotnet help
   ```

## Authors

- [@funktasthic](https://www.github.com/funktasthic)
- [@KuajinaiSS](https://www.github.com/kuajinaiss)
