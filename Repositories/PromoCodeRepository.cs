using Dapper;
using ShopManagementBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopManagementBackend.Repositories
{
    public class PromoCodeRepository : IRepository<TBL_PROMO_CODES>
    {
        private readonly DapperContext _context;

        public PromoCodeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TBL_PROMO_CODES>> GetAllAsync(int tenantId)
        {
            var query = "EXEC GetPromoCodesByTenantID @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<TBL_PROMO_CODES>(query, new { TenantID = tenantId });
            }
        }

        public async Task<TBL_PROMO_CODES> GetByIdAsync(int id)
        {
            var query = "EXEC GetPromoCodeByID @PromoCodeID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<TBL_PROMO_CODES>(query, new { PromoCodeID = id });
            }
        }

        public async Task<int> AddAsync(TBL_PROMO_CODES promoCode)
        {
            var query = "EXEC AddPromoCode @Code, @Discount, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, promoCode);
            }
        }

        public async Task<int> UpdateAsync(TBL_PROMO_CODES promoCode)
        {
            var query = "EXEC UpdatePromoCode @PromoCodeID, @Code, @Discount, @CreatedAt, @TenantID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, promoCode);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "EXEC DeletePromoCode @PromoCodeID";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { PromoCodeID = id });
            }
        }
    }
}
