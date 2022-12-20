using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.LookupInfo
{
    [Table("LookupData", Schema = "DIG")]
    public class LookupData
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        [ForeignKey("Lookup")]
        public int LookupId { get; set; }

        [ForeignKey("lookupData")]
        public int? ParentCode { get; set; }
        public LookupData lookupData { get; set; }
        public virtual Lookup  Lookup { get; set; }

        

    }
}
