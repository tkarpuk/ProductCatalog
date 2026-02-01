using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class InMemoryRepository : IRepository<Product>
    {
        private List<Product> _products = new() {
            new() { Id = 1, Name = "Wireless Mouse", Price = 29.99m, Category = "Electronics" },
            new() { Id = 2, Name = "Mechanical Keyboard", Price = 119.00m, Category = "Electronics" },
            new() { Id = 3, Name = "Office Chair", Price = 249.50m, Category = "Furniture" },
            new() { Id = 4, Name = "Notebook A5", Price = 4.99m, Category = "Stationery" },
            new() { Id = 5, Name = "Coffee Mug", Price = 12.75m, Category = "Kitchen" }
        };

        public Task<List<Product>> GetAllAsync() => Task.FromResult(_products.ToList());

        public Task<Product?> GetByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

        public Task<int> CreateAsync(Product item)
        {
            var id = _products.MaxBy(p => p.Id)?.Id ?? 0;
            item.Id = ++id;

            _products.Add(item);

            return Task.FromResult(item.Id);
        }

        public Task DeleteAsync(int id) 
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return Task.CompletedTask;

            _products.Remove(product);

            return Task.CompletedTask; 
        }

        public Task UpdateAsync(Product item)
        {
            var product = _products.FirstOrDefault(p => p.Id == item.Id);
            if (product is null)
                return Task.CompletedTask;

            product.Name = item.Name;
            product.Price = item.Price;
            product.Category = item.Category;

            return Task.CompletedTask;
        }
    }
}
