# LibraryAPI

The solution consists of two microservices: LibraryAuthApi for authenticating user and creating the JWT token, and LibraryAPI for working with books. Each microservice implements a three-layer architecture. IExceptionHandler, the .NET 8 feature, is used for global exception handling.

### Authentication Microservice
LibraryAuthAPI is connected to the UserDB (creates it, if necessary), which stores personal data. For demonstration, the database is initialised with a single person Dmitry Ivanov:
```
username: Dmitry.Ivanov
password: pa$$w0rd.
``` 
The microservice has the AuthorizationController with a single action _SignIn_ to authenticate the user and return a bearer token.

### Library API Microservice
LibraryAPI is connected to the BookDB  (creates it, if necessary), which stores data about books. The database is initialized with two books. The microservice has a three-layer architecture (divided into Data Access Layer, Business Logic Layer, and Web API (Presentation Layer)) and the CQRS-pattern is implemented using MediatR. The FluentValidation library is used for server-side validation of user input. Requests are handled by two controllers: BookController and AccountController. The first contains methods for working with book entities (CRUD logic) and requires authorized access. The AccountContoller has a single action _Login_ for signing in with a password and obtaining a bearer token. This sends the http request to the Authentication Microservice. The action allows unauthorized access. 


### Stack: ASP.NET Core 8, Entity Framework Core, Fluent API, MS SQL Server, MediatR, FluentValidation, Global Exception Handling, AutoMapper, Swagger

# Installation & Run

First, clone the repository:
```
git clone https://github.com/AntonZhidovich/LibraryAPI
```
There are two options to run the project.

**With script** <br>
Run script **"RUN.bat"** in the solution folder, which builds the projects, starts both microserivces and opens swagger page in the browser. Wait until both projects are started.

**With Visual Studio** <br>
In Visual Studio, to launch both microsirvices, go to solution properties and on "Startup Project" tab select "Multiple startup projects", LibraryAPI -> Start, LibraryAuthApi -> Start, press Ok. 
Then you can press the Start button. 

Firts, you need to sign in with Dmitry Ivanov credentials, so use _Login_ action to obtain a JWT token and pass it to the swagger authorization window. After that, you can acces Book controller methods.
