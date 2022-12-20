using Infrastructure.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.CompanyInfo
{
    [Table("Company",Schema = "DIG")]
    public class Company
    {
        public Company()
        {
            //this.ApplicantFarmRequest = new HashSet<ApplicantFarmRequest>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string RequestPartyName { get; set; }
        [Required]
        public string DetailedAddress { get; set; }
        [Required]
        public string ActivityType { get; set; }
        [Required]
        public string CommercialRegistrationNo { get; set; }
    
        public string RequestPartyEmail { get; set; }


        [ForeignKey("Requests")]
        public decimal RequestId { get; set; }

        public virtual requests Requests { get; set; }


        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;

    }
}
