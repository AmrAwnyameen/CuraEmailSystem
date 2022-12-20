using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.CompanyPersonals
{
    [DisplayName("CompanyPersonal")]
    public class CompanyPersonalsDTO
    {
        public int? Character { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Letter { get; set; }
        public string Year { get; set; }
        public string DocumentationOffice { get; set; }
        public string CommericalRegister { get; set; }
        public string CompanyName { get; set; }
        public string Office { get; set; }
        public string TransactionCategoryDesc { get; set; }

    }
}