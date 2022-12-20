namespace Core.Domain.Models.AppModels
{
    using Core.Domain.Models.AppModels.Payment.CategoryFeez;
    using Core.Domain.Models.AppModels.SlugsInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms.l_category")]
    public partial class l_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public l_category()
        {
            L_category_documents_types = new HashSet<L_category_documents_types>();
            l_category1 = new HashSet<l_category>();
            requests = new HashSet<requests>();
            ServiceCategoryFees = new HashSet<ServiceCategoryFees>();
        }

        public decimal id { get; set; }

        [StringLength(4)]
        public string CODE { get; set; }

        public decimal? CATEGORY_PARENT_ID { get; set; }

        [StringLength(250)]
        public string ENAME { get; set; }

        [StringLength(250)]
        public string ANAME { get; set; }

        [StringLength(255)]
        public string EDESCRIPTION { get; set; }

        [StringLength(255)]
        public string ADESCRIPTION { get; set; }

        public decimal? ORDERBY { get; set; }

        public decimal? ISDELETED { get; set; }

        public decimal? WORKFLOW_TYPE_ID { get; set; }

        public decimal? REPLYDAYS { get; set; }

        public decimal f_service { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }

        public decimal? f_delete { get; set; }

        public decimal? category_application_id { get; set; }

        public DateTime? DATEMODIFIED { get; set; }

        public long? MODIFIEDBY { get; set; }

        public decimal F_PUBLISH { get; set; }

        public string WeeklyDays { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public int? Limitaion { get; set; }

        public int? LimitationPerCompany { get; set; }

        [StringLength(250)]
        public string Report_ProcedureName { get; set; }

        public decimal? EXCPECTED_DONE_DAYS { get; set; }

        public decimal? VacancyPermission { get; set; }

        public bool? IsPaid { get; set; }

        public string CategoryImagePath { get; set; }

        public ICollection<Slug> Slugs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<L_category_documents_types> L_category_documents_types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l_category> l_category1 { get; set; }

        public virtual l_category l_category2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requests> requests { get; set; }

        public virtual ICollection<ServiceCategoryFees> ServiceCategoryFees { get; set; }


    }
}
