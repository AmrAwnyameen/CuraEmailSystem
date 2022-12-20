using Core.Domain.Models.AppModels.UserServices;
using Infrastructure.Helpers.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models.AppModels.FarmInfo
{
    [Table("FarmInformation", Schema = "DIG")]
    public class FarmInformation
    {
        public FarmInformation()
        {
            this.UserFarms = new HashSet<UserFarms>();
        }

        [Key]
        public int Id { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Area { get; set; }
        public string GeographicalLocation { get; set; }
        public int? Code { get; set; }
        public string FarmActivityType { get; set; }
        public string PropertyType { get; set; }
        public int Acre { get; set; }
        public int Carat { get; set; }
        public int Share { get; set; }
        public string EasternBorder { get; set; }
        public string NorthernBorder { get; set; }
        public string WesternBorder { get; set; }
        public string SouthernBorder { get; set; }
        public string RequestType { get; set; }
        public string BuildingNationalID { get; set; }
        public bool IsFarm { get; set; }
        public int? GreenHouseNumber { get; set; }
        public ICollection<UserFarms> UserFarms { get; set; }

                        
         public int? F_MIG { get; set; }= (int)MigrationCodes.Migrated;
    }
}
