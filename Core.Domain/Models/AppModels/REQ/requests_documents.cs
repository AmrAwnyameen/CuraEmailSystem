namespace Core.Domain.Models.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.requests_documents")]
    public partial class requests_documents
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Required]
        [StringLength(40)]
        public string GUID { get; set; }

        public decimal DOC_TYPE { get; set; }

        public DateTime DATEMODIFIED { get; set; }

        public decimal MODIFIEDBY { get; set; }

        public decimal corr_id { get; set; }

        [Required]
        [StringLength(150)]
        public string FILE_NAME { get; set; }

        [StringLength(350)]
        public string FILE_PATH { get; set; }

        public bool? IsDeleted { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_COMPLETE_FILE { get; set; }

        public decimal F_ROUTED { get; set; }

        public DateTime? ROUTE_DATE { get; set; }
    }
}
