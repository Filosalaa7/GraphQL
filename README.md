# School API - GraphQL .NET Solution

Welcome to the **School API** — a GraphQL-based .NET Core project that manages course data, user authentication, and authorization.  
This solution uses a clean architecture approach with **Repository Pattern**, **JWT Authentication**, **GraphQL (HotChocolate)**, **DataLoaders**, and **FluentValidation** integration.

The project is fully dockerized and available on Docker Hub:  
👉 [`filosalah/schoolapi`](https://hub.docker.com/r/filosalah/schoolapi)

---

## ✨ Features

- **GraphQL API** with HotChocolate
- **Authentication & Authorization** with JWT Tokens
- **Admin Role Protection** for sensitive operations
- **Repository Pattern** for data access
- **FluentValidation** for input validation
- **DataLoaders** for efficient data fetching
- **AutoMapper** for clean DTO to Entity mappings
- **Offset Paging**, **Filtering**, **Sorting** out-of-the-box
- **Dockerized** for easy deployment

---

## 📚 GraphQL Schema Overview

### Queries

- **GetOffsetCourses**  
  ➔ Fetch paginated, filterable, sortable list of courses using offset paging.

- **GetAllCourses**  
  ➔ Retrieve all courses with Relay-style cursor paging.

- **GetCourseById(id: Guid)**  
  ➔ Fetch a single course by its ID.

### Mutations

- **CreateCourse(courseInput: CourseTypeInput)**  
  ➔ Admin-only. Create a new course.

- **UpdateCourse(id: Guid, courseInput: CourseTypeInput)**  
  ➔ Admin-only. Update an existing course.

- **DeleteCourse(id: Guid)**  
  ➔ Admin-only. Delete a course.

- **Register(input: RegisterModel)**  
  ➔ Register a new user.

- **Login(input: TokenRequestModel)**  
  ➔ Obtain JWT tokens via login.

- **AddRole(input: AddRoleModel)**  
  ➔ Admin-only. Assign a new role to a user.

---

## 🛡️ Authentication & Authorization

- Uses **JWT Bearer Tokens** for user authentication.
- Protected mutations (e.g., create, update, delete course, add role) require the user to be authenticated and in the **Admin** role.
- User roles are stored in JWT claims and validated through `[Authorize]` attributes.

---

## 🏗️ Technologies & Libraries

| Technology             | Purpose                  |
|:------------------------|:-------------------------|
| .NET Core 8             | Backend framework        |
| GraphQL HotChocolate    | API technology           |
| Entity Framework Core   | ORM                      |
| FluentValidation        | Request validation       |
| AutoMapper              | Object mapping           |
| JWT Tokens              | Authentication           |
| Docker                  | Containerization         |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)

---

### Run with Docker

1. Pull the Docker image:

```bash
docker pull filosalah/schoolapi
```

2. Run the container:

```bash
docker run -d -p 5000:80 filosalah/schoolapi
```

> The GraphQL endpoint will be available at:  
> ➡️ `http://localhost:5000/graphql`

---

### Run Locally (Without Docker)

1. Clone the repository:

```bash
git clone https://github.com/YOUR_GITHUB_USERNAME/schoolapi.git
cd schoolapi
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Run the application:

```bash
dotnet run
```

GraphQL Playground/Altair will be available at:  
➡️ `https://localhost:5001/graphql` (for HTTPS)  
➡️ or `http://localhost:5000/graphql` (for HTTP)

---

## 🧪 Example GraphQL Mutations

### Register a User

```graphql
mutation {
  register(input: {
    email: "test@example.com",
    password: "Pa$$w0rd!"
  }) {
    isAuthenticated
    token
  }
}
```

### Login

```graphql
mutation {
  login(input: {
    email: "test@example.com",
    password: "Pa$$w0rd!"
  }) {
    token
    refreshToken
  }
}
```

### Create Course (Admin Role Required)

```graphql
mutation {
  createCourse(courseInput: {
    name: "Math 101",
    subject: "Mathematics",
    instructorId: "GUID-OF-INSTRUCTOR"
  }) {
    id
    name
    subject
    instructorId
  }
}
```

---

## 📦 Folder Structure (Important Parts)

```
/School.API                   --> Main API project
  ├── /Controllers             --> (Optional) API Controllers
  ├── /DataLoaders             --> GraphQL DataLoaders for batching & caching
  ├── /Mappings                --> AutoMapper profiles
  ├── /Models                  --> Entity models
  ├── /Schema                  --> GraphQL Queries, Mutations, Types
  ├── /Validators              --> FluentValidation validators
  ├── /Views                   --> GraphQL Views
  ├── appsettings.json         --> App configuration
  ├── Dockerfile               --> Docker container file
  └── Program.cs               --> Application entry point

/School.Core                   --> Core layer (Business logic)
  ├── /DTOs                    --> Data Transfer Objects
  ├── /Interfaces              --> Repository and Service interfaces
  └── /Models                  --> Core business models

/School.Infrastructure         --> Infrastructure layer (Data access)
  ├── /Migrations              --> Entity Framework migrations
  ├── /Repositories            --> Repository implementations
  └── SchoolDbContext.cs       --> EF Core database context
```

---

## 👨‍💻 Author

Made with ❤️ by **Filo Salah**  
🔗 Docker Hub: [filosalah/schoolapi](https://hub.docker.com/r/filosalah/schoolapi)

---

#️⃣ _Feel free to fork, contribute, and star this project!_
