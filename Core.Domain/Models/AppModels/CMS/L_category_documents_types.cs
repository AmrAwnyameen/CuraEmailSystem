namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms.L_category_documents_types")]
    public partial class L_category_documents_types
    {
        public decimal id { get; set; }

        [StringLength(4)]
        public string CODE { get; set; }

        public decimal l_category_id { get; set; }

        public decimal l_document_type_id { get; set; }

        public DateTime? DATEMODIFIED { get; set; }

        public long? MODIFIEDBY { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        public decimal? f_delete { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? f_required { get; set; }

        public decimal ORDERBY { get; set; }

        public virtual l_category l_category { get; set; }

        public virtual l_document_type l_document_type { get; set; }
    }
}
