using Elmah;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infrastructure.Helpers.CustomAttributes
{
    public class FarmRequiredSlugs : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("FarmAcreOrchards", "3030");
                dictionary.Add("FarmCaratOrchards", "3031");
                dictionary.Add("FarmShareOrchards", "3032");

                var slugName = HttpContext.Current.Request.Headers.Get("ServiceSlug");
                if (!string.IsNullOrEmpty(slugName) && (value is int || value == null))
                {
                    if (new List<string>() { "MALR-10", "MALR-11", "MALR-21", "MALR-22" }.Any(s => s.Equals(slugName) && value is null))
                        return new ValidationResult(dictionary[validationContext.DisplayName]);
                }
                return ValidationResult.Success;

            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                return new ValidationResult(Infrastructure.Resources.Validations.Arabic.Ar_Responses.Error);
            }
        }


    }
}
