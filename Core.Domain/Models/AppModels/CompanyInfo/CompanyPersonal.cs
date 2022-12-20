using Infrastructure.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.CompanyInfo
{
    [Table("CompanyPersonal", Schema = "DIG")]
    public class CompanyPersonal
    {
        [Key]
        public int Id { get; set; }
        public int? Character { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Letter { get; set; }
        public string Year { get; set; }
        public string DocumentationOffice { get; set; }
        public string CommericalRegister { get; set; }
        public string CompanyName { get; set; }
        public string Office { get; set; }

        public string TransactionCategoryDesc { get; set; }

        [ForeignKey("Requests")]
        public decimal RequestId { get; set; }

        public virtual requests Requests { get; set; }


        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;
    }
}
