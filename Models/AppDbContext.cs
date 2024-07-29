using Microsoft.EntityFrameworkCore;

namespace ShopManagementBackend.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TBL_ADMINS> TBL_ADMINS { get; set; }
        public DbSet<TBL_CUSTOMERS> TBL_CUSTOMERS { get; set; }
        public DbSet<TBL_ADDRESSES> TBL_ADDRESSES { get; set; }
        public DbSet<TBL_SHOPS> TBL_SHOPS { get; set; }
        public DbSet<TBL_PRODUCTS> TBL_PRODUCTS { get; set; }
        public DbSet<TBL_ORDERS> TBL_ORDERS { get; set; }
        public DbSet<TBL_ORDER_DETAILS> TBL_ORDER_DETAILS { get; set; }
        public DbSet<TBL_PROMO_CODES> TBL_PROMO_CODES { get; set; }
        public DbSet<TBL_TENANTS> TBL_TENANTS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
