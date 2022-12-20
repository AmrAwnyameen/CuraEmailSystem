using Core.Domain.Models.AppModels.Shipments;
using Infrastructure.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.CMS
{
    [Table("cms.Request_ShipmentInfo")]
    public class Request_ShipmentInfo
    {
        public int Id { get; set; }
        public string ShipmentNumber { get; set; }
        public int RequireDocumentFromCitizen { get; set; }
        public string DocumentDescription { get; set; }


        [ForeignKey("Request")]
        public decimal RequestId { get; set; }
        public requests Request { get; set; }

        [ForeignKey("VendorAddress")]
        public int VendorAddressID { get; set; }
        public VendorAddress VendorAddress { get; set; }

        [ForeignKey("ReturnAddress")]
        public int ReturnAddressID { get; set; }
        public ReturnAddress ReturnAddress { get; set; }
        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;
    }
}
