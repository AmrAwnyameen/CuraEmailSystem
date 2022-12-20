using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.Logging
{
    [Table("RequestsLogger", Schema = "Logging")]
    public class RequestsLogger
    {
        [Key]
        public int Id { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public DateTime? Date { get; set; }
    }
}
