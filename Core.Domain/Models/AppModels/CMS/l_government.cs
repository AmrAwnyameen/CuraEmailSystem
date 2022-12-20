namespace Core.Domain.Models.AppModels
{
    using Core.Domain.Models.AppModels.Shipments;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms.l_government")]
    public partial class l_government
    {
        public l_government()
        {
            this.ShipmentAddresses = new HashSet<ShipmentAddress>();
        }

        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(4)]
        public string code { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [StringLength(50)]
        public string edescription { get; set; }

        public ICollection<ShipmentAddress> ShipmentAddresses { get; set; }
    }
}
