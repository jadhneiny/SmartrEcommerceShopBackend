using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_ADDRESSES
    {
        [Key]
        [Column("ADDRESS_ID")]
        public int ADDRESS_ID { get; set; }

        [Column("CUSTOMER_ID")]
        public int CUSTOMER_ID { get; set; }

        [StringLength(255)]
        [Column("STREET")]
        public string STREET { get; set; } = null!;

        [StringLength(100)]
        [Column("CITY")]
        public string CITY { get; set; } = null!;

        [StringLength(100)]
        [Column("STATE")]
        public string STATE { get; set; } = null!;

        [StringLength(20)]
        [Column("ZIPCODE")]
        public string ZIPCODE { get; set; } = null!;

        [StringLength(100)]
        [Column("COUNTRY")]
        public string COUNTRY { get; set; } = null!;

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;

        [ForeignKey(nameof(CUSTOMER_ID))]
        public virtual TBL_CUSTOMERS Customer { get; set; } = null!;
    }
}
