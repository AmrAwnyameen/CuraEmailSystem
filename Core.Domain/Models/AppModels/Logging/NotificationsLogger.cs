using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models.AppModels.Logging
{
    [Table("NotificationsLogger", Schema = "DIG")]
    public class NotificationsLogger
    {
        [Key]
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime? Date { get; set; }
        public string RequestId { get; set; }
    }
}
