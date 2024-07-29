using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class OrderDetailRepository : IRepository<TBL_ORDER_DETAILS>
    {
        private readonly DapperContext _context;

        public OrderDetailRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_ORDER_DETAILS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetOrderDetailsByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_ORDER_DETAILS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_ORDER_DETAILS> GetByIdAsync(int id)
        {
            var query = "EXEC GetOrderDetailByID @OrderDetailID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_ORDER_DETAILS>(query, new { OrderDetailID = id });
            }
        }

        public async Task<int> AddAsync(TBL_ORDER_DETAILS orderDetail)
        {
            var query = "EXEC AddOrderDetail @OrderID, @ProductID, @Quantity, @Price, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, orderDetail);
            }
        }

        public async Task<int> UpdateAsync(TBL_ORDER_DETAILS orderDetail)
        {
            var query = "EXEC UpdateOrderDetail @OrderDetailID, @OrderID, @ProductID, @Quantity, @Price, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, orderDetail);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteOrderDetail @OrderDetailID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { OrderDetailID = id });
            }
        }
    }
}
