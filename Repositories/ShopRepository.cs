using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class ShopRepository : IRepository<TBL_SHOPS>
    {
        private readonly DapperContext _context;

        public ShopRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_SHOPS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetShopsByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_SHOPS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_SHOPS> GetByIdAsync(int id)
        {
            var query = "EXEC GetShopByID @ShopID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_SHOPS>(query, new { ShopID = id });
            }
        }

        public async Task<int> AddAsync(TBL_SHOPS shop)
        {
            var query = "EXEC AddShop @Name, @Description, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, shop);
            }
        }

        public async Task<int> UpdateAsync(TBL_SHOPS shop)
        {
            var query = "EXEC UpdateShop @ShopID, @Name, @Description, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, shop);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteShop @ShopID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { ShopID = id });
            }
        }
    }
}
