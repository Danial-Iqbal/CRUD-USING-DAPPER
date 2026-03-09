using CRUD.WebApi.Data;
using CRUD.WebApi.Models;
using Dapper;

namespace CRUD.WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dbContext;

        public ProductRepository(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Product product)
        {
            var query = @"INSERT INTO PRODUCTS (Name, Description, Price)
                          VALUES (@Name, @Description, @Price);
                          SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _dbContext.CreateConnection();

            var id = await connection.ExecuteScalarAsync<int>(query, product);

            return id;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = @"SELECT Id,
                                 Name,
                                 Description, 
                                 Price     
                          FROM Products
                          ORDER BY Id DESC
                         ";

            using var connection = _dbContext.CreateConnection();

            var products = await connection.QueryAsync<Product>(query);

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var query = @"SELECT Id,
                                 Name,
                                 Description,
                                 Price
                          FROM Products
                          WHERE Id = @Id";

            using var connection = _dbContext.CreateConnection();

            var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });

            return product;
        }

        public Task<bool> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
