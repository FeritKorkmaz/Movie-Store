# Movie Store WebApi

This project aims to develop a WebApi application that encompasses fundamental services of a movie store.

## Project Structure

### Movie

- Movie Title
- Release Year
- Genre
- Director
- Actors
- Price

### Actor

- First Name
- Last Name
- Movies Played In

### Director

- First Name
- Last Name
- Movies Directed

### Customer

- First Name
- Last Name
- Purchased Movies

## Application Requirements

1. **Movie Operations**

   - Add/Delete/Update/List Movies

2. **Customer Operations**

   - Add/Delete Customers/List Customers

3. **Actor Operations**

   - Add/Delete/Update/List Actors

4. **Director Operations**

   - Add/Delete/Update/List Directors

5. **Movie Purchase**

   - Customers can purchase movies through the application.

6. **Customer-Based Purchase Data**

   - The list of purchased movies can be viewed on a customer basis. Deleted movies should not affect order data.

7. **Movie Genres**
   - Can be created as default when the application is launched.

## Technical Requirements

1. **Entity Objects**

   - Should not be used as Input/Output.

2. **Models and DTOs**

   - Objects should be transformed into each other using the AutoMapper library.

3. **Controller and Service Operations**

   - Service operations should not be performed within controllers.

4. **Validation**

   - Each service should have a validation class. The application should be protected with strict rules.

5. **Exception and Logging**

   - Exception and logging infrastructure should be created using middleware.

6. **Dependency Management**

   - Dependencies should be managed from a single point using DI Container.

7. **Authentication and Authorization**

   - A basic Authentication and Authorization structure should be implemented.

8. **Deletion Operations**
   - Data consistency should be considered. Related data cannot be deleted.

## How to Start

1. Copy project files to your computer.
2. Open the project in an IDE (Visual Studio, VS Code, etc.).
3. Install required packages: `dotnet restore`.
4. Start the application: `dotnet run`.

**Note:** To run the project, you need to have at least [.NET 6.0.100] version of the .NET Core SDK installed on your computer. If it's not installed, you can download the latest version of .NET 6.0 SDK from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/6.0).
