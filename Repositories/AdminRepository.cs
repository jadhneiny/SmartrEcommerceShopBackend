using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ShopManagementBackend.Repositories
{
    public class AdminRepository : IUserRepository<TBL_ADMINS>
    {
        private readonly DapperContext _context;

        public AdminRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_ADMINS>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetAdminByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_ADMINS>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_ADMINS> GetByIdAsync(int id)
        {
            var query = "EXEC GetAdminByID @AdminID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_ADMINS>(query, new { ADMIN_ID = id });
            }
        }

        public async Task<TBL_ADMINS> GetByUsernameAsync(string username)
        {
            var query = "EXEC GetAdminByUsername @Username";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_ADMINS>(query, new { Username = username });
            }
        }

        public async Task<int> AddAsync(TBL_ADMINS admin)
        {
            // Hash the password before saving
            admin.PASSWORD = BCrypt.Net.BCrypt.HashPassword(admin.PASSWORD);

            var query = "EXEC AddAdmin @Name, @Username, @Email, @Password, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, admin);
            }
        }

        public async Task<int> UpdateAsync(TBL_ADMINS admin)
        {
            if (!string.IsNullOrEmpty(admin.PASSWORD))
            {
                admin.PASSWORD = BCrypt.Net.BCrypt.HashPassword(admin.PASSWORD);
            }
            else
            {
                // Fetch the existing password if it's not provided
                var existingAdmin = await GetByIdAsync(admin.ADMIN_ID);
                admin.PASSWORD = existingAdmin.PASSWORD;
            }

            var query = "EXEC UpdateAdmin @AdminID, @Name, @Username, @Email, @Password, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, admin);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteAdmin @AdminID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { ADMIN_ID = id });
            }
        }
    }
}
