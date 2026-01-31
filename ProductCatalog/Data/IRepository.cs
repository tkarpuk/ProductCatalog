namespace ProductCatalog.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
