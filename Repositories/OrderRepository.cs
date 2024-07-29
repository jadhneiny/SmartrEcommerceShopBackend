using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class OrderRepository : IRepository<TBL_ORDERS>
    {
        private readonly DapperContext _context;

        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_ORDERS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetOrdersByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_ORDERS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_ORDERS> GetByIdAsync(int id)
        {
            var query = "EXEC GetOrderByID @OrderID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_ORDERS>(query, new { OrderID = id });
            }
        }

        public async Task<int> AddAsync(TBL_ORDERS order)
        {
            var query = "EXEC AddOrder @CustomerID, @OrderDate, @Status, @PromoCodeID, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, order);
            }
        }

        public async Task<int> UpdateAsync(TBL_ORDERS order)
        {
            var query = "EXEC UpdateOrder @OrderID, @CustomerID, @OrderDate, @Status, @PromoCodeID, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, order);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteOrder @OrderID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { OrderID = id });
            }
        }
    }
}
