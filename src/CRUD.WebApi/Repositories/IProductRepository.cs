using CRUD.WebApi.Models;

namespace CRUD.WebApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<int> CreateAsync(Product product);

        Task<bool> UpdateAsync(int id, Product product);

        Task<bool> DeleteAsync(int id);

    }
}
