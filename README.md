# Employee Project Tracker API

## 📌 Overview
The **Employee Project Tracker API** is a RESTful API built with **ASP.NET Core** to manage employees and their assigned projects efficiently.  
It follows a **Repository Pattern** and supports **CRUD operations** for both Employees and Projects, making it easy to integrate into various enterprise-level applications.

---

## ✨ Features
- 📋 **Employee Management** – Add, view, update, and delete employee records.
- 🛠 **Project Management** – Add, view, update, and delete project records.
- 🔗 **Repository Pattern** – Clean separation between data access and business logic.
- ⚡ **Asynchronous Methods** – Better scalability and performance.
- 🌐 **RESTful API Endpoints** – Easy to consume from frontend apps.
- 🧩 **Dependency Injection** – Service registrations in `Program.cs`.
- 🛡 **JSON Serialization Settings** – Configured to handle circular references using `ReferenceHandler.IgnoreCycles`.

---

## 🏗 Technologies Used
- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server**
- **Repository Pattern**
- **Newtonsoft.Json**

---

## 🔌 API Endpoints

### Employee Endpoints
| Method | Endpoint                  | Description              |
|--------|---------------------------|--------------------------|
| GET    | `/api/employee`           | Get all employees        |
| GET    | `/api/employee/{id}`      | Get employee by ID       |
| POST   | `/api/employee`           | Add new employee         |
| PUT    | `/api/employee/{id}`      | Update employee          |
| DELETE | `/api/employee/{id}`      | Delete employee          |

### Project Endpoints
| Method | Endpoint                  | Description              |
|--------|---------------------------|--------------------------|
| GET    | `/api/project`            | Get all projects         |
| GET    | `/api/project/{id}`       | Get project by ID        |
| POST   | `/api/project`            | Add new project          |
| PUT    | `/api/project/{id}`       | Update project           |
| DELETE | `/api/project/{id}`       | Delete project           |


