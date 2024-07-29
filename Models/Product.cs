using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_PRODUCTS
    {
        [Key]
        [Column("PRODUCT_ID")]
        public int PRODUCT_ID { get; set; }

        [Column("SHOP_ID")]
        public int SHOP_ID { get; set; }

        [StringLength(100)]
        [Column("PRODUCT_NAME")]
        public string PRODUCT_NAME { get; set; } = null!;

        [Column("PRICE")]
        public decimal PRICE { get; set; }

        [StringLength(255)]
        [Column("IMAGE")]
        public string IMAGE { get; set; } = null!;

        [Column("DESCRIPTION")]
        public string DESCRIPTION { get; set; } = null!;

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;

        [ForeignKey(nameof(SHOP_ID))]
        public virtual TBL_SHOPS Shop { get; set; } = null!;
    }
}
