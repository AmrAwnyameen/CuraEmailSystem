using Core.Domain.Models.AppModels.Complains;
using Core.Domain.Models.AppModels.UserServices;
using Infrastructure.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.SiteInfo
{
    [Table("Sites",Schema ="cms")]
    public class Site
    {
        public Site()
        {
            this.UserFarms = new HashSet<UserFarms>();
            this.Requests = new HashSet<requests>();
        }
      
        [Key]
        public decimal Id { get; set; }
        [Required]
        [StringLength(200)]
        public string NAME { get; set; }
        [Required]
        public decimal NATIONAL_NO { get; set; }

        [Required]
        [StringLength(30)]
        public string MO_PHONE_NO { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [ForeignKey("l_government")]
        public int LKUP_GOVERNMENT_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string ADDRESS { get; set; }

        public DateTime? DATEMODIFIED { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public decimal LKUP_SITE_TYPE_ID { get; set; } = (int)SiteType.DigEgyptUser;

        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;

        public l_government l_government { get; set; }

        [ForeignKey("sysl_Service_Channel")]
        [DefaultValue(3)]
        public decimal? ChannelId { get; set; } = (int)ChannelCodes.DigitalEgypt;
        public sysl_service_channel sysl_Service_Channel { get; set; }

        [NotMapped]
        public string ServiceCode { get; set; }



        #region EntityMapping
        public ICollection<UserFarms> UserFarms { get; set; }
        public ICollection<requests> Requests { get; set; }
        public ICollection<Complaint> Complaints { get; set; }

        #endregion
    }
}
