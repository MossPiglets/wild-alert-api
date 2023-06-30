# WildAlertAPI

## Project Description
This API is a part of an educational and self-development project designed to detect and gather data about the presence of wild animals in urban areas.
The API receives data from users and the [BoarRoarDetector](https://github.com/Krystyna-Szybalska/BoarRoarDetector/tree/master/app) microservice and is connected to a PostgreSQL database hosted on [Heroku](https://wild-alert-api.herokuapp.com/Swagger/index.html). Example frontend project for this API is located here: [WildAlertApp](https://github.com/MossPiglets/wild-alert-api/edit/develop/README.md).

### Architecture
The solution architecture consists of multiple projects, each with a specific role in implementing the CQRS pattern.

**1. WildAlert.API**
   
   The API project receives incoming requests, performs authorization checks, validates input, and delegates commands or queries to the appropriate handlers in the Application project.
   
**2. WildAlert.Application**
   
   The Application project contains the core business logic of the system. It implements the command and query handlers, which are responsible for handling write operations (commands) and retrieving data (queries) from the underlying persistence layer. The Application project orchestrates the interactions between the API and the Persistence project.
   
**3. WildAlert.Persistance**

The Persistence project handles data persistence and access to the PostgreSQL database. It includes repositories, data models, and database-specific configuration. 

**4. WildAlert.UnitTests**

The UnitTests project utilizes the NUnit testing framework and BDD style syntax of Given, When, Then.

**5. WildAlert.IntegrationTests**

This project will contain IntegrationTests in the future.

**WildAlert.Shared** and **WildAlert.Tests.Shared** contain shared utilites for other projects.

## Usage
Ensure that Docker is running on your system. 
Build and run the Docker container. Execute the following command in the terminal:

``` docker-compose up -d ```

And start the project:

```dotnet run ```

To access certain endpoints, API Key authentication is required. 

### API Key
>1a87479852d0471881df50cb39e33283

## Technologies
* C#
* ASP.NET
* Entity Framework Core
* NUnit
* MediatR
* CQRS
* Swagger
* Docker

## License
This project is licensed under the MIT License.


