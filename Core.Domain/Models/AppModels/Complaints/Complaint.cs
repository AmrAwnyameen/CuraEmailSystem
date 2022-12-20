using Core.Domain.Context;
using Core.Domain.Models.AppModels.SiteInfo;
using Infrastructure.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Complains
{
    [Table("Complaint", Schema = "DIG")]
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        public decimal UserId { get; set; }
        public string ComplainedParty { get; set; }
        public string TypeOfDamage { get; set; }
        public string ComplaintSubject { get; set; }

        [ForeignKey("UserId")]
        public Site User { get; set; }

        public int? F_MIG { get; set; } = (int)MigrationCodes.Migrated;
    }
}
