using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.AppModels.Company
{
    public class Comapny
    {
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
        [Required]
        public string RequestPartyEmail { get; set; }



    }
}
