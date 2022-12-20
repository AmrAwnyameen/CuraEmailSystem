﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Shipments
{
    [Table("VendorAddress", Schema = "DIG")]
    public class VendorAddress
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [ForeignKey("l_government")]
        public int GovernorateCode { get; set; }
        public l_government l_government { get; set; }

       
   
         public int? F_MIG { get; set; }
    }
}
