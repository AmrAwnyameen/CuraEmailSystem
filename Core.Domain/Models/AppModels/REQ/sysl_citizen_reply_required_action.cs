namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.sysl_citizen_reply_required_action")]
    public partial class sysl_citizen_reply_required_action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sysl_citizen_reply_required_action()
        {
            citizen_reply_details = new HashSet<citizen_reply_details>();
        }

        public decimal id { get; set; }

        [StringLength(4)]
        public string CODE { get; set; }

        [Required]
        [StringLength(100)]
        public string ENAME { get; set; }

        [Required]
        [StringLength(100)]
        public string ANAME { get; set; }

        [StringLength(255)]
        public string edescription { get; set; }

        [StringLength(255)]
        public string adescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        public decimal ORDERBY { get; set; }

        public decimal? app_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citizen_reply_details> citizen_reply_details { get; set; }
    }
}
