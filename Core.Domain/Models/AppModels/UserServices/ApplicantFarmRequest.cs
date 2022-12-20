using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Headers;
using Infrastructure.Helpers.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.UserServices
{
    [Table("ApplicantFarmRequest", Schema = "DIG")]
    public class ApplicantFarmRequest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Requests")]
        public decimal RequestId { get; set; }

        [ForeignKey("GGHeader")]
        public int? HeaderId { get; set; }

        public DateTime? CreationDate { get; set; }


        [ForeignKey("UserFarms")]
        public int UserFarmId { get; set; }

        public virtual UserFarms UserFarms  { get; set; }

        public virtual GGHeader GGHeader { get; set; }

        public virtual  requests Requests { get; set; }
        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;



    }
}
