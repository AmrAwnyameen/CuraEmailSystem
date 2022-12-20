namespace Core.Domain.Models.AppModels
{
    using Core.Domain.Models.AppModels.SiteInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("req.sysl_service_channel")]
    public partial class sysl_service_channel
    {
        public sysl_service_channel()
        {
            this.Sites = new HashSet<Site>();
            this.Requests = new HashSet<requests>();
        }
        public decimal id { get; set; }

        [Required]
        [StringLength(2)]
        public string code { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; }
        public ICollection<Site> Sites { get; set; }
        public ICollection<requests> Requests { get; set; }


    }
}
