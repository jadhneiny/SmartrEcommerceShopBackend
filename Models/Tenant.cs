using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public class TBL_TENANTS
    {
        [Key]
        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [StringLength(100)]
        [Column("NAME")]
        public string NAME { get; set; } = null!;

        public virtual ICollection<TBL_ADMINS> TBL_ADMINS { get; set; } = new List<TBL_ADMINS>();
        public virtual ICollection<TBL_CUSTOMERS> TBL_CUSTOMERS { get; set; } = new List<TBL_CUSTOMERS>();
        public virtual ICollection<TBL_ADDRESSES> TBL_ADDRESSES { get; set; } = new List<TBL_ADDRESSES>();
        public virtual ICollection<TBL_SHOPS> TBL_SHOPS { get; set; } = new List<TBL_SHOPS>();
        public virtual ICollection<TBL_PRODUCTS> TBL_PRODUCTS { get; set; } = new List<TBL_PRODUCTS>();
        public virtual ICollection<TBL_ORDERS> TBL_ORDERS { get; set; } = new List<TBL_ORDERS>();
        public virtual ICollection<TBL_ORDER_DETAILS> TBL_ORDER_DETAILS { get; set; } = new List<TBL_ORDER_DETAILS>();
        public virtual ICollection<TBL_PROMO_CODES> TBL_PROMO_CODES { get; set; } = new List<TBL_PROMO_CODES>();
    }
}
