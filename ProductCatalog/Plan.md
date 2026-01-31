## Implementation plan

### A. Startup

1. Create MVC project (.NET 8, no auth)
2. Clean UI 
3. Add `Product` model with DataAnnotations
4. Add EF Core packages (SqlServer + Tools) and create `AppDbContext` + `DbSet<Product>`
5. Add LocalDB connection string + register DbContext in `Program.cs`
6. Create DB via migrations (`Add-Migration`, `Update-Database`)

### B. CRUD controller

1. Add `ProductsController` with injected `AppDbContext`
2. Implement `Index` (GET) list all products
3. Implement `Details` (GET) by id + NotFound
4. Implement `Create` (GET) show form
5. Implement `Create` (POST) validate + add + PRG redirect
6. Implement `Edit` (GET) load + NotFound
7. Implement `Edit` (POST) validate + update + PRG redirect
8. Implement `Delete` (GET) confirm + NotFound
9. Implement `DeleteConfirmed` (POST) remove + PRG redirect

### C. Views

1. Create `Views/Products/Index.cshtml` (table + links)
2. Create `Views/Products/Details.cshtml` (read-only)
3. Create `Views/Products/Create.cshtml` (form + validation)
4. Create `Views/Products/Edit.cshtml` (form + validation)
5. Create `Views/Products/Delete.cshtml` (confirm + POST)

### D. Error handling recap

1. Add `ErrorController` with `Error(int code)` action
2. Add views: `Views/Error/NotFound.cshtml`, `Views/Error/BadRequest.cshtml`
3. Enable `UseStatusCodePagesWithReExecute("/Error/{0}")`
4. Quick test: hit `/Products/Details/9999` and invalid id routes

### E. Polish (only if time remains)

1. Seed a few products on startup (dev-only)
2. Add small UX touches (Back links, headings)
3. Quick manual test checklist for all flows