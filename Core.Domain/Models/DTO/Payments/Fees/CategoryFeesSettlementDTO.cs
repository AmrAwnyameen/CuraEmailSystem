using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Payments.Fees
{
    public class CategoryFeesSettlementDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string SettlementAccountCode { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [JsonIgnore]
        public bool updated { get; set; }

    }
}