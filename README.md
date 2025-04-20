# Task tracker
Submission for https://github.com/hmcts/dts-developer-challenge
## Stack
### Backend
- C# 12 / .NET 8.0
- ASP.NET Core
- PostgreSQL
### Frontend
- Typescript
- AG Grid Library to display data in tabular format
## Functionality
- Create a new task
- View all tasks
- Amend a task
- Delete a task
## How to run
1. Install Docker
2. Clone this repo
3. From the project root run `docker compose -f docker-compose.yml up --build`
4. Go to: http://localhost:8080
## Available endpoints
This project uses Swagger UI to display routes and endpoints when running the Server in development mode
1. From the project root run `docker compose up --build`
   
    _- NOTE: We don't specify the docker-compose file so we use the override file for development mode_
2. Go to: http://localhost:8080/swagger

_Alternatively, check the README.md in the /Server directory_
## Project Structure
The project uses a layered architecture. Unlike larger codebases which follow Clean Architecture / Layered Architecture, each layer is under the same C# project and is instead represented as a directory.
### Controllers
- Handle the incoming requests
- Pass off any logic to the relevant service
- Send response back to client
### Services
- Hold application level logic
### Domain
- Hold models for entities
- Hold business logic
### Repositories
- Interface with database
### Persistence 
- DbContext related actions

