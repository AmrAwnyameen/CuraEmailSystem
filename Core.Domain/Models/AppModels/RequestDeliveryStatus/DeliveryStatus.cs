using Core.Domain.Models.AppModels.Shipments;
using Infrastructure.Helpers.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.RequestDeliveryStatus
{
    [Table("DeliveryStatus", Schema = "DIG")]
    public class DeliveryStatus
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Requests")]
        public decimal RequestId { get; set; }
        [Required]
        public DateTime? TimeStamp { get; set; }
        [Required]
        [ForeignKey("ShimentInfoStatus")]
        public int ShimentStatusId { get; set; }
        public string Message { get; set; }
        public string MetaData { get; set; }
        public int? F_MIG { get; set; } = (int)MigrationCodes.MigratedUpdate;
        public virtual requests Requests { get; set; }

        public virtual ShimentInfoStatus ShimentInfoStatus { get; set; }
    }
}
