# Student Management System

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![SQL Server](https://img.shields.io/badge/SQL_Server-CC292B?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Student Management System is a full-stack platform built with .NET 8, designed to efficiently manage students, departments, roles, and users. It leverages Clean Architecture to ensure a highly maintainable, scalable, and decoupled codebase, providing a RESTful API backend and a responsive MVC frontend.

## Why this project stands out
- **Clean Architecture Implementation:** Strict separation of concerns across Domain, Application, Infrastructure, and Presentation layers.
- **Microservice-ready Structure:** Backend APIs and Frontend MVC are separated into distinct projects, communicating via HTTP Client.
- **Robust Security:** JWT-based authentication combined with BCrypt password hashing and custom HTTP handlers for token management.
- **Enterprise Patterns:** Extensive use of Repository Pattern, Unit of Work, Dependency Injection, and custom global Exception Middleware.
- **Data Integrity:** Seamless data validation using FluentValidation and object mapping using AutoMapper.

## Core Features
| Feature | Details |
| --- | --- |
| 🧑‍🎓 Student Management | CRUD operations for student records, enrollment, and profiles |
| 🏫 Department Management | Organize and manage university departments and their structures |
| 🔐 Authentication & Security | Login, JWT generation, token attachment via middleware, BCrypt hashing |
| 🛡️ Role-Based Access Control | Assign and manage system roles and user permissions |
| 🌐 API Documentation | Built-in Swagger UI for easy API testing and integration |

## Tech Stack
| Layer | Technology |
| --- | --- |
| **Backend API** | C#, .NET 8, ASP.NET Core Web API |
| **Frontend View** | ASP.NET Core MVC, HTML, CSS, Bootstrap |
| **Database** | Microsoft SQL Server |
| **ORM** | Entity Framework Core 8 |
| **Security** | JWT (JSON Web Tokens), BCrypt.Net-Next |
| **Utilities** | AutoMapper, FluentValidation |

## Project Structure
```text
StudentManagement/
├── StudentManagement.API/           # Presentation Layer: RESTful APIs, Swagger, Middleware
├── StudentManagement.Application/   # Application Layer: DTOs, Interfaces, Mappings, Validators
├── StudentManagement.Domain/        # Domain Layer: Entities, Enums, Exceptions
├── StudentManagement.Infrastructure/# Infrastructure Layer: EF Core DbContext, Repositories, Migrations
└── StudentManagement.MVC/           # Presentation Layer: Frontend web application, Controllers, Views, API Services
```
## Run Locally
**Prerequisites:** .NET 8 SDK, SQL Server
1. **Clone the repository**
```bash
git clone https://github.com/your-username/student-management-clean-architecture.git
cd student-management-clean-architecture
```
2. **Configure Database Connection**
Open `StudentManagement.API/appsettings.json` and update the `DefaultConnection` string with your SQL Server credentials:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=StudentManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
```
3. **Apply Database Migrations**
Open your terminal in the `StudentManagement.API` directory and run:
```bash
dotnet ef database update --project ../StudentManagement.Infrastructure
```
4. **Run the Application**
Since this system has separated the API and MVC layers, you need to run both projects simultaneously.
**Terminal 1 (Run API):**
```bash
cd StudentManagement.API
dotnet run
```
*API will run on `https://localhost:7181`*
**Terminal 2 (Run MVC):**
```bash
cd StudentManagement.MVC
dotnet run
```
5. **Access the Application**
- **Web UI:** Open `https://localhost:7091` (or `http://localhost:5013`)
- **API Swagger:** Open `https://localhost:7181/swagger`
## Contact
📧 **Email: thesonpham28@gmail.com
🐙 **GitHub:** https://github.com/PtSon2204
# StudentManagement_CleanArchitecture
