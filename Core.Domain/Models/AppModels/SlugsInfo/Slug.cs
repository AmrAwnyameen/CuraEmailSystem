using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.SlugsInfo
{
    [Table("Slug", Schema = "DIG")]
    public class Slug
    {
        [Key]
        public int Id { get; set; }
        public string SlugName { get; set; }

        [ForeignKey("l_category")]
        public decimal l_category_id { get; set; }
        public l_category l_category { get; set; }

        public bool IShimself { get; set; }
    }
}
