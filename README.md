# ASP-MVC-JqGrid-Project

This project demonstrates how to integrate and use the jQuery JqGrid plugin in an ASP.NET MVC application. It showcases how to perform basic CRUD operations on an `Employee` model by directly connecting to a SQL Server database using `Microsoft.Data.SqlClient`. The employee data is displayed in a JqGrid on the Employees index view.

## Features

- **Employee Management** : Perform Create, Read, operations for employee data.
- **jQuery JqGrid Integration** :Utilize JqGrid to display employee data in a customizable, interactive grid.
- **Direct SQL Server Connection** : Use `Microsoft.Data.SqlClient` for direct database access without Entity Framework.
- **AJAX Support** : Retrieve and update data asynchronously via JSON.
- **Server-Side Operations** : Handle operations like sorting, paging, and filtering on the server side.

## Prerequisites
Ensure you have the following installed before running this project:
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (local or remote instance)

  ## Getting Started
1. Clone the repository
```bash
   git clone https://github.com/tusharNova/ASP-MVC-JqGrid-Project
   cd ASP-MVC-JqGrid-Project
```
2. Open the project in Visual Studio3. John Quincy Adams
- Navigate to the project directory and open the solution file (.`sln`) in Visual Studio.
3. Configure the SQL Server connection
- Update the connection string in the Emoployess file to point to your SQL Server database:
```bash
   string connection="server==your-server-name;Database=your-database-name;User Id = Username;Password=your-password;"
```
4. Build the project
- Build the project to resolve any dependencies and compile the solution.
5. Run the project
- Press `F5` to run the project or use the `Run` button in Visual Studio.

