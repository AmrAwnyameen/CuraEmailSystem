namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOC.l_document_type")]
    public partial class l_document_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public l_document_type()
        {
            L_category_documents_types = new HashSet<L_category_documents_types>();
            citizen_reply_required_documents = new HashSet<citizen_reply_required_documents>();
        }

        public decimal id { get; set; }

        [StringLength(4)]
        public string CODE { get; set; }

        [StringLength(150)]
        public string DOCTYPENAME { get; set; }

        [StringLength(255)]
        public string DESCRIPTION { get; set; }

        public DateTime? DATEMODIFIED { get; set; }

        public long? MODIFIEDBY { get; set; }

        public decimal? F_ACTIVE { get; set; }

        public decimal L_DOC_CLASSIFICATION_ID { get; set; }


         public int? F_MIG { get; set; }

        public decimal? f_delete { get; set; }

        public int? MaxSize { get; set; }

        [StringLength(50)]
        public string DocumentType { get; set; }

        [StringLength(150)]
        public string EDOCTYPENAME { get; set; }

        [StringLength(255)]
        public string EDESCRIPTION { get; set; }

        public decimal? is_sys_val { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<L_category_documents_types> L_category_documents_types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citizen_reply_required_documents> citizen_reply_required_documents { get; set; }
    }
}
