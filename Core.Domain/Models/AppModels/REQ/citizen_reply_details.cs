namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.citizen_reply_details")]
    public partial class citizen_reply_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public citizen_reply_details()
        {
            citizen_reply_required_documents = new HashSet<citizen_reply_required_documents>();
            requests1 = new HashSet<requests>();
        }

        public decimal id { get; set; }

        [StringLength(4000)]
        public string required_comment { get; set; }

        public DateTime? attendence_date { get; set; }

        public decimal? attendence_region_id { get; set; }

        public decimal? route_id { get; set; }

        public decimal? corr_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        public decimal? request_id { get; set; }

        public decimal? CITIZEN_REPLY_REQUIRED_ACTION_ID { get; set; }

        public decimal? required_action_id { get; set; }

        public decimal? Company_IDFK { get; set; }

        public decimal? User_IDFK { get; set; }

        public decimal? Status_IDFK { get; set; }

        public DateTime? RequestReplayDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public decimal? PaymentAmount { get; set; }

        public virtual requests requests { get; set; }

        public virtual sysl_citizen_reply_required_action sysl_citizen_reply_required_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citizen_reply_required_documents> citizen_reply_required_documents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requests> requests1 { get; set; }
    }
}
