namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.sysl_request_status")]
    public partial class sysl_request_status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysl_request_status()
        {
            requests = new HashSet<requests>();
        }

        public decimal id { get; set; }

        [Required]
        [StringLength(15)]
        public string code { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        [StringLength(100)]
        public string portal_adescription { get; set; }

        [StringLength(100)]
        public string portal_edescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requests> requests { get; set; }
    }
}
