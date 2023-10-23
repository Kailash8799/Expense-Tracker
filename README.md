# Expense Tracker

## Project Description
Welcome to the Expense Tracker Web App, a simple web-based tool for managing your personal finances.

## Prerequisites
Before you begin, ensure you have met the following requirements:
- .NET Core SDK (version 6.0 or higher)
- Visual Studio Code or Visual Studio (recommended)

## Installation
1. Clone the repository:

    ```shell
    git clone https://github.com/Kailash8799/Expense-Tracker.git
    ```

2. Open Visual Studio code and open `Expense-Tracker-Project.sln` file of this project
3. **Database Setup**: Update your database connection string in the `appsettings.json` file.

   ```shell
   {
      "ConnectionStrings": {
          "DefaultConnection": "your-connection-string-here"
      }
   }
   
4. **Database Migration**: Run database migrations to create the database schema.

   ```shell
   add-migration "your-migration-name"
   update-database

5. **Run the Application**: Start the ASP.NET Core application.

## Usage
1. **Authentication** : Login and signup functionality
2. **Create a Category**: navigate to the "category" page. Fill in the category details, including the title, tag.

3. **Create expense**: navigate to the "create expense" page. Fill the transacation details and create new expense.


## Features
- Dynamic category creation
- User registration for expense

## Project Structure

- `Expense.DataAccess`: Contains repositories responsible for handling database connection.
- `Expense.Models`: Contains models of app.
- `Controllers`: Contains controllers responsible for handling HTTP requests.
- `Views`: Contains the views for the application.
- `Models`: Defines the data models used in the application . 

## Contact Information
- [Twitter](https://twitter.com/thekailash8799)
- [github](https://github.com/Kailash8799)
