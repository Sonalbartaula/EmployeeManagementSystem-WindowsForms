# Employee Management System

## Installation

1. Clone the repository:
```
git clone https://github.com/Sonalbartaula/employee-management-system.git
```
2. Open the solution in Visual Studio.
3. Build the project to restore the NuGet packages.
4. Ensure that you have the necessary database connection string configured in the `AppDbContext.cs` file.
5. Run the application.

## Usage

1. Upon launching the application, you will be presented with the login screen.
2. If you don't have an account, click the "Don't have an account? Sign Up" button to create a new user.
3. After logging in, you will see the dashboard, which displays a list of all employees.
4. You can perform the following actions:
   - Add a new employee by clicking the "Add Employee" button.
   - Edit an existing employee by selecting a row and clicking the "Edit Employee" button.
   - Delete an employee by selecting a row and clicking the "Delete Employee" button.
   - Refresh the employee list by clicking the "Refresh" button.
   - Logout by clicking the "Logout" button.

## API

The application does not provide a public API. It is a desktop application built using Windows Forms.

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your changes to your forked repository.
5. Submit a pull request to the original repository.

## License

This project is licensed under the [MIT License](LICENSE).

## Testing

The application includes unit tests for the `PasswordHelper` class. To run the tests, open the solution in Visual Studio and use the built-in testing tools.
