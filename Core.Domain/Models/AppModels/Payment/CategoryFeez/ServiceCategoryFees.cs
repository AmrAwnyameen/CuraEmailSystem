using Core.Domain.Models.AppModels.Payment.FeesSettlement;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Payment.CategoryFeez
{
    [Table("ServiceCategoryFees", Schema = "DIG")]
    public class ServiceCategoryFees
    {
        public ServiceCategoryFees()
        {
            ServiceCategoryFeesSettlement = new HashSet<ServiceCategoryFeesSettlement>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("l_category")]
        public decimal CategoryId { get; set; }
        public virtual l_category l_category { get; set; }
        [Required]
       
        public decimal RequestFees { get; set; }
        public string SenderInvoiceNumber { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string ServiceCode { get; set; }
        public virtual ICollection<ServiceCategoryFeesSettlement> ServiceCategoryFeesSettlement { get; set; }

    }
}
