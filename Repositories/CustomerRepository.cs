using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class CustomerRepository : IUserRepository<TBL_CUSTOMERS>
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_CUSTOMERS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetCustomersByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_CUSTOMERS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_CUSTOMERS> GetByIdAsync(int id)
        {
            var query = "EXEC GetCustomerByID @CustomerID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_CUSTOMERS>(query, new { CustomerID = id });
            }
        }

        public async Task<TBL_CUSTOMERS> GetByUsernameAsync(string username)
        {
            var query = "EXEC GetCustomerByUsername @Username";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_CUSTOMERS>(query, new { Username = username });
            }
        }

        public async Task<int> AddAsync(TBL_CUSTOMERS customer)
        {
            var query = "EXEC AddCustomer @Name, @Username, @Email, @Password, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, customer);
            }
        }

        public async Task<int> UpdateAsync(TBL_CUSTOMERS customer)
        {
            var query = "EXEC UpdateCustomer @CustomerID, @Name, @Username, @Email, @Password, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, customer);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteCustomer @CustomerID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { CustomerID = id });
            }
        }
    }
}
