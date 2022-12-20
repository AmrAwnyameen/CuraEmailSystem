using Core.Domain.Models.AppModels.Payment.CategoryFeez;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Payment.FeesSettlement
{
    [Table("ServiceCategoryFeesSettlement", Schema = "DIG")]
    public class ServiceCategoryFeesSettlement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SettlementAccountCode { get; set; }
        public string Description { get; set; }
        [Required]
       
        public decimal Amount { get; set; }
        [ForeignKey("ServiceCategoryFees")]
        public int CategoryFeezId { get; set; }
        public virtual ServiceCategoryFees ServiceCategoryFees { get; set; }
    }
}
