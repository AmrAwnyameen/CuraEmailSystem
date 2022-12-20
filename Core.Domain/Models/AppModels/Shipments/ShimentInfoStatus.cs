using Core.Domain.Models.AppModels.RequestDeliveryStatus;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Shipments
{
    [Table("ShimentInfoStatus", Schema = "DIG")]
    public class ShimentInfoStatus
    {
        public ShimentInfoStatus()
        {
            DeliveryStatuses = new HashSet<DeliveryStatus>();
        }
        [Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public virtual ICollection<DeliveryStatus> DeliveryStatuses { get; set; }
    }
}
