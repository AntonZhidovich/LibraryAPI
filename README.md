# LibraryAPI

The solution consists of two microservices: **LibraryAuthApi** for user authenticating and creating the JWT token, and **LibraryAPI** for working with books. Each microservice implements a three-layer architecture. IExceptionHandler, the .NET 8 feature, is used for global exception handling.

### Authentication Microservice
LibraryAuthAPI is connected to the UserDB (creates it, if necessary), which stores personal data. For demonstration, the database is initialised with a single person Dmitry Ivanov:
```
username: Dmitry.Ivanov
password: pa$$w0rd.
``` 
The microservice has the AuthorizationController with a _SignIn_ action to authenticate the user and return a bearer token. The method allows unauthorized accesss.

### Library API Microservice
LibraryAPI is connected to the BookDB  (creates it, if necessary), which stores data about books. The database is initialized with two books. The microservice has a three-layer architecture (divided into Data Access Layer, Business Logic Layer, and Presentation Layer) and the CQRS-pattern is implemented using MediatR. The FluentValidation library is used for server-side validation of user input. Requests are handled by the BookController. It contains methods for working with book entities (CRUD logic) and requires authorized access. 

### Stack: ASP.NET Core 8, Entity Framework Core, Fluent API, MS SQL Server, MediatR, FluentValidation, Global Exception Handling, AutoMapper, Swagger

# Installation & Run

First, clone the repository:
```
git clone https://github.com/AntonZhidovich/LibraryAPI
```
There are two options to run the project.

**With script** <br>
Run the **"RUN.bat"** script in the solution folder, which builds the projects, starts both microserivces and opens swagger pages in the browser. Wait until both projects are started. After that, reload browser pages, if needed.

**With Visual Studio** <br>
In Visual Studio, to launch both microsirvices, go to solution properties and on "Startup Project" tab select "Multiple startup projects", LibraryAPI -> Start, LibraryAuthApi -> Start, press Ok. 
Then you can press the Start button.

Firts, you need to sign in with Dmitry Ivanov credentials in the **LibraryAuthAPI** swagger page to obtain a JWT token. Pass it into the **LibraryAPI** swagger authorization window. After that, you can acces Book controller methods.
