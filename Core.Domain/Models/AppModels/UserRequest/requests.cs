using Core.Domain.Models.AppModels.CompanyInfo;
using Core.Domain.Models.AppModels.Payment.Confirmation;
using Core.Domain.Models.AppModels.RequestDeliveryStatus;
using Core.Domain.Models.AppModels.Shipments;
using Core.Domain.Models.AppModels.SiteInfo;
using Infrastructure.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels
{

    [Table("req.requests")]
    public partial class requests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public requests()
        {
            citizen_reply_details = new HashSet<citizen_reply_details>();
            ShipmentAddresses = new HashSet<ShipmentAddress>();
            Companies = new HashSet<Company>();
            CompanyPersonals = new HashSet<CompanyPersonal>();
            RequestPayments = new HashSet<RequestPayment>();
            DeliveryStatuses = new HashSet<DeliveryStatus>();
        }

        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal corr_id { get; set; }

        [StringLength(30)]
        public string CORR_NUMBER { get; set; }

        [StringLength(1000)]
        public string CORR_TITLE { get; set; }

        [ForeignKey("l_category")]
        public decimal? CORR_CATEGORY_TYPE { get; set; }

    


        [ForeignKey("User")]
        public decimal CORR_SITE_ID { get; set; }

        public DateTime? CORR_CREATE_DATE { get; set; }

        public int? RequesterType { get; set; }

        public decimal F_DELETED { get; set; }

        public decimal? F_DESTROY { get; set; }

        public decimal? REQ_STATUS { get; set; }

        public DateTime? REQUEST_REPLY_DATE { get; set; }

        public decimal? CITIZEN_REPLY_DETAILS_ID { get; set; }

        [StringLength(100)]
        public string FOLDER_PATH { get; set; }

        public DateTime? CORR_DELIVERY_DATE { get; set; }

        public DateTime? CancelDate { get; set; }

        public string CancelReason { get; set; }

        public decimal F_ROUTED { get; set; }

        public DateTime? ROUTE_DATE { get; set; }

        public decimal? payment_amount { get; set; }

        [StringLength(100)]
        public string payment_refrence_no { get; set; }

        public DateTime? payment_date { get; set; }

        public decimal f_payment { get; set; }

        public decimal? request_owner_Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MIG { get; set; } = (int)MigrationCodes.Migrated;

        public decimal? f_request_done_status { get; set; }

        [StringLength(100)]
        public string Last_Modifiedby { get; set; }

        public DateTime? CompanyReplayDate { get; set; }

        public DateTime? LastRequestStatusDate { get; set; }

        [ForeignKey("sysl_Service_Channel")]
        public decimal? ChannelId { get; set; } = (int)ChannelCodes.DigitalEgypt;
        public sysl_service_channel sysl_Service_Channel { get; set; }
        public virtual l_category l_category { get; set; }

        public virtual Site User { get; set; }

        public int? DeliveryMethod { get; set; }
        public DateTime? RequestExpiryDate { get; set; }
        public bool? IfNotified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citizen_reply_details> citizen_reply_details { get; set; }

        public virtual ICollection<RequestPayment> RequestPayments { get; set; }

        public virtual citizen_reply_details citizen_reply_details1 { get; set; }


        public virtual sysl_request_status sysl_request_status { get; set; }

        public virtual ICollection<ShipmentAddress> ShipmentAddresses { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<DeliveryStatus>  DeliveryStatuses { get; set; }
        public virtual ICollection<CompanyPersonal> CompanyPersonals { get; set; }
    }
}
