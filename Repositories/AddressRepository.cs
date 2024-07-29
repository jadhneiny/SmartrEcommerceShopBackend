using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class AddressRepository : IRepository<TBL_ADDRESSES>
    {
        private readonly DapperContext _context;

        public AddressRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_ADDRESSES>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetAddressesByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_ADDRESSES>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_ADDRESSES> GetByIdAsync(int id)
        {
            var query = "EXEC GetAddressByID @AddressID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_ADDRESSES>(query, new { AddressID = id });
            }
        }

        public async Task<int> AddAsync(TBL_ADDRESSES address)
        {
            var query = "EXEC AddAddress @Street, @City, @State, @PostalCode, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, address);
            }
        }

        public async Task<int> UpdateAsync(TBL_ADDRESSES address)
        {
            var query = "EXEC UpdateAddress @AddressID, @Street, @City, @State, @PostalCode, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, address);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeleteAddress @AddressID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { AddressID = id });
            }
        }
    }
}
