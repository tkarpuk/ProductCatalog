using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _repo;

        public ProductController(IRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _repo.GetByIdAsync(id);
            return product is null 
                ? NotFound() 
                : View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _repo.GetByIdAsync(id);
            return product is null
                ? NotFound()
                : View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = await _repo.GetByIdAsync(id);
            return product is null
                ? NotFound()
                : View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            await _repo.UpdateAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
