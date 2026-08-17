# Task Manager API - Using Layered Architecture

A RESTful Web API built with **C# and ASP.NET Core** for managing a personal tasks.

This project was developed **primarily to understand the structure and implementation of layered architecture in ASP.NET Core Web API**, while also exploring concepts such as business rules, input validation, exception handling, and dependency injection.

## Technologies

- C#
- .NET
- ASP.NET Core Web API
- Swagger / OpenAPI
- Visual Studio

## Features

- List all tasks
- Get a task by ID
- Create a task
- Update a task
- Delete a task
- Input validation
- Business rule validation
- Status and Priority validation
- HTTP status code handling

## Layered Architecture

For this project, the following layered architecture was adopted:

1. TaskManager.API — The entry point of the application, responsible for handling HTTP requests through the controllers.
2. TaskManager.Application — The application/service layer, responsible for implementing the application's use cases and business rules.
3. TaskManager.Communication — The DTO layer, responsible for defining and organizing the request and response objects used to communicate between the API and the application layer.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |

## What I Practiced

Through this project, I practiced:

- Layered architecture in .NET
- ASP.NET Core Web API
- RESTful API design
- HTTP methods and status codes
- Business rule implementation
- Input validation
- Exception handling
- Debugging with Visual Studio

## How to Run

### Prerequisites

Make sure you have installed:

- .NET SDK
- Visual Studio 2022 or another C#/.NET IDE

### 1. Clone the repository

```bash
git clone https://github.com/AnaLinsDev/task-manager-api.git
```

### 2. Navigate to the project

```bash
cd TaskManager
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Build the project

```bash
dotnet build
```

### 5. Run the API

```bash
dotnet run
```

The terminal will display the URL where the API is running.

### 6. Open Swagger

Open the Swagger URL displayed by the application in your browser.

Swagger can be used to test the available API endpoints without requiring Postman or another API client.
