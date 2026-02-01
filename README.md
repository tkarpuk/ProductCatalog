# ProductCatalog — ASP.NET Core MVC CRUD Demo

This project is a simple **ASP.NET Core MVC** application that demonstrates classic **CRUD operations**, **server-side validation**, 
and **centralized error handling** using a clean and readable MVC approach.

The goal of the project is to showcase how quickly and clearly a data-driven
web application can be implemented with MVC — without unnecessary complexity.

---

## Tech Stack

- **.NET 8**
- **ASP.NET Core MVC (Razor Views)**
- **In-memory repository** (with async API, EF-ready design)

---

## Features

- Full CRUD for `Product`
  - Index (list)
  - Details
  - Create
  - Edit
  - Delete (with confirmation)
- Server-side validation using Data Annotations
- PRG pattern (Post => Redirect => Get)
- Anti-forgery protection on POST actions
- Centralized error handling via `/Error/{code}`
  - Custom pages for `404` and `400`
- Clean navigation using MVC Tag Helpers

---

## How to Run

Just download, open in VS and F5. No database or additional setup is required.

---

## Notes

- The repository layer is intentionally abstracted to allow easy replacement with EF Core and a real database in the future.
- The project focuses on **clarity and correctness**, not UI polish.
- Created as a learning project to practice ASP.NET Core MVC fundamentals.
