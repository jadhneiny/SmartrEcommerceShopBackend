using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_SHOPS
    {
        [Key]
        [Column("SHOP_ID")]
        public int SHOP_ID { get; set; }

        [StringLength(100)]
        [Column("NAME")]
        public string NAME { get; set; } = null!;

        [StringLength(10)]
        [Column("CURRENCY")]
        public string CURRENCY { get; set; } = null!;

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;
    }
}
