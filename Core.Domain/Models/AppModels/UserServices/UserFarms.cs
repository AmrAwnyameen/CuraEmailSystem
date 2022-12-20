using Core.Domain.Context;
using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.AppModels.SiteInfo;
using Infrastructure.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.UserServices
{
    [Table("UserFarms", Schema = "DIG")]
    public class UserFarms
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public decimal UserId { get; set; }
        public virtual Site User { get; set; }

        [ForeignKey("FarmInformation")]
        public int FarmId { get; set; }

         public int? F_MIG { get; set; }

        public virtual FarmInformation FarmInformation { get; set; }

    }
}
