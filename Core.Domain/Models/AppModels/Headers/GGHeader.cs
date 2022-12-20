using Core.Domain.Models.AppModels.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Headers
{
    [Table("GGHeader", Schema = "DIG")]
    public class GGHeader
    {
        public GGHeader()
        {
            this.ApplicantFarmRequest = new HashSet<ApplicantFarmRequest>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CorrelationId { get; set; }
        [Required]
        public int OriginatingChannel { get; set; }
        public string channelRequestId { get; set; }
        public int OriginatingUserType { get; set; }
        public string OriginatingUserIdentifier { get; set; }
        public int ServiceEntityId { get; set; }
        [Required]
        public string ServiceSlug { get; set; }

        public DateTime? CreationDate { get; set; }
        [ForeignKey("Request")]
        public decimal? RequestId { get; set; }
        public requests  Request { get; set; }
        public int? F_MIG { get; set; }

        public ICollection<ApplicantFarmRequest> ApplicantFarmRequest { get; set; }

    }
}
