# Task tracker
Submission for https://github.com/hmcts/dts-developer-challenge
## Stack
### Backend
- C# 12 / .NET 8.0
- ASP.NET Core
- PostgreSQL
### Frontend
- Javascript
## Functionality
- Create a new task
- View all tasks
- View tasks by ID
- Amend a task
- Delete a task
## How to run
1. Install Docker
2. Clone this repo
3. From the project root run `docker compose up -d --build`
4. Go to: https://localhost:????
## Project Structure
The project loosely follows a layered architecture. Unlike larger codebases which follow Clean Architecture / Layered Architecture, each layer is under the same C# project and is instead represented as a directory.
### Controllers
- Handle the incoming requests
- Pass off any logic to the relevant service
- Send response back to client
### Services
- Holds application level logic
### Domain
- Holds models for entities
- Holds business logic
### Persistence 
- Hold everything to do with PostgreSQL database

