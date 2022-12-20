using Infrastructure.Helpers.ModalStates.Models;
using System.Collections.Generic;

namespace Core.Domain.Models.DTO.Validation
{
    public class GGValidationDTO
    {
        public List<ModalStateResponse> errors { get; set; }
        public string Message { get; set; }
    }
}