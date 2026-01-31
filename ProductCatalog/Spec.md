# MVC CRUD Demo — Product Catalog (LocalDB)

## Goal
Build a thin ASP.NET Core MVC app that demonstrates classic MVC CRUD with EF Core + LocalDB:
- Index / Details / Create / Edit / Delete
- Server-side validation + PRG pattern
- Basic error handling (NotFound/BadRequest) + status code pages (recap)

## Tech stack
- .NET 8, ASP.NET Core MVC (Razor Views)
- EF Core 8 + SQL Server provider
- LocalDB (MSSQLLocalDB)
- Visual Studio 2022 workflow (Package Manager Console for migrations)

## Domain model
Entity: Product
- Id: int (PK, identity)
- Name: string (required, max 80)
- Price: decimal (range 0.01..1,000,000)
- Category: string? (optional, max 40)

Validation:
- DataAnnotations on the model
- Views show validation summary and per-field messages

## Data access
DbContext: AppDbContext
- DbSet<Product> Products

Database:
- LocalDB database name: `MvcCrudDemoDb`
- Migration-based schema creation (`Add-Migration`, `Update-Database`)

## UI / Views
Controller: ProductsController
Views folder: Views/Products/
- Index.cshtml: table list + links (Details/Edit/Delete) + link (Create)
- Details.cshtml: read-only page + Back link
- Create.cshtml: form with validation + submit
- Edit.cshtml: form prefilled + submit
- Delete.cshtml: confirm page + POST submit

UI constraints:
- Minimal default layout, no custom CSS/JS required
- Use Tag Helpers (`asp-action`, `asp-route-id`, `asp-for`, etc.)

## Routing
Conventional routing:
- /Products
- /Products/Details/5
- /Products/Create
- /Products/Edit/5
- /Products/Delete/5

## Controller behavior
- All GET actions return a View with a model
- All POST actions:
  - validate ModelState
  - on success: save changes and RedirectToAction (PRG)
  - on failure: return same View(model)
- NotFound (404) when entity is missing by id
- BadRequest (400) for invalid id (<= 0) where appropriate

## Security baseline
- Use AntiForgeryToken on all POST actions
- Razor form helpers auto-emit antiforgery token when using `<form asp-action="...">`

## Error handling recap
- Enable status code pages re-execute:
  - app.UseStatusCodePagesWithReExecute("/Error/{0}");
- ErrorController:
  - /Error/{code} returns views for 404 and 400 (minimum)
- Keep dev exception page vs production exception handler

## Out of scope (to keep it 1 day)
- Auth/roles
- Paging/sorting/search
- Relationships, repositories, unit tests
- Docker compose and deployment (future upgrade)
