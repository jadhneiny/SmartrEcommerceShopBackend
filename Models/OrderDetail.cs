using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_ORDER_DETAILS
    {
        [Key]
        [Column("ORDER_DETAIL_ID")]
        public int ORDER_DETAIL_ID { get; set; }

        [Column("ORDER_ID")]
        public int ORDER_ID { get; set; }

        [Column("PRODUCT_ID")]
        public int PRODUCT_ID { get; set; }

        [Column("QUANTITY")]
        public int QUANTITY { get; set; }

        [Column("PRICE")]
        public decimal PRICE { get; set; }

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;

        [ForeignKey(nameof(ORDER_ID))]
        public virtual TBL_ORDERS Order { get; set; } = null!;

        [ForeignKey(nameof(PRODUCT_ID))]
        public virtual TBL_PRODUCTS Product { get; set; } = null!;
    }
}
