using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_ORDERS
    {
        [Key]
        [Column("ORDER_ID")]
        public int ORDER_ID { get; set; }

        [Column("CUSTOMER_ID")]
        public int CUSTOMER_ID { get; set; }

        [Column("ORDER_DATE")]
        public DateTime? ORDER_DATE { get; set; }

        [StringLength(50)]
        [Column("STATUS")]
        public string STATUS { get; set; } = null!;

        [Column("PROMO_CODE_ID")]
        public int? PROMO_CODE_ID { get; set; }

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;

        [ForeignKey(nameof(CUSTOMER_ID))]
        public virtual TBL_CUSTOMERS Customer { get; set; } = null!;

        [ForeignKey(nameof(PROMO_CODE_ID))]
        public virtual TBL_PROMO_CODES? PromoCode { get; set; }

        public virtual ICollection<TBL_ORDER_DETAILS> TBL_ORDER_DETAILS { get; set; } = new List<TBL_ORDER_DETAILS>();
    }
}
