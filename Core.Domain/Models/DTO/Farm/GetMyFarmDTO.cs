using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Farm
{
    [DisplayName("GetMyFarmsByID")]
    public class GetMyFarmDTO
    {
        [Required(ErrorMessageResourceName = "NationalID", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]{14,14}$", ErrorMessageResourceName = "NationalIdLenght", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string NationalID { get; set; }
    }
}