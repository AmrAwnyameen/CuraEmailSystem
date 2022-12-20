using Infrastructure.Helpers.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Payment.Confirmation
{
    [Table("RequestPayment", Schema = "DIG")]
    public class RequestPayment
    {
        [Key]
        public int Id { get; set; }
        public string SenderRequestNumber { get; set; }
        public string PaymentRequestNumber { get; set; }
        [Required]

        public decimal CustomerAuthorizationAmount { get; set; }
        public string AuthorizationCode { get; set; }
        [Required]
        public string TransactionNumber { get; set; }
        public string AuthorizingMechanism { get; set; }
        public string AuthorizingInstitution { get; set; }
        public string AuthoriztionDateTime { get; set; }
        [Required]

        public decimal PaymentRequestTotalAmount { get; set; }
        [Required]

        public decimal CollectionFeesAmount { get; set; }

        public DateTime? PaymentDate { get; set; }

        [ForeignKey("Requests")]
        public decimal RequestId { get; set; }
        public virtual requests Requests { get; set; }

        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;
        public string ReconciliationDate { get; set; }

        public string IsConfirmed { get; set; }
    }
}
