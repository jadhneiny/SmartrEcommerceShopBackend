using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class ProductRepository : IRepository<TBL_PRODUCTS>
    {
        private readonly DapperContext _context;

        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_PRODUCTS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetProductsByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_PRODUCTS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_PRODUCTS> GetByIdAsync(int id)
        {
            var query = "EXEC GetProductByID @ProductID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_PRODUCTS>(query, new { ProductID = id });
            }
        }

        public async Task<int> AddAsync(TBL_PRODUCTS product)
        {
            var query = "EXEC AddProduct @Name, @Description, @Price, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, product);
            }
        }

        public async Task<int> UpdateAsync(TBL_PRODUCTS product)
        {
            var query = "EXEC UpdateProduct @ProductID, @Name, @Description, @Price, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, product);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteProduct @ProductID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { ProductID = id });
            }
        }
    }
}
