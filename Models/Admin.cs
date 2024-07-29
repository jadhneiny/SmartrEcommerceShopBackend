using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagementBackend.Models
{
    public partial class TBL_ADMINS
    {
        [Key]
        [Column("ADMIN_ID")]
        public int ADMIN_ID { get; set; }

        [StringLength(100)]
        [Column("NAME")]
        public string NAME { get; set; } = null!;

        [StringLength(100)]
        [Column("USERNAME")]
        public string USERNAME { get; set; } = null!;

        [StringLength(100)]
        [Column("EMAIL")]
        public string EMAIL { get; set; } = null!;

        [StringLength(255)]
        [Column("PASSWORD")]
        public string PASSWORD { get; set; } = null!;

        [Column("CREATED_AT")]
        public DateTime? CREATED_AT { get; set; }

        [Column("TENANT_ID")]
        public int TENANT_ID { get; set; }

        [ForeignKey(nameof(TENANT_ID))]
        public virtual TBL_TENANTS Tenant { get; set; } = null!;
    }
}
