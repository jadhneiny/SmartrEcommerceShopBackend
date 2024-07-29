using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_PROMO_CODES
    {
        [Key]
        [Column("PROMO_CODE_ID")]
        public int PROMO_CODE_ID { get; set; }

        [StringLength(50)]
        [Column("CODE")]
        public string CODE { get; set; } = null!;

        [Column("DISCOUNT")]
        public decimal DISCOUNT { get; set; }

        [Column("EXPIRATION_DATE")]
        public DateTime? EXPIRATION_DATE { get; set; }

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;

        public virtual ICollection<TBL_ORDERS> TBL_ORDERS { get; set; } = new List<TBL_ORDERS>();
    }
}
