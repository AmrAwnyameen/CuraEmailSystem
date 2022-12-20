using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.LookupInfo
{
    [Table("Lookup", Schema = "DIG")]
    public class Lookup
    {
        public Lookup()
        {
            this.LookupDatas = new HashSet<LookupData>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("lookup")]
        public int? ParentId { get; set; }

        public Lookup  lookup { get; set; }
        public ICollection<LookupData>  LookupDatas { get; set; }
    }
}
