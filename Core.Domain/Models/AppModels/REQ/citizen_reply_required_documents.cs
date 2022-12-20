namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.citizen_reply_required_documents")]
    public partial class citizen_reply_required_documents
    {
        public decimal id { get; set; }

        public decimal CITIZEN_REPLY_DETAILS_ID { get; set; }

        public decimal l_document_type_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        public decimal? requestDocumentId { get; set; }

        [StringLength(40)]
        public string GUID { get; set; }

        public virtual l_document_type l_document_type { get; set; }

        public virtual citizen_reply_details citizen_reply_details { get; set; }
    }
}
